using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class ButtonOneShotFMOD : MonoBehaviour
{
    public StudioEventEmitter eventEmitter;

    void Start()
    {
        eventEmitter = GetComponent<StudioEventEmitter>();

        GetComponent<Button>().onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        eventEmitter.Play();
    }
}
