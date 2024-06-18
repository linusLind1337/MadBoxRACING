using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrakeButton : MonoBehaviour
{
    public CarInfo carInfo;

    public void SetBrakeTorque()
    {
        if (carInfo != null)
        {
            carInfo.currentBreakTorque = carInfo.breakTorque;
        }
    }

    public void ResetBrakeTorque()
    {
        if (carInfo != null)
        {
            carInfo.currentBreakTorque = 0;
        }
    }
}
