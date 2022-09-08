using UnityEngine;

public class ScriptSoundManager : MonoBehaviour
{
    public static ScriptSoundManager smInstance;
    public AudioSource _musicSourse; //, _effectsSource;

    void Awake()
    {
        if (ScriptSoundManager.smInstance == null)
        {
            ScriptSoundManager.smInstance = this;
            DontDestroyOnLoad(this);
            _musicSourse = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void PlayMusic()
    {
        smInstance._musicSourse.UnPause();
    }
    public static void PauseMusic()
    {
        smInstance._musicSourse.Pause();
    }
}

