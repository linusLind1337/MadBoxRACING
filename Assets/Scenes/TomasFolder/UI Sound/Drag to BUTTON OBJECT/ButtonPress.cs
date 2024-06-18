using UnityEngine;
using FMODUnity;

public class ButtonPress : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string oneShotEventPath;

    public void OnButtonPressed()
    {

        if (!string.IsNullOrEmpty(oneShotEventPath))
        {
            RuntimeManager.PlayOneShot(oneShotEventPath, transform.position);
        }
        else
        {
            Debug.LogError("One-shot event path is not assigned!");
        }
    }
}
