//using UnityEngine;
//using UnityEngine.UI;
//using FMODUnity;
//using FMOD.Studio;

//public class AudioManager : MonoBehaviour
//{
//    public static AudioManager instance { get; private set; }

//    // Headers - visible in game
//    [Header("Volume")]
//    [Range(0, 1)]
//    public float masterVolume = 1;
//    [Range(0, 1)]
//    public float BGMVolume = 1;
//    [Range(0, 1)]
//    public float AnnouncerVolume = 1;
//    [Range(0, 1)]
//    public float AmbientSoundVolume = 1;
//    [Range(0, 1)]
//    public float SFXVolume = 1;

//    //Buses
//    private Bus masterBus;
//    private Bus ambientSoundBus;
//    private Bus bgmBus;
//    private Bus announcerBus;
//    private Bus sfxBus;

//    // UI sliders visible in inspector
//    public Slider masterVolumeSlider;
//    public Slider BGMVolumeSlider;
//    public Slider AnnouncerVolumeSlider;
//    public Slider AmbientSoundVolumeSlider;
//    public Slider SFXVolumeSlider;

//    private void Start()
//    {
//        if (instance != null)
//        {
//            Debug.LogError("Found more than one Audio Manager in the scene.");
//            Destroy(gameObject);
//            return;
//        }
//        instance = this;
//        DontDestroyOnLoad(gameObject);

//        masterBus = RuntimeManager.GetBus("bus:/");
//        bgmBus = RuntimeManager.GetBus("bus:/BGM");
//        sfxBus = RuntimeManager.GetBus("bus:/SFX");
//        ambientSoundBus = RuntimeManager.GetBus("bus:/AmbientSound");
//        announcerBus = RuntimeManager.GetBus("bus:/Announcer");

//        masterVolumeSlider.value = masterVolume;
//        BGMVolumeSlider.value = BGMVolume;
//        AnnouncerVolumeSlider.value = AnnouncerVolume;
//        AmbientSoundVolumeSlider.value = AmbientSoundVolume;
//        SFXVolumeSlider.value = SFXVolume;
//    }

//    public void PlayOneShot(EventReference sound, Vector3 worldPos)
//    {
//        RuntimeManager.PlayOneShot(sound, worldPos);
//    }

//    public void SetMasterVolume(float volume)
//    {
//        masterVolume = volume;
//        masterBus.setVolume(volume);
//    }

//    public void SetBGMVolume(float volume)
//    {
//        BGMVolume = volume;
//        bgmBus.setVolume(volume);
//    }

//    public void SetAnnouncerVolume(float volume)
//    {
//        AnnouncerVolume = volume;
//        announcerBus.setVolume(volume);
//    }

//    public void SetAmbientSoundVolume(float volume)
//    {
//        AmbientSoundVolume = volume;
//        ambientSoundBus.setVolume(volume);
//    }

//    public void SetSFXVolume(float volume)
//    {
//        SFXVolume = volume;
//        sfxBus.setVolume(volume);
//    }

//    private void Update()
//    {
//        masterBus.setVolume(masterVolume);
//    }
//}
