using UnityEngine;

public class ScriptAWP : ScriptWeaponStats
{
    void Start()
    {
        weaponName = "Magnum Sniper";
        weaponCost = 4750;
        weaponMagazine = 10;
        ammo = 30;
        weaponDamage = 115;
        weaponSecondaryDamage = 0;
        bulletsPerTap = 1;
        timeBetweenShooting = 3f;
        //spread = new Vector3 (0.02f, 0.02f, 0.02f);
        range = 150f;
        reloadTime = 3f;
        timeBetweenShots = 0.05f;
        allowButtonHold = false;
    }
}
