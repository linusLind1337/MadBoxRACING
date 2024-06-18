using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetCar : MonoBehaviour
{
    public GameObject car;
    public Rigidbody carRb;
    private bool spinIcon;
    private float spinIncrement = 1f;
    [SerializeField] private float spinSpeed;

    private Transform originalRotation;
    [SerializeField] private Image icon;

    [SerializeField] private Transform[] resetPoints;
    [SerializeField] private int resetPointsIndex;
    [SerializeField] private GameActionInt updateResetPoints;
    [SerializeField] private GameActionVoid actionVoidCarOutOfBounds;



    private void Start()
    {
        carRb = car.GetComponent<Rigidbody>();
        originalRotation = transform.transform;
    }

    private void OnEnable()
    {
        updateResetPoints.callActionInt += NewResetPoint;
        actionVoidCarOutOfBounds.callActionVoid += CarOutOfBounds;

    }

    private void OnDisable()
    {
        updateResetPoints.callActionInt -= NewResetPoint;
        actionVoidCarOutOfBounds.callActionVoid -= CarOutOfBounds;

    }
    
    private void FixedUpdate()
    {
        if (spinIcon)
        {
            icon.transform.Rotate(0, 0, spinIncrement);
        }

        spinIncrement = -spinSpeed * Time.fixedDeltaTime;
        
    }

    //Updates what reset should be used when the player clicks the reset button
    private void NewResetPoint(int index)
    {
        resetPointsIndex = index;
    }

    //Sets the cars transform to be one of the reset transforms on the map
    public void ResetCarToCurrentResetPoint()
    {
        car.transform.position = resetPoints[resetPointsIndex].transform.position;
        car.transform.rotation = resetPoints[resetPointsIndex].transform.rotation;
        carRb.velocity = new Vector3(0, 0, 0);
        carRb.constraints = RigidbodyConstraints.FreezeAll;
        carRb.constraints = RigidbodyConstraints.None;
        spinIcon = false;
        spinIncrement = 0;
        icon.transform.rotation = originalRotation.rotation;
    }
    
    //If the player goes out of bounds, the car will freeze and the reset button icon will spin
    private void CarOutOfBounds()
    {
        carRb.constraints = RigidbodyConstraints.FreezeAll;
        spinIcon = true;
        spinIncrement = 0;
    }
    
}
