using UnityEngine;

public class ScriptWeaponStats : MonoBehaviour
{
    public string weaponName;
    public int weaponCost, weaponMagazine, weaponDamage, weaponSecondaryDamage, bulletsPerTap;
    public int[] ammoLeftAux, ammoAux;
    //public int[] ammoLeftAux = new int[] { 0, 40, 32, 90, 30, 200 };
    //public int[] ammoAux = new int[] { 0, 40, 32, 90, 30, 200 };
    public static int ammo, ammoLeft;
    public float timeBetweenShooting, range, timeBetweenShots, spread;
    public static float reloadTime, reloadTimeLeft;
    public bool allowButtonHold, AddBulletSpread, isShootgun, IsPistolBuy, IsShotgunBuy, IsRifleBuy, IsSniperBuy, IsMachinegunBuy;
    public static bool canShoot, canZoom;

    void Awake()
    {
        ammoAux = new int[] { 0, 40, 32, 90, 30, 200 };
        ammoLeftAux = new int[] { 0, 10, 8, 30, 10, 100 };
    }

    public void MachineGunOn()
    {
        canShoot = true;
        weaponName = "FN M249 Para";
        weaponCost = 5750;
        weaponMagazine = 100;
        //ammo = 200;
        weaponDamage = 32;
        weaponSecondaryDamage = 0;
        bulletsPerTap = 1;
        timeBetweenShooting = 0.08f;
        spread = 0.04f;
        range = 100f;
        reloadTime = 7f;
        timeBetweenShots = 3f;
        allowButtonHold = true;
        AddBulletSpread = true;
        //ammoLeft = weaponMagazine;
        isShootgun = false;
        canZoom = false;

        if (!IsMachinegunBuy)
        {
            ammo = ammoAux[5];
            ammoLeft = ammoLeftAux[5];
            IsMachinegunBuy = true;
        }
        else
        {
            ammo = ammoAux[5];
            ammoLeft = ammoLeftAux[5];
        }
    }

    public void SniperOn()
    {
        canShoot = true;
        weaponName = "Magnum Sniper";
        weaponCost = 4750;
        weaponMagazine = 10;
        //ammo = 30;
        weaponDamage = 115;
        weaponSecondaryDamage = 0;
        bulletsPerTap = 1;
        timeBetweenShooting = 3f;
        spread = 0.05f;
        range = 100f;
        reloadTime = 3f;
        timeBetweenShots = 3f;
        allowButtonHold = false;
        AddBulletSpread = false;
        //ammoLeft = weaponMagazine;
        isShootgun = false;
        canZoom = true;

        if (!IsSniperBuy)
        {
            ammo = ammoAux[4];
            ammoLeft = ammoLeftAux[4];
            IsSniperBuy = true;
        }
        else
        {
            ammo = ammoAux[4];
            ammoLeft = ammoLeftAux[4];
        }
    }

    public void RifleOn()
    {
        canShoot = true;
        weaponName = "AK-47";
        weaponCost = 2500;
        weaponMagazine = 30;
        //ammo = 90;
        weaponDamage = 36;
        weaponSecondaryDamage = 0;
        bulletsPerTap = 1;
        timeBetweenShooting = 0.2f;
        spread = 0.035f;
        range = 80f;
        reloadTime = 3f;
        timeBetweenShots = 3f;
        allowButtonHold = true;
        AddBulletSpread = true;
        //ammoLeft = weaponMagazine;
        isShootgun = false;
        canZoom = false;

        if (!IsRifleBuy)
        {
            ammo = ammoAux[3];
            ammoLeft = ammoLeftAux[3];
            IsRifleBuy = true;
        }
        else
        {
            ammo = ammoAux[3];
            ammoLeft = ammoLeftAux[3];
        }
    }

    public void ShotgunOn()
    {
        canShoot = true;
        weaponName = "Benelli M3 Super90";
        weaponCost = 1700;
        weaponMagazine = 8;
        //ammo = 32;
        weaponDamage = 180;
        weaponSecondaryDamage = 0;
        bulletsPerTap = 6;
        timeBetweenShooting = 1f;
        spread = 0.06f;
        range = 20f;
        reloadTime = 2f;
        timeBetweenShots = 0f;
        allowButtonHold = false;
        AddBulletSpread = true;
        //ammoLeft = weaponMagazine;
        isShootgun = true;
        canZoom = false;

        if (!IsShotgunBuy)
        {
            ammo = ammoAux[2];
            ammoLeft = ammoLeftAux[2];
            IsShotgunBuy = true;
        }
        else
        {
            ammo = ammoAux[2];
            ammoLeft = ammoLeftAux[2];
        }
    }

    public void PistolOn()
    {
        canShoot = true;
        weaponName = "Glock18 Select Fire";
        weaponCost = 400;
        weaponMagazine = 10;
        //ammo = 100;
        weaponDamage = 25;
        weaponSecondaryDamage = 0;
        bulletsPerTap = 1;
        timeBetweenShooting = 0.1f;
        spread = 0.01f;
        range = 30f;
        reloadTime = 1.5f;
        timeBetweenShots = 0.08f;
        allowButtonHold = false;
        AddBulletSpread = false;
        //ammoLeft = weaponMagazine;
        isShootgun = false;
        canZoom = false;

        if (!IsPistolBuy)
        {
            ammo = ammoAux[1];
            ammoLeft = ammoLeftAux[1];
            IsPistolBuy = true;
        }
        else
        {
            ammo = ammoAux[1];
            ammoLeft = ammoLeftAux[1];
        }
    }

    public void KnifeOn()
    {
        canShoot = false;
        weaponName = "Knife";
        //weaponCost = 0;
        //weaponMagazine = 0;
        //ammoAux = ammo;
        //ammoLeftAux = ammoLeft;
        weaponDamage = 25;
        //weaponSecondaryDamage = 0;
        bulletsPerTap = 1;
        timeBetweenShooting = 1.5f;
        spread = 0.01f;
        range = 1f;
        reloadTime = 1f;
        timeBetweenShots = 1.5f;
        allowButtonHold = false;
        AddBulletSpread = false;
        isShootgun = false;
        canZoom = false;

        //test
        ammo = ammoAux[0];
        ammoLeft = ammoLeftAux[0];
        //

    }
}

