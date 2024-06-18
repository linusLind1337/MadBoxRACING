using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
    public GameObject car;

    private void Start()
    {
        if (car == null)
        {
            car = GameObject.Find("ViechleBody");
        }
    }

    void Update()
    {
        transform.LookAt(car.transform);
    }
}
