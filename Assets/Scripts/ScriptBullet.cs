using UnityEngine;

public class ScriptBullet : MonoBehaviour
{
    float timer = 2f;
    float damage = 15;

    public void Start()
    {
        Destroy(gameObject, timer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<ScriptPlayerBehaviour>().PlayerTakeDamage(damage);

            }
            else if (collision.gameObject.CompareTag("Hostage"))
            {
                collision.gameObject.GetComponent<ScriptHostageBehaviour>().HostageTakeDamage(damage);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
