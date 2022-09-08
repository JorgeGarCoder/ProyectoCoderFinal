using UnityEngine;

public class ScriptEventManager : MonoBehaviour
{
    void OnEnable()
    {
        ScriptEvent.Event1 += Event1;
        ScriptEvent.Event2 += Event2;
        ScriptEvent.Event3 += Event3;
    }

    void Event1()
    {
        print("event1");
    }

    void Event2()
    {
        print("event2");
    }

    void Event3()
    {
        print("event3");
    }

    private void OnDisable()
    {
        ScriptEvent.Event1 -= Event1;
        ScriptEvent.Event2 -= Event2;
        ScriptEvent.Event3 -= Event3;
    }
}