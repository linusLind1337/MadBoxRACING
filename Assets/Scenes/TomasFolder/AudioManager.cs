using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    [Header("Volume")]
    [Range(0, 1)] public float masterVolume = 1;
    [Range(0, 1)] public float BGMVolume = 1;
    [Range(0, 1)] public float AnnouncerVolume = 1;
    [Range(0, 1)] public float AmbientSoundVolume = 1;
    [Range(0, 1)] public float SFXVolume = 1;

    private Bus masterBus;
    private Bus ambientSoundBus;
    private Bus bgmBus;
    private Bus announcerBus;
    private Bus sfxBus;

    private float lastNonMutedMasterVolume; // save master volume before pausing
    private float previousAmbientVolume;
    private float previousSFXVolume;

    public Slider masterVolumeSlider;
    public Slider BGMVolumeSlider;
    public Slider AnnouncerVolumeSlider;
    public Slider AmbientSoundVolumeSlider;
    public Slider SFXVolumeSlider;

    private bool isGamePaused = false;

    private void Start()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        masterBus = RuntimeManager.GetBus("bus:/");
        bgmBus = RuntimeManager.GetBus("bus:/BGM");
        sfxBus = RuntimeManager.GetBus("bus:/SFX");
        ambientSoundBus = RuntimeManager.GetBus("bus:/AmbientSound");
        announcerBus = RuntimeManager.GetBus("bus:/Announcer");

        // Set initial volumes
        SetMasterVolume(masterVolume);
        SetBGMVolume(BGMVolume);
        SetAnnouncerVolume(AnnouncerVolume);
        SetAmbientSoundVolume(AmbientSoundVolume);
        SetSFXVolume(SFXVolume);
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        if (!isGamePaused)
            RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        masterBus.setVolume(volume);
        masterVolumeSlider.value = volume;
    }

    public void SetBGMVolume(float volume)
    {
        BGMVolume = volume;
        bgmBus.setVolume(volume);
        BGMVolumeSlider.value = volume;
    }

    public void SetAnnouncerVolume(float volume)
    {
        AnnouncerVolume = volume;
        announcerBus.setVolume(volume);
        AnnouncerVolumeSlider.value = volume;
    }

    public void SetAmbientSoundVolume(float volume)
    {
        AmbientSoundVolume = volume;
        ambientSoundBus.setVolume(volume);
        AmbientSoundVolumeSlider.value = volume;
    }

    public void SetSFXVolume(float volume)
    {
        SFXVolume = volume;
        sfxBus.setVolume(volume);
        SFXVolumeSlider.value = volume;
    }

    public void ToggleSoundMute()
    {
        if (isGamePaused)
            return; // Don't allow muting when game is paused

        isGamePaused = true;
        lastNonMutedMasterVolume = masterVolumeSlider.value; // SAVE sound before going to pause
        SetMasterVolume(0); // Mute all sounds [WHEN PAUSED]
    }

    public void UnpauseGame()
    {
        if (!isGamePaused)
            return;

        isGamePaused = false;
        SetMasterVolume(lastNonMutedMasterVolume); // RESTORE last saved sound
    }

    public void LowerVolumeInTrigger(float volume)
    {
        // Store previous volumes before lowering
        previousAmbientVolume = AmbientSoundVolume;
        previousSFXVolume = SFXVolume;

        SetAmbientSoundVolume(volume);
        SetSFXVolume(volume);
    }

    public void RestorePreviousVolumes()
    {
        // Restore previous volumes
        SetAmbientSoundVolume(previousAmbientVolume);
        SetSFXVolume(previousSFXVolume);
    }
}
