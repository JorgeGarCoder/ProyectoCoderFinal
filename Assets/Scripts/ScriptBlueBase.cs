using UnityEngine;

public class ScriptBlueBase : MonoBehaviour
{
    public static bool playerOnBase;
    int rescueReward = 1000;

    public void OnTriggerStay(Collider other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            playerOnBase = true;
        }

        if (other != null && other.gameObject.CompareTag("Hostage"))
        {
            other.gameObject.SetActive(false);
            ScriptGameManager.MoneyUpDown(rescueReward);
            ScriptGameManager.gmInstance.hostagesLeft--;
            ScriptGameManager.gmInstance.hostagesRescued++;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            playerOnBase = false;
        }
    }
}
