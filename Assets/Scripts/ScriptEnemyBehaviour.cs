using UnityEngine;

public class ScriptEnemyBehaviour : MonoBehaviour
{
    float distanceLeft, timeLeft, speedToLook = 2f, timeBetweenAttacks = 2f,  bulletSpeed = 3f, rangeOfView = 30f;
    public float life = 100;
    //public int reward = 150;
    [SerializeField] EnemyBehaviour enemyBehaviour;
    public GameObject bulletGO, weaponGO, muzzleFlash;
    public Transform shootPoint, playerTransform;
    [SerializeField] Animator anim;
    public bool imDead;

    enum EnemyBehaviour { waiting, attacking, dead }

    void SetEnemyBehaviour()
    {
        switch (enemyBehaviour)
        {
            case EnemyBehaviour.waiting:
                break;
            case EnemyBehaviour.attacking:
                LookAtPlayer();
                Attack();
                break;
            case EnemyBehaviour.dead:

                break;

        }
    }

    void BehaviourChanger()
    {
        if (distanceLeft < rangeOfView && !imDead)
        {
            enemyBehaviour = EnemyBehaviour.attacking;
        }
        else
        {
            enemyBehaviour = EnemyBehaviour.waiting;
        }    
    }

    void Start()
    {
        ResetTimer();
        enemyBehaviour = EnemyBehaviour.waiting;
    }

    void Update()
    {
        CheckDistance();
        SetEnemyBehaviour();
        BehaviourChanger();
    }

    void Timer()
    {
        if (timeBetweenAttacks > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft <= 4)
        {
            anim.SetBool("IsShooting", false);
        }
        if (timeLeft <= 0)
        {
            Shoot();
            ResetTimer();
        }
    }

    void ResetTimer() 
    {
        //timeLeft = timeBetweenAttacks;
        float i = Random.Range(timeBetweenAttacks - 1, timeBetweenAttacks);
        timeLeft = i;
    }

    void LookAtPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedToLook * Time.deltaTime);
    }

    void CheckDistance()
    {
        Vector3 magn = (playerTransform.transform.position + new Vector3(0, 1.35f, 0) - shootPoint.transform.position);
        Vector3 norm = magn.normalized;
        distanceLeft = magn.magnitude;
        Vector3 distance = norm * distanceLeft;
    }

    void Attack()
    {
        if (!imDead)
        {
            Timer();

            if (timeLeft <= 0)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        anim.SetBool("IsShooting", true);

        //test
        Instantiate(muzzleFlash, shootPoint.position, Quaternion.identity);


        GameObject cloneBullet = Instantiate(bulletGO, shootPoint.position, shootPoint.rotation);
        cloneBullet.GetComponent<Rigidbody>().AddForce(shootPoint.forward * bulletSpeed, ForceMode.Impulse);
    }

    public void EnemyTakeDamage(float damage)
    {
        life -= damage;
        IsAlive();
    }

    void IsAlive()
    {
        if (life <= 0 && !imDead)
        {
            enemyBehaviour = EnemyBehaviour.dead;    //

            //Dead();   //
            ScriptGameManager.gmInstance.enemiesLeft--;
            //ScriptGameManager.MoneyUpDown(reward);

            anim.SetBool("IsDead", true);   //
            Invoke("CleanBody", 10);    //

            weaponGO.SetActive(false);
        }
    }

    void CleanBody()
    {
        transform.gameObject.SetActive(false);
    }


    public void Dead()
    {
        //ScriptGameManager.gmInstance.enemiesLeft--;   //
        //ScriptGameManager.MoneyUpDown(reward);    //
        //transform.gameObject.SetActive(false);    //

        //Instantiate(ammoGO, transform.position + Vector3.up, Quaternion.identity);
    }
}
