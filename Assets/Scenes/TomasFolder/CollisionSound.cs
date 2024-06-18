using UnityEngine;
using FMODUnity;

public class CollisionSound : MonoBehaviour
{
    [EventRef]
    public string collisionSoundEvent;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a specific tag (you can customize this)
        if (collision.gameObject.CompareTag("Barrier"))
        {
            // Play the FMOD sound when the collision occurs
            PlayCollisionSound();
        }
    }

    private void PlayCollisionSound()
    {
        // Ensure the FMOD event is set
        if (!string.IsNullOrEmpty(collisionSoundEvent))
        {
            // Play the FMOD event
            FMODUnity.RuntimeManager.PlayOneShot(collisionSoundEvent, transform.position);
        }
        else
        {
            Debug.LogWarning("FMOD event path is not set in the script.");
        }
    }
}
