using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI textObject;

    void Start()
    {
        if (textObject != null)
        {
            RectTransform rectTransform = textObject.GetComponent<RectTransform>();
            rectTransform.position = new Vector3(Screen.width / 2f, Screen.height / 8f, 0f);
        }
        else
        {
            Debug.LogError("TextMeshProUGUI object is not assigned in the inspector.");
        }
    }
}
