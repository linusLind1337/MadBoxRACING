using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class SFXVolume : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string[] fmodEvents;

    private FMOD.Studio.EventInstance[] eventInstances;
    public Slider volumeSlider;

    void Start()
    {
        eventInstances = new FMOD.Studio.EventInstance[fmodEvents.Length];

        for (int i = 0; i < fmodEvents.Length; i++)
        {
            if (!string.IsNullOrEmpty(fmodEvents[i]))
            {
                eventInstances[i] = FMODUnity.RuntimeManager.CreateInstance(fmodEvents[i]);
            }
            else
            {
                Debug.LogError("FMOD Event missing " + i + "!");
            }
        }

        volumeSlider.value = 1.0f;
        SetVolume(1.0f);

        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnDestroy()
    {
        foreach (var eventInstance in eventInstances)
        {
            eventInstance.release();
        }

        volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float sliderValue)
    {
        SetVolume(sliderValue);
    }

    void SetVolume(float sliderValue)
    {
        foreach (var eventInstance in eventInstances)
        {
            eventInstance.setVolume(sliderValue);
        }
    }
}
