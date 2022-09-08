using UnityEngine;

public class ScriptTriggerEventManager : MonoBehaviour
{
    [SerializeField] GameObject go;
    [SerializeField] Transform tf;
    [SerializeField] int moneyUp = 500;
    [SerializeField] float rengenUp = 0.002f;

    /*
    public void Event()
    {
        Instantiate(go, tf.position, Quaternion.identity);
        print("Instanciado: " + go.name);
    }
    */

    public void Event1()
    {
        ScriptGameManager.MoneyUpDown(moneyUp);
    }

    public void Event2()
    {
        ScriptGameManager.gmInstance.regenLife += rengenUp;
    }
}
