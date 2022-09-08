using UnityEngine;
using UnityEngine.Events;

public class ScriptTriggerEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent myTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            myTrigger.Invoke();
        }
    }
}