using UnityEngine;
using System.Collections;
using UnityEngine.Animations.Rigging;

public class ScriptGunSystem : ScriptWeaponStats
{
    bool readyToShoot; //, reloading;
    public static bool shooting, reloading;

    //reference
    public Camera _Camera;
    public Transform shootPoint;
    public Transform reloadPoint;
    public RaycastHit rayHit;
    public LayerMask _layerMask;

    //graphics
    public GameObject bulletHoleGraphicGO, bloodSprayGraphicGO, magazineGO, muzzleFlashGunGO, muzzleFlashShootgunGO, muzzleFlashRifleGO, muzzleFlashSniperGO, muzzleFlashMachinegunGO;

    //Animator
    public Animator animController;

    [SerializeField] TrailRenderer _trailRenderer;
    public int weaponSelected, pistolPrice = 500, shotgunPrice = 1700, riflePrice = 2500, sniperPrice = 2750, machinegunPrice = 3000, previousSelectedWeapon, bulletsShot;
    public GameObject magazinePistolGO, magazineShootgunGO, magazineRifleGO, magazineSniperGO, magazineMachinegunGO;
    public GameObject bulletOffGO;
    public bool blockChangeWeapon;
    
    //test
    [SerializeField] Transform[] shootPos = new Transform[6];
    [SerializeField] Transform[] reloadPos = new Transform[6];
    public Rig rig;
    //


    void Start()
    {
        readyToShoot = true;
        WeaponSwitcher();
    }

    void Update()
    {
        previousSelectedWeapon = weaponSelected;

        //WeaponChanger();
        WeaponInput();

        /*if (previousSelectedWeapon != weaponSelected)
        {
            WeaponSwitcher();
        }

        if (!blockChangeWeapon)
        {
            WeaponSelect();
        }

        if (canShoot)
        {
            FireWeaponInput();
        }
        else
        {
            MeleeInput();
        }

        if (canZoom && Input.GetMouseButton(1))
        {
            _Camera.fieldOfView = 35;
        }
        else
        {
            _Camera.fieldOfView = 60;
        }

        if (reloading)
        {
            reloadTimeLeft -= Time.deltaTime;
        }*/
    }

    
    void WeaponSelect()
    {
        switch (weaponSelected)
        {
            case 1:
                PistolOn();
                blockChangeWeapon = true;
                break;

            case 2:
                ShotgunOn();
                blockChangeWeapon = true;
                break;

            case 3:
                RifleOn();
                blockChangeWeapon = true;
                break;

            case 4:
                SniperOn();
                blockChangeWeapon = true;
                break;

            case 5:
                MachineGunOn();
                blockChangeWeapon = true;
                break;

            default:
                KnifeOn();
                blockChangeWeapon = true;
                break;
        }
    }

