/*
using UnityEngine;
using UnityEngine.UI;
using System;   //necesario para el reloj
using UnityEngine.SceneManagement;

public class ScriptUIManager : MonoBehaviour
{
    public static ScriptUIManager uiInstance;

    public Text ammoText, ammoLeftText, moneyText, timerText, playerLifeText;
    public Image bloodImg;
    private TimeSpan timeCronom;    //necesario para el reloj
    Color oranje = new Color(0.99f, 0.70f, 0.21f, 1f);
    bool pauseActive, inGame;
    public GameObject PauseMenuGO, MainMenuGO, OptionsMenuGO, ExitMenuGO;

    void Awake()
    {
        if (ScriptUIManager.uiInstance == null)
        {
            ScriptUIManager.uiInstance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        //MainMenuGO = GameObject.Find("MainMenu");
        //OptionsMenuGO = GameObject.Find("OptionsMenu");
        //ExitMenuGO = GameObject.Find("ExitMenu");
        
        MainMenuActive();

    }

    void Update()
    {
        if (inGame)
        {
            TextColor();
            BloodUI();
            TextUpdate();
            TogglePause();
        }
    }

    public void MainMenuLoadScene()
    {
        SceneManager.LoadScene(0);
        MainMenuActive();
        inGame = false;
    }

    public void NewGameLoadScene()
    {
        SceneManager.LoadScene(1);
        inGame = true;
        ResumeGame();
        PauseMenuGO = GameObject.Find("PauseMenu");

    }

    public void TogglePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

    public void PauseGame()
    {
        PauseMenuGO.SetActive(true);
        Time.timeScale = 0;
        pauseActive = true;
    }

    public void ResumeGame()
    {
        PauseMenuGO.SetActive(false);
        Time.timeScale = 1;
        pauseActive = false;
    }
    public void MainMenuActive()
    {
        MainMenuGO.SetActive(true);
        OptionsMenuGO.SetActive(false);
        ExitMenuGO.SetActive(false);
    }

    public void OptionsMenuActive()
    {
        MainMenuGO.SetActive(false);
        OptionsMenuGO.SetActive(true);
        ExitMenuGO.SetActive(false);
    }

    public void ExitMenuActive()
    {
        MainMenuGO.SetActive(false);
        OptionsMenuGO.SetActive(false);
        ExitMenuGO.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void TextUpdate()
    {
        ammoText.text = ScriptAK47.ammo.ToString();
        ammoLeftText.text = ScriptGunSystem.ammoLeft.ToString() + " | ";
        moneyText.text = "$" + ScriptGameManager.gmInstance.money.ToString();
        playerLifeText.text = ((int)ScriptGameManager.gmInstance.playerLife).ToString();
        timeCronom = TimeSpan.FromSeconds(ScriptC4Bomb.timeToExplode);      //magia negra
        string timeString = timeCronom.ToString("mm':'ss");                 //de la linda
        timerText.text = "Time: " + timeString;
    }

    void TextColor()
    {
        if (ScriptGameManager.gmInstance.money <= 0)
        {
            moneyText.color = new Color(1f, 0f, 0f, 1f);
        }
        else
        {
            moneyText.color = oranje;
        }

        if (ScriptAK47.ammo <= 0)
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
    }

    void BloodUI()
    {
        float fix = ScriptGameManager.gmInstance.playerLife / 100f;
        bloodImg.color = new Color(255, 255, 255, -fix + 1);
    }
}
*/