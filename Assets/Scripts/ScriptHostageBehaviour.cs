using UnityEngine;

public class ScriptHostageBehaviour : MonoBehaviour
{
    public float life = 100f;
    float speedToLook = 2f, moveSpeed = 3f, distanceLeft;
    bool IsFollowing, pickedReward;
    public int pickReward = 500;

    [SerializeField] HostageBehaviour hostageBehaviour;
    [SerializeField] Animator anim;
    [SerializeField] Transform playerTransform;
    public bool imDead;
    public Animator hostageAnim;

    enum HostageBehaviour
    {
        waiting, follow
    }

    void SetHostageBehaviour()
    {
        switch (hostageBehaviour)
        {
            case HostageBehaviour.waiting:
                break;

            case HostageBehaviour.follow:
                LookAtPlayer();
                MoveForward();
                break;
        }
    }

    void Start()
    {
        hostageBehaviour = HostageBehaviour.waiting;
    }

    void Update()
    {
        CheckDistance();
        SetHostageBehaviour();
        BehaviourChanger();
    }

    void BehaviourChanger()
    {
        if (Input.GetKeyDown(KeyCode.E) && distanceLeft <= 2)
        {
            if (!IsFollowing)
            {
                hostageBehaviour = HostageBehaviour.follow;
                IsFollowing = true;
                
                if (!pickedReward)
                {
                    ScriptGameManager.MoneyUpDown(pickReward);
                    pickedReward = true;
                }
            }
            else
            {
                hostageBehaviour = HostageBehaviour.waiting;
                IsFollowing = false;
            }
        }
    }

    void CheckDistance()
    {
        Vector3 magn = (playerTransform.position - transform.position);
        Vector3 norm = magn.normalized;
        distanceLeft = magn.magnitude;
        Vector3 distance = norm * distanceLeft;
    }

    public void IsAlive()
    {
        if (life <= 0 && !imDead)
        {
            hostageBehaviour = HostageBehaviour.waiting;    //
            //transform.gameObject.SetActive(false);
            ScriptGameManager.gmInstance.hostagesLeft--;

            anim.SetBool("IsDead", true);   //
            Invoke("CleanBody", 10);    //
        }
    }

    void CleanBody()
    {
        transform.gameObject.SetActive(false);
    }

    void LookAtPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation((playerTransform.position - transform.position));

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedToLook * Time.deltaTime);
    }

    void MoveForward()
    {
        if (distanceLeft >= 5 && distanceLeft <= 20)
        {
            Vector3 dir = (playerTransform.position - transform.position).normalized;
            transform.position += dir * moveSpeed * Time.deltaTime;

            anim.SetBool("IsRunning", true);
        }
        else if (distanceLeft <= 5) anim.SetBool("IsRunning", false);
    }

    public void HostageTakeDamage(float damage)
    {
        life -= damage;
        IsAlive();
    }
}