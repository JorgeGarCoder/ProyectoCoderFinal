using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptUIManager1 : MonoBehaviour
{
    public static ScriptUIManager1 uiInstance1;

    public GameObject mainMenuGO, optionsMenuGO, howToPlayMenuGO, creditsMenuGO, exitMenuGO;
    public bool optionsBool;
    public Slider _soundSlider;
    public Slider _SFXSlider;
    public Toggle _soundToggle;
    public Toggle _SFXToggle;
    public Toggle _godModeToggle;

    void Awake()
    {
        //MainMenuGO = GameObject.Find("MainMenu");
        //OptionsMenuGO = GameObject.Find("OptionsMenu");
        //ExitMenuGO = GameObject.Find("ExitMenu");
        MainMenuActive();
    }


    private void Update()
    {
        
        if (optionsBool)
        {
            ScriptSoundManager.smInstance._musicSourse.volume = _soundSlider.value;

            if (!_soundToggle.isOn)
            {
                ScriptSoundManager.smInstance._musicSourse.volume = 0;
            }

            if (_godModeToggle.isOn)
            {
                ScriptGameManager.gmInstance.godMode = true;
            }
            else
            {
                ScriptGameManager.gmInstance.godMode = false;
            }
        }
    }

    public void MainMenuLoadScene()
    {
        SceneManager.LoadScene(0);
        MainMenuActive();
    }

    public void NewGameLoadScene()
    {
        SceneManager.LoadScene(1);
        ScriptGameManager.gmInstance.NewGame();
        ScriptSoundManager.PauseMusic();
    }

    public void MainMenuActive()
    {
        ScriptSoundManager.PlayMusic();
        mainMenuGO.SetActive(true);
        optionsMenuGO.SetActive(false);
        optionsBool = false;
        howToPlayMenuGO.SetActive(false);
        creditsMenuGO.SetActive(false);
        exitMenuGO.SetActive(false);
    }

    public void OptionsMenuActive()
    {
        mainMenuGO.SetActive(false);
        optionsMenuGO.SetActive(true);
        optionsBool = true;
        howToPlayMenuGO.SetActive(false);
        creditsMenuGO.SetActive(false);
        exitMenuGO.SetActive(false);
    }
    public void HowToPlayMenuActive()
    {
        mainMenuGO.SetActive(false);
        optionsMenuGO.SetActive(false);
        howToPlayMenuGO.SetActive(true);
        creditsMenuGO.SetActive(false);
        exitMenuGO.SetActive(false);
    }

    public void CreditsMenuActive()
    {
        mainMenuGO.SetActive(false);
        optionsMenuGO.SetActive(false);
        howToPlayMenuGO.SetActive(false);
        creditsMenuGO.SetActive(true);
        exitMenuGO.SetActive(false);
    }

    public void ExitMenuActive()
    {
        mainMenuGO.SetActive(false);
        optionsMenuGO.SetActive(false);
        howToPlayMenuGO.SetActive(false);
        creditsMenuGO.SetActive(false);
        exitMenuGO.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}