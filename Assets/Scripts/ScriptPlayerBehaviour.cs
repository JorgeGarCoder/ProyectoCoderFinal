using UnityEngine;

public class ScriptPlayerBehaviour : MonoBehaviour
{

    
    public void PlayerTakeDamage(float damage)
    {
        if (!ScriptGameManager.gmInstance.godMode)
        {
            ScriptGameManager.gmInstance.playerLife -= damage;
        }
    }

    /*
    public void PickAmmo(int ammo)
    {
        ScriptAK47.ammo += ammo;
    }
    */
}
