using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public GameObject[] objectsToRandomize;

    void Start()
    {
        if (objectsToRandomize != null && objectsToRandomize.Length > 0)
        {
            int indexToActivate = Random.Range(0, objectsToRandomize.Length);

            for (int i = 0; i < objectsToRandomize.Length; i++)
            {
                objectsToRandomize[i].SetActive(i == indexToActivate);
            }
        }
        else
        {
            Debug.LogError("No GameObjects to randomize.");
        }
    }
}
