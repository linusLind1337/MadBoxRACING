using UnityEngine;
using FMODUnity;

public class WinSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string soundEvent;

    private bool hasEntered = false;
    private FMODUnity.StudioEventEmitter eventEmitter;

    private void Start()
    {
        // Get the StudioEventEmitter component attached to the GameObject
        eventEmitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasEntered)
        {
            PlaySound();
            hasEntered = true;
        }
    }

    private void PlaySound()
    {
        // Ensure the FMOD event is set
        if (!string.IsNullOrEmpty(soundEvent))
        {
            // Set the FMOD event for the StudioEventEmitter
            eventEmitter.Event = soundEvent;

            // Play the FMOD event
            eventEmitter.Play();
        }
        else
        {
            Debug.LogWarning("FMOD event path is not set in the script.");
        }
    }
}
