using UnityEngine;

public class PathChooser : MonoBehaviour
{
    public GameObject objectToEnable;
    public GameObject objectToDisable;

    void OnEnable()
    {
        SetObjectStates();
    }

    public void ToggleObjects()
    {
        bool tempState = objectToEnable.activeSelf;
        objectToEnable.SetActive(!objectToEnable.activeSelf);
        objectToDisable.SetActive(!tempState);
    }

    private void SetObjectStates()
    {
        if (objectToEnable != null)
            objectToEnable.SetActive(true);

        if (objectToDisable != null)
            objectToDisable.SetActive(false);
    }
}
