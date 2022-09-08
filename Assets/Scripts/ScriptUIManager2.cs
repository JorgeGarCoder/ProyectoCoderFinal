using UnityEngine;
using UnityEngine.UI;
using System;   //necesario para el reloj
using UnityEngine.SceneManagement;

public class ScriptUIManager2 : MonoBehaviour
{
    public static ScriptUIManager2 uiInstance2;

    public Text ammoText, ammoLeftText, moneyText, timerText, playerLifeText, moneyUpDownText, mision1Text, mision2Text, mision3Text;
    public Image bloodImg;
    private TimeSpan timeCronom;    //necesario para el reloj
    Color oranje = new Color(0.99f, 0.70f, 0.21f, 1f);
    public static bool hudUpdate, pauseActive, buyActive, moneyUpDownBool;
    public static float moneyUpDownTimer = 5f;
    public GameObject pauseMenuGO, gameOverGO, buyMenuGO, moneyUpDownGO, defuseBarGO, victoryMenuGO, blueBaseIconGO, reloadBarGO;
    public Image defuseFrontBar, reloadFrontBar;
    public ScriptWeaponSO _pistolSO, _shotgunSO, _AWPSO, _AK47SO, _machinegunSO, _CurrentSO;
    public Text priceText, countryText, caliberText, clipText, rateText, weightText, projectileText, muzzlespdText, muzzleEnText;
    public Image weaponImage;

    //test
    public ScriptMisionsSO mision1SO, mision2SO, mision3SO;
    //

    void OnEnable()
    {
        ScriptGunSystem.reloading = false;
        hudUpdate = true;
        pauseActive = false;
        gameOverGO.SetActive(false);
    }

    void Update()
    {
        if (hudUpdate)
        {
            TextColorUpdate();
            TextUpdate();
            TogglePauseMenu();
            ToggleBuyMenu();
            BuyMenuUpdate(_CurrentSO);
            HudUpdate();
            WinCondHud();
        }
        
    }

    void HudUpdate()
    {
        if (ScriptC4Bomb.IsDefusingBool)
        {
            defuseBarGO.SetActive(true);
            DefuseBarUpdate();
        }
        else
        {
            defuseBarGO.SetActive(false);
        }

        if (moneyUpDownBool)
        {
            MoneyUpDownUpdate();
        }

        if (ScriptGunSystem.reloading)
        {
            reloadBarGO.SetActive(true);
            ReloadBarUpdate();
        }
        else
        {
            reloadBarGO.SetActive(false);
        }

        BloodUI();
    }

    void WinCondHud()
    {
        if (ScriptGameManager.areYouWinning)
        {
            VictoryMenu();
        }

        if (ScriptGameManager.gameOver)
        {
            Invoke("GameOverMenu", 3f);
        }

        if (ScriptGameManager.gmInstance.playerLife <= 0)
        {
            CancelInvoke();
            GameOverMenu();
        }
    }

    public void MachinegunMenu()
    {
        _CurrentSO = _machinegunSO;
        BuyMenuUpdate(_CurrentSO);
        //compra 
    }
    public void AWPMenu()
    {
        _CurrentSO = _AWPSO;
        BuyMenuUpdate(_CurrentSO);
        //compra awp
    }
    public void AK47Menu()
    {
        _CurrentSO = _AK47SO;
        BuyMenuUpdate(_CurrentSO);
        //compra ak47
    }

    
    public void ShotgunMenu()
    {
        _CurrentSO = _shotgunSO;
        BuyMenuUpdate(_CurrentSO);
        //compra 
    }
    public void GlockMenu()
    {
        _CurrentSO = _pistolSO;
        BuyMenuUpdate(_CurrentSO);
        //compra 
    }


    public void BuyMenuUpdate(ScriptWeaponSO _CurrentSO)
    {
        weaponImage.sprite = _CurrentSO.weaponSprite;
        priceText.text = _CurrentSO.weaponPriceInt.ToString();
        countryText.text = _CurrentSO.weaponCountryOfOriginSg;
        caliberText.text = _CurrentSO.weaponCaliberFlo.ToString();
        clipText.text = _CurrentSO.weaponClipCapacityInt.ToString();
        rateText.text = _CurrentSO.weaponRateOfFireInt.ToString();
        weightText.text = _CurrentSO.weaponWeightLoadedFlo.ToString();
        projectileText.text = _CurrentSO.weaponProjectileWeightFlo.ToString();
        muzzlespdText.text = _CurrentSO.weaponMuzzleVelocityInt.ToString();
        muzzleEnText.text = _CurrentSO.weaponMuzzleEnergyInt.ToString();
    }

    public void MainMenuLoadScene()
    {
        SceneManager.LoadScene(0);
        hudUpdate = false;
    }

