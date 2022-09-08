using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessTest : MonoBehaviour
{
    public PostProcessVolume volume;
    private Bloom _bloom;
    private Vignette _vignette;

    void Start()
    {
        volume.profile.TryGetSettings(out _bloom);  //intenta chequear si esta activado el bloom
        volume.profile.TryGetSettings(out _vignette);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _bloom.intensity.value = 0;
            _vignette.intensity.value = 0;
        }
    }
}
