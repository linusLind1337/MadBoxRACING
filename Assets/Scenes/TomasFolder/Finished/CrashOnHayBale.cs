using UnityEngine;
using FMODUnity;

public class CrashOnHayBale : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string crashEvent;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FMODUnity.RuntimeManager.PlayOneShot(crashEvent, transform.position);

            enabled = false;
            Debug.Log("Hit hay bale");
        }
    }
}
