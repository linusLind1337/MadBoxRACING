using UnityEngine;

public class ActivateDeactivate : MonoBehaviour
{
    public GameObject targetObject;
    public float activationDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetObject != null)
            {
                targetObject.SetActive(true);

                Invoke("DeactivateTargetObject", activationDuration);
            }
            else
            {
                Debug.LogError("Assign GameObject!");
            }
        }
    }

    private void DeactivateTargetObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }
}
