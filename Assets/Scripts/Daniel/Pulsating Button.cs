
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class PulsatingButton : MonoBehaviour
{
    public Button Puls;
    public float size;
    public float speed;
    private Vector3 sizeDif;
    private Vector3 originalSize;
    private bool posetive;
    
    private void Start()
    {
        originalSize = Puls.transform.localScale;
        sizeDif = Puls.transform.localScale + new Vector3(size, size);
    }

    void FixedUpdate()
    {
        if (Puls.transform.localScale.x >= sizeDif.x)
        {
            posetive = false;
        }
        else if (Puls.transform.localScale.x <= originalSize.x)
        {
            posetive = true;
        }

        if (posetive)
        {
            Puls.transform.localScale += new Vector3(speed * Time.fixedDeltaTime, speed * Time.fixedDeltaTime);
        }
        else
        {
            Puls.transform.localScale -= new Vector3(speed * Time.fixedDeltaTime, speed * Time.fixedDeltaTime);
        }
    }
}