    //inputs para cambiar el arma
    void WeaponChanger()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0) && !reloading && !ScriptUIManager2.pauseActive)
        {
            blockChangeWeapon = false;
            weaponSelected = default;

            //test
            shootPoint = shootPos[weaponSelected];
            reloadPoint = reloadPos[weaponSelected];
            //
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >= 2 && weaponSelected != 1 && !reloading && !ScriptUIManager2.pauseActive)
        {
            if (IsPistolBuy)
            {
                blockChangeWeapon = false;
                weaponSelected = 1;

                //test
                shootPoint = shootPos[weaponSelected];
                reloadPoint = reloadPos[weaponSelected];

                //
            }
            else if (ScriptBlueBase.playerOnBase)
            {
                if (ScriptGameManager.gmInstance.money >= pistolPrice)
                {
                    ScriptGameManager.MoneyUpDown(-pistolPrice);
                    blockChangeWeapon = false;
                    weaponSelected = 1;

                    //test
                    shootPoint = shootPos[weaponSelected];
                    reloadPoint = reloadPos[weaponSelected];

                    //

                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 3 && weaponSelected != 2 && !reloading && !ScriptUIManager2.pauseActive)
        {
            if (IsShotgunBuy)
            {
                blockChangeWeapon = false;
                weaponSelected = 2;

                shootPoint = shootPos[weaponSelected];
                reloadPoint = reloadPos[weaponSelected];


            }
            else if (ScriptBlueBase.playerOnBase)
            {
                if (ScriptGameManager.gmInstance.money >= shotgunPrice)
                {
                    ScriptGameManager.MoneyUpDown(-shotgunPrice);
                    blockChangeWeapon = false;
                    weaponSelected = 2;

                    shootPoint = shootPos[weaponSelected];
                    reloadPoint = reloadPos[weaponSelected];


                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 4 && weaponSelected != 3 && !reloading && !ScriptUIManager2.pauseActive)
        {
            if (IsRifleBuy)
            {
                blockChangeWeapon = false;
                weaponSelected = 3;

                //test
                shootPoint = shootPos[weaponSelected];
                reloadPoint = reloadPos[weaponSelected];

                //
            }
            else if (ScriptBlueBase.playerOnBase)
            {
                if (ScriptGameManager.gmInstance.money >= riflePrice)
                {
                    ScriptGameManager.MoneyUpDown(-riflePrice);
                    blockChangeWeapon = false;
                    weaponSelected = 3;

                    //test
                    shootPoint = shootPos[weaponSelected];
                    reloadPoint = reloadPos[weaponSelected];

                    //

                }
            }
        }


        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 5 && weaponSelected != 4 && !reloading && !ScriptUIManager2.pauseActive)
        {
            if (IsSniperBuy)
            {
                blockChangeWeapon = false;
                weaponSelected = 4;

                shootPoint = shootPos[weaponSelected];
                reloadPoint = reloadPos[weaponSelected];


            }
            else if (ScriptBlueBase.playerOnBase)
            {
                if (ScriptGameManager.gmInstance.money >= sniperPrice)
                {
                    ScriptGameManager.MoneyUpDown(-sniperPrice);
                    blockChangeWeapon = false;
                    weaponSelected = 4;

                    shootPoint = shootPos[weaponSelected];
                    reloadPoint = reloadPos[weaponSelected];


                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 6 && weaponSelected != 5 && !reloading && !ScriptUIManager2.pauseActive)
        {
            if (IsMachinegunBuy)
            {
                blockChangeWeapon = false;
                weaponSelected = 5;

                shootPoint = shootPos[weaponSelected];
                reloadPoint = reloadPos[weaponSelected];


            }
            else if (ScriptBlueBase.playerOnBase)
            {
                if (ScriptGameManager.gmInstance.money >= machinegunPrice)
                {
                    ScriptGameManager.MoneyUpDown(-machinegunPrice);
                    blockChangeWeapon = false;
                    weaponSelected = 5;

                    shootPoint = shootPos[weaponSelected];
                    reloadPoint = reloadPos[weaponSelected];

                }
            }
        }
    }


    //mantiene actualizado el arma actual en base a la variable del switch
    void WeaponSwitcher()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == weaponSelected)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
    //

    void WeaponInput()
    {
        WeaponChanger();

        //permite mantener el clic presionado
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }
        if (previousSelectedWeapon != weaponSelected)
        {
            WeaponSwitcher();
        }

        if (!blockChangeWeapon)
        {
            WeaponSelect();
        }

        if (canShoot)
        {
            FireWeaponInput();
        }
        else
        {
            MeleeInput();
        }

        if (canZoom && Input.GetMouseButton(1))
        {
            _Camera.fieldOfView = 35;
        }
        else
        {
            _Camera.fieldOfView = 60;
        }

        if (reloading)
        {
            reloadTimeLeft -= Time.deltaTime;
        }

    }

    void FireWeaponInput()
    {
        //reload
        if (Input.GetKeyDown(KeyCode.R) && ammoLeft < weaponMagazine && ammo > 0 && !reloading && !ScriptUIManager2.pauseActive)
        {
            Reload();
        }

        //shoot
        if (readyToShoot && shooting && !reloading && ammoLeft > 0 && !ScriptUIManager2.pauseActive)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }

    void Shoot()
    {
        readyToShoot = false;

        //ScriptSoundManager.smInstance

        //calculate direction with spread
        Vector3 direction = GetDirection();

        //test
        //TrailRenderer trail = Instantiate(_trailRenderer, shootPoint.position, Quaternion.identity); //test
        //StartCoroutine(SpawnTrail(trail, rayHit));  //test
        //

        //raycast
        if (Physics.Raycast(shootPoint.position, direction, out rayHit, range, _layerMask))
        {
            TrailRenderer trail = Instantiate(_trailRenderer, shootPoint.position, Quaternion.identity); 
            StartCoroutine(SpawnTrail(trail, rayHit));  

            if (rayHit.collider.CompareTag("Enemy"))
            {
                rayHit.collider.GetComponent<ScriptEnemyBehaviour>().EnemyTakeDamage(weaponDamage);
                Instantiate(bloodSprayGraphicGO, rayHit.point, Quaternion.LookRotation(rayHit.normal));

                if (rayHit.collider.GetComponent<ScriptEnemyBehaviour>().life <= 0 && !rayHit.collider.GetComponent<ScriptEnemyBehaviour>().imDead)
                {
                    ScriptGameManager.MoneyUpDown(ScriptGameManager.gmInstance.reward);
                    rayHit.collider.GetComponent<ScriptEnemyBehaviour>().imDead = true; //
                }

            }

            else if (rayHit.collider.CompareTag("Hostage"))
            {
                rayHit.collider.GetComponent<ScriptHostageBehaviour>().HostageTakeDamage(weaponDamage);
                Instantiate(bloodSprayGraphicGO, rayHit.point, Quaternion.LookRotation(rayHit.normal));

                if (rayHit.collider.GetComponent<ScriptHostageBehaviour>().life <= 0 && !rayHit.collider.GetComponent<ScriptHostageBehaviour>().imDead) //
                {
                    ScriptGameManager.MoneyUpDown(-ScriptGameManager.gmInstance.killPunish);

                    rayHit.collider.GetComponent<ScriptHostageBehaviour>().imDead = true;   //
                }
            }
            else if (rayHit.collider.CompareTag("Obstacle")) //test
            {
                Instantiate(bulletHoleGraphicGO, rayHit.point, Quaternion.LookRotation(rayHit.normal));
            }
        }

        //Instantiate(muzzleFlashGO, shootPoint.position, Quaternion.identity);
        animController.SetBool("IsShooting", true);

        switch (weaponSelected)
        {
            case 1:
                //Instantiate(muzzleFlashGO, shootPoint.position, Quaternion.identity);
                Instantiate(muzzleFlashGunGO, shootPoint.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(muzzleFlashShootgunGO, shootPoint.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(muzzleFlashMachinegunGO, shootPoint.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(muzzleFlashSniperGO, shootPoint.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(muzzleFlashMachinegunGO, shootPoint.position, Quaternion.identity);
                break;

        }

        if (isShootgun)
        {
            if (bulletsShot <= 1)
            {
                ammoLeft--;
                ammoLeftAux[weaponSelected]--;
            }
        }
        else
        {
            ammoLeft--;
            ammoLeftAux[weaponSelected]--;
        }

        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && ammoLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    Vector3 GetDirection()
    {
        Vector3 direction = _Camera.transform.forward;

        if (AddBulletSpread)
        {
            direction += new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread));
            direction.Normalize();
        }
        return direction;
    }

    IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit Hit)
    {
        float time = 0;
        Vector3 startPosition = Trail.transform.position;

        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, Hit.point, time);
            time += Time.deltaTime / Trail.time;
            yield return null;
            //Animator.SetBool("IsShooting", false);
            Trail.transform.position = Hit.point;
            //Instantiate(_ImpactPartSys, Hit.point, Quaternion.LookRotation(Hit.normal));
            //Destroy(Trail.gameObject, Trail.time);
        }
    }

    void ResetShot()
    {
        readyToShoot = true;
        animController.SetBool("IsShooting", false);
    }

    void Reload()
    {
        reloading = true;
        animController.SetBool("IsReloading", true);

        //desactivar el RIG al recargar
        rig.weight = 0f;
        
        //

        switch (weaponSelected)
        {
            case 1:
                Instantiate(magazinePistolGO, reloadPos[weaponSelected].position, Quaternion.identity);
                break;
            case 2:
                Instantiate(magazineShootgunGO, reloadPos[weaponSelected].position, Quaternion.identity);
                Instantiate(magazineShootgunGO, reloadPos[weaponSelected].position, Quaternion.identity);
                break;
            case 3:
                Instantiate(magazineRifleGO, reloadPos[weaponSelected].position, Quaternion.identity);
                break;
            case 4:
                Instantiate(magazineSniperGO, reloadPos[weaponSelected].position, Quaternion.identity);
                break;
            case 5:
                Instantiate(magazineMachinegunGO, reloadPos[weaponSelected].position, Quaternion.identity);
                break;

        }
        reloadTimeLeft = reloadTime;
        magazineGO.SetActive(false);
        Invoke("ReloadFinished", reloadTime);
    }

    public void ReloadTimer()
    {
        reloadTimeLeft = reloadTime;
        reloadTimeLeft -= Time.deltaTime;
    }

    public void ReloadFinished()
    {
        if (ammo + ammoLeft < weaponMagazine)
        {
            ammoLeft += ammo;
            ammo = 0;

            ammoLeftAux[weaponSelected] = 0; //test
        }
        else
        {
            int i = weaponMagazine - ammoLeft;
            ammoLeft += i;
            ammo -= i;

            ammoLeftAux[weaponSelected] += i; //test
            ammoAux[weaponSelected] -= i; //test
        }

        reloading = false;
        animController.SetBool("IsReloading", false);
        magazineGO.SetActive(true);

        //activar el rig al terminar la regarga
        rig.weight = 1f;
        //
    }

    void MeleeInput()
    {
        if (shooting && !canShoot && !ScriptUIManager2.buyActive)
        {
            MeleeAtack();
        }
    }

    void MeleeAtack()
    {
        Vector3 direction = transform.forward;

        if (Physics.Raycast(_Camera.transform.position, direction, out rayHit, range, _layerMask))
        {

            if (rayHit.collider.CompareTag("Enemy"))
            {
                rayHit.collider.GetComponent<ScriptEnemyBehaviour>().EnemyTakeDamage(weaponDamage);
                Instantiate(bloodSprayGraphicGO, rayHit.point, Quaternion.LookRotation(rayHit.normal));
            }

            else if (rayHit.collider.CompareTag("Hostage"))
            {
                rayHit.collider.GetComponent<ScriptHostageBehaviour>().HostageTakeDamage(weaponDamage);
                Instantiate(bloodSprayGraphicGO, rayHit.point, Quaternion.LookRotation(rayHit.normal));

                if (rayHit.collider.GetComponent<ScriptHostageBehaviour>().life <= 0)
                {
                    ScriptGameManager.MoneyUpDown(-ScriptGameManager.gmInstance.killPunish);
                }
            }
            else if (rayHit.collider.CompareTag("Obstacle")) //test
            {
                Instantiate(bulletHoleGraphicGO, rayHit.point, Quaternion.LookRotation(rayHit.normal));
            }
        }
    }
}
