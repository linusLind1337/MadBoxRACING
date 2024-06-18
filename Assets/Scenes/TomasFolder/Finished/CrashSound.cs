using UnityEngine;
using FMODUnity;

public class CrashSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string soundEvent;

    private bool hasEntered = false;

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
        RuntimeManager.PlayOneShot(soundEvent, transform.position);
    }
}
