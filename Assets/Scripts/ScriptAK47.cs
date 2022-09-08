public class ScriptAK47 : ScriptWeaponStats
{
    public void Start()
    {
        weaponName = "AK-47";
        weaponCost = 2500;
        weaponMagazine = 30;
        ammo = 90;
        ammoLeft = 30;
        weaponDamage = 36;
        weaponSecondaryDamage = 0;
        bulletsPerTap = 1;
        timeBetweenShooting = 0.2f;
        spread = 0.03f;
        range = 100f;
        reloadTime = 3f;
        timeBetweenShots = 3f;
        allowButtonHold = true;
        AddBulletSpread = true;
        ammoLeft = weaponMagazine;
    }
}