    public void TogglePauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !buyActive)
        {
            if (pauseActive)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    
    public void ToggleBuyMenu()
    {
        if (Input.GetKeyDown(KeyCode.B) && !pauseActive && ScriptBlueBase.playerOnBase)
        {
            if (buyActive)
            {
                ResumeFromBuy();
            }
            else
            {
                ScriptFPSRB.canMove = false;
                ScriptGunSystem.canShoot = false;
                buyMenuGO.SetActive(true);
                buyActive = true;
            }
        }
    }

    public void ResumeFromBuy()
    {
        ScriptFPSRB.canMove = true;
        ScriptGunSystem.canShoot = true;
        buyMenuGO.SetActive(false);
        buyActive = false;
    }

    public void VictoryMenu()
    {
        victoryMenuGO.SetActive(true);
        pauseActive = true;
        Time.timeScale = 0;
    }

    public void GameOverMenu()
    {
        gameOverGO.SetActive(true);
        pauseActive = true;
        Time.timeScale = 0;
    }

    public void PauseGame()
    {
        pauseMenuGO.SetActive(true);
        pauseActive = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenuGO.SetActive(false);
        pauseActive = false;
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void TextUpdate()
    {
        ammoText.text = ScriptWeaponStats.ammo.ToString();
        ammoLeftText.text = ScriptGunSystem.ammoLeft.ToString() + " | ";
        moneyText.text = "$" + ScriptGameManager.gmInstance.money.ToString();
        playerLifeText.text = ((int)ScriptGameManager.gmInstance.playerLife).ToString(); //comvierte en int el float
        timeCronom = TimeSpan.FromSeconds(ScriptC4Bomb.timeToExplode);      //magia negra
        string timeString = timeCronom.ToString("mm':'ss");                 //de la linda
        timerText.text = "Time: " + timeString;
        mision1Text.text = mision1SO.misionName.ToString() + ": " + ScriptGameManager.gmInstance.hostagesLeft.ToString() + "/" + mision1SO.number.ToString();
        mision2Text.text = mision2SO.misionName.ToString();
        mision3Text.text = mision3SO.misionName.ToString();
        
        if (moneyUpDownBool)
        {
            moneyUpDownGO.SetActive(true);

            if (ScriptGameManager.moneyUpDown <= 0)
            {
                moneyUpDownText.text = ScriptGameManager.moneyUpDown.ToString();
            }
            else
            {
                moneyUpDownText.text = "+ " + ScriptGameManager.moneyUpDown.ToString();
            }
        }
        else
        {
            moneyUpDownGO.SetActive(false);
        }

        if (ScriptBlueBase.playerOnBase)
        {
            blueBaseIconGO.SetActive(true);
        }
        else
        {
            blueBaseIconGO.SetActive(false);
        }
    }

    void MoneyUpDownUpdate()
    {
        if (moneyUpDownTimer > 0)
        {
            moneyUpDownTimer -= Time.deltaTime;
        }
        else
        {
            moneyUpDownBool = false;
            moneyUpDownTimer = 5f;
            return;
        }
    }

    void TextColorUpdate()
    {
        if (ScriptGameManager.gmInstance.money <= 0)
        {
            moneyText.color = new Color(1f, 0f, 0f, 1f);
        }
        else
        {
            moneyText.color = oranje;
        }

        if (ScriptWeaponStats.ammo <= 0)
        {
            ammoText.color = new Color(1f, 0f, 0f, 1f);
        }
        else
        {
            ammoText.color = oranje;
        }

        if (ScriptGunSystem.ammoLeft <= 0)
        {
            ammoLeftText.color = new Color(1f, 0f, 0f, 1f);
        }
        else
        {
            ammoLeftText.color = oranje;
        }

        if (ScriptC4Bomb.timeToExplode <= 0)
        {
            timerText.color = new Color(1f, 0f, 0f, 1f);
        }
        else
        {
            timerText.color = oranje;
        }

        if (ScriptGameManager.gmInstance.playerLife <= 0)
        {
            playerLifeText.color = new Color(1f, 0f, 0f, 1f);
        }
        else
        {
            playerLifeText.color = oranje;
        }

        if (ScriptGameManager.moneyUpDown <= 0)
        {
            moneyUpDownText.color = Color.red;
        }
        else
        {
            moneyUpDownText.color = Color.green;
        }



        if (ScriptGameManager.gmInstance.hostagesLeft <= 0)
        {
            if (ScriptGameManager.gmInstance.hostagesRescued <= 0)
            {
                mision1Text.color = Color.red;
            }
            if (ScriptGameManager.gmInstance.hostagesRescued >= 1 && ScriptGameManager.gmInstance.hostagesRescued <= 2 )
            {
                mision1Text.color = Color.yellow;
            }
            else if (ScriptGameManager.gmInstance.hostagesRescued >= 3)
            {
                mision1Text.color = Color.green;
            }
        }


        if (ScriptC4Bomb.timeToExplode > 0)
        {
            if (!ScriptGameManager.gmInstance.bombDefused)
            {
                mision2Text.color = Color.white;
            }
            else
            {
                mision2Text.color = Color.green;
            }
        }
        else
        {
            mision2Text.color = Color.red;
        }
        


        if (ScriptGameManager.gmInstance.allEnemyDead)
        {
            mision3Text.color = Color.green;
        }
        else
        {
            mision3Text.color = Color.white;
        }
    }

    void BloodUI()
    {
        float fix = ScriptGameManager.gmInstance.playerLife / 100f;
        bloodImg.color = new Color(255, 255, 255, -fix + 1);
    }

    void DefuseBarUpdate()
    {
        defuseFrontBar.fillAmount = ScriptC4Bomb.timeOfDefuse / 10f;
    }

    void ReloadBarUpdate()
    {
        reloadFrontBar.fillAmount = ScriptWeaponStats.reloadTimeLeft / ScriptWeaponStats.reloadTime;
    }
}