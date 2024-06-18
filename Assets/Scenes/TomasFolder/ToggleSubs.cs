using UnityEngine;

public class ToggleSubs : MonoBehaviour
{
    public GameObject[] objectsToToggle;

    public void ToggleVisibility()
    {
        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }
}
