using UnityEngine;
using FMODUnity;

public class AnnouncerStart : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string fmodEvent;

    private FMOD.Studio.EventInstance eventInstance;

    void Start()
    {
        // Invoke the StartDelayedSound method after a delay of 3 seconds
        Invoke("StartDelayedSound", 3f);
    }

    void StartDelayedSound()
    {
        // Create an instance of the FMOD event
        eventInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);

        // Start playing the FMOD event
        eventInstance.start();
    }

    void OnDestroy()
    {
        // Release the FMOD event instance when the GameObject is destroyed
        eventInstance.release();
    }
}
