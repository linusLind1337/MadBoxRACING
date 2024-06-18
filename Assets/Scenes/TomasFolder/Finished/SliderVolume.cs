using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class SliderVolume : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string fmodEvent;

    private FMOD.Studio.EventInstance eventInstance;
    public Slider volumeSlider;

    void Start()
    {
        if (!string.IsNullOrEmpty(fmodEvent))
        {
            eventInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
            eventInstance.start();

            volumeSlider.value = 1.0f;
            SetVolume(1.0f);
        }
        else
        {
            Debug.LogError("FMOD Event path missing!");
        }

        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnDestroy()
    {
        volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
        eventInstance.release();
    }

    void OnVolumeChanged(float sliderValue)
    {
        SetVolume(sliderValue);
    }

    void SetVolume(float sliderValue)
    {

        float volume = sliderValue;

        eventInstance.setVolume(volume);
    }
}
