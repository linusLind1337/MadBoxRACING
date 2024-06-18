using UnityEngine;
using UnityEngine.UI;

public class ActivateTMPButton : MonoBehaviour
{
    public GameObject objectToActivate;
    public float activationDuration = 2f;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ActivateObject);
    }

    void ActivateObject()
    {
        objectToActivate.SetActive(true);

        Invoke("DeactivateObject", activationDuration);
    }

    void DeactivateObject()
    {
        objectToActivate.SetActive(false);
    }
}
