using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class KMHscript : MonoBehaviour 
{
    public CarInfo carInfo;
    public TMP_Text speedText;

    // Update is called once per frame
    void Update()
    {
        speedText.text = carInfo.currentAccelaration.ToString("F0") + " KM/H";
    }
}
