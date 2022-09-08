using UnityEngine;

public class ScriptC4Bomb : MonoBehaviour
{
    float distanceLeft;
    public static float timeToExplode, timerMaxBomb = 90f; //90f
    [SerializeField] C4Behaviour C4behaviour;
    public Transform playerTransform;
    enum C4Behaviour { active, explode, defused }
    public static float timeOfDefuse = 10f;
    public static bool IsDefusingBool = false;

    //test
    public ParticleSystem explosionPS;
    bool exploded;
    float radius = 20f;
    float explosionForce = 2f;
    int damage = 100;
    int reward = 800;
    //

    void SetBombBehaviour()
    {
        switch (C4behaviour)
        {
            case C4Behaviour.active:

                if (ScriptGameManager.gmInstance.bombDefused)
                {
                    ScriptGameManager.gmInstance.bombDefused = false;
                }

                CheckDistance();
                Timer();

                if (IsDefusingBool)
                {
                    Defusing();
                }
                break;

            case C4Behaviour.explode:
                
                if (!exploded)
                {
                    ExplodeBomb();
                    exploded = true;
                }
                break;

            case C4Behaviour.defused:
                break;
        }
    }

    void Start()
    {
        C4behaviour = C4Behaviour.active;
    }

    void Update()
    {
        SetBombBehaviour();
    }

    void Timer()
    {
        if (timeToExplode > 0)
        {
            timeToExplode -= Time.deltaTime;

        }
        else if (timeToExplode <= 0)
        {
            C4behaviour = C4Behaviour.explode;
        }
    }

    void CheckDistance()
    {
        Vector3 magn = (playerTransform.transform.position - transform.position);
        Vector3 norm = magn.normalized;
        distanceLeft = magn.magnitude;
        Vector3 distance = norm * distanceLeft;
        
        if (distanceLeft <= 1.75f && Input.GetKey(KeyCode.E))
        {
            IsDefusingBool = true;
        }
        else
        {
            IsDefusingBool = false;
            timeOfDefuse = 10f;
        }
    }

    void Defused()
    {
        C4behaviour = C4Behaviour.defused;
        transform.gameObject.SetActive(false);
        ScriptGameManager.gmInstance.bombDefused = true;
        ScriptGameManager.MoneyUpDown(reward);
    }

    void Defusing()
    {
        if (timeOfDefuse > 0)
        {
            timeOfDefuse -= Time.deltaTime;
        }
        else
        {
            Defused();
            IsDefusingBool = false;
        }
    }

    void ExplodeBomb()
    {
        explosionPS.Play();

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider near in colliders)
        {
            Rigidbody rb = near.GetComponent<Rigidbody>();

            if (rb != null)
            {
                if (rb.gameObject.CompareTag("Enemy"))
                {
                    rb.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);
                    rb.GetComponent<ScriptEnemyBehaviour>().EnemyTakeDamage(damage);

                }
                if (rb.gameObject.CompareTag("Player"))
                {
                    rb.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);
                    ////rb.GetComponent<ScriptGameManager>().PlayerTakeDamage(damage);
                    //ScriptPlayerBehaviour.gmInstance.PlayerTakeDamage(damage);
                    rb.gameObject.GetComponent<ScriptPlayerBehaviour>().PlayerTakeDamage(damage);

                }
                if (rb.gameObject.CompareTag("Hostage"))
                {
                    rb.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);
                    rb.GetComponent<ScriptHostageBehaviour>().HostageTakeDamage(damage);
                }
            }
        }
    }
}
