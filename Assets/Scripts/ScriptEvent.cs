using UnityEngine;
using System;

public class ScriptEvent : MonoBehaviour
{
    public static event Action Event1;
    public static event Action Event2;
    public static event Action Event3;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Event1?.Invoke();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Event2?.Invoke();
        }

        if (Input.GetMouseButtonDown(2))
        {
            Event3?.Invoke();
        }
    }
}