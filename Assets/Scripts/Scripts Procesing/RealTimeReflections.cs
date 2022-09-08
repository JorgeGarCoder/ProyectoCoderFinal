using UnityEngine;

public class RealTimeReflections : MonoBehaviour
{
    private void Update()
    {
        GetComponent<ReflectionProbe>().RenderProbe();
    }
}
