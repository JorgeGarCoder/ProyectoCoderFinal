/*using UnityEngine;

public class ScriptAmmo : MonoBehaviour
{
    float time = 15f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int box = 30;
            collision.gameObject.GetComponent<ScriptPlayerBehaviour>().PickAmmo(box);
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 1f, 0));
        time -= Time.deltaTime;

        if (ScriptGameManager.gmInstance.playerDead || time <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}*/
