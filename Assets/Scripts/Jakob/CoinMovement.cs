using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    private float y;
    private float newY;
    private float spinStep;
    [SerializeField] private float bounceSize;
    [SerializeField] private float bounceSpeed;
    [SerializeField] private float spinSpeed;
    private void Start()
    {
        newY = transform.position.y;
    }

    private void Update()
    {
        float newY2 = newY +  Mathf.PingPong(Time.time * bounceSpeed, 1) * bounceSize;
        this.transform.position = new Vector3(transform.position.x, newY2, transform.position.z);
        transform.Rotate(new Vector3(0,spinStep,0));
        spinStep = spinSpeed * Time.deltaTime;
    }
}
