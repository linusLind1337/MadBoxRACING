using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarControl : MonoBehaviour
{
    /// <summary>
    /// FYI The commented out code below is the gyro, yes i could have thrown it in it's own function.
    /// </summary>
    
    [Header("References to wheel collider")]
    public WheelCollider frontRight;
    public WheelCollider frontLeft;
    public WheelCollider backLeft;
    public WheelCollider backRight;
    [Space(5)]
    
    [Header("References to wheel transform/meshes")]
    public Transform frontRightTransform;
    public Transform frontLeftTransform;
    public Transform backLeftTransform;
    public Transform backRightTransform;
    
    [Header("Other references")]
    public CarInfo carInfo;
    public ObjFallOff objFallOff;

    [Header("Car Settings")]
    public float constantForce;
    [SerializeField]private float speed;
    [SerializeField] private float maxSpeedPropFallOff;
    private float _input;
    
    [SerializeField]private bool needsBoost;
    private Vector2 move;
    private Vector3 slopeDir;
    
    private InputActions inputs;
    private Rigidbody rb;
    //private Vector3 gyro;
    private void Start()
    {
        inputs = new InputActions();
        inputs.Enable();
        rb = GetComponent<Rigidbody>();
        //Input.gyro.enabled = false;
    }
    private void Update()
    {
        slopeDir = transform.forward;
        rb.AddForce(slopeDir * constantForce, ForceMode.Acceleration);
        
        needsBoost = rb.velocity.z <= 0 && (needsBoost = true);
        if (needsBoost)
            AddForceWhenStill();
    }

    private void FixedUpdate()
    { 
        //gyro = Input.gyro.rotationRateUnbiased;
        //float steerAngle = -gyro.z * carInfo.steeringMax;
        //frontLeft.steerAngle = steerAngle;
        //frontRight.steerAngle = steerAngle;
        
        move = inputs.Player.Steer.ReadValue<Vector2>();
        _input = move.x;

        measureSpeed();
        
        frontLeft.brakeTorque = carInfo.currentBreakTorque;
        frontRight.brakeTorque = carInfo.currentBreakTorque;
        backLeft.brakeTorque = carInfo.currentBreakTorque;
        backRight.brakeTorque = carInfo.currentBreakTorque;
        
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRight,  frontRightTransform);
        UpdateWheel(backLeft,  backLeftTransform);
        UpdateWheel(backRight, backRightTransform);
    }

    public void TurnLeft()
    {
        float steerAngle = carInfo.steeringMax;
        frontLeft.steerAngle = -steerAngle;
        frontRight.steerAngle = -steerAngle;
    }
    public void StopTurningLeft()
    {
        frontLeft.steerAngle = 0;
        frontRight.steerAngle = 0;
    }
    public void TurnRight()
    {
        float steerAngle = carInfo.steeringMax;
        frontLeft.steerAngle = steerAngle;
        frontRight.steerAngle = steerAngle;
    }
    public void StopTurningRight()
    {
        frontRight.steerAngle = 0;
        frontLeft.steerAngle = 0;
    }
    public void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        col.GetWorldPose(out pos, out rot);

        trans.position = pos;
        trans.rotation = rot * Quaternion.Euler(0f, 90f, 0f);
    }
    public void AddForceWhenStill()
    {
        rb.AddForce(transform.forward * 10, ForceMode.Force);
    }

    public void measureSpeed()
    {
        speed = carInfo.currentAccelaration;
        carInfo.currentAccelaration = rb.velocity.magnitude;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("HayBale"))
        {
            if (speed >= maxSpeedPropFallOff)
            {
                objFallOff.randomObjFallOff();
                if (objFallOff.objFall.transform.parent == null)
                {
                    StartCoroutine(destoyProps());
                }
            }
        }
    }
    IEnumerator destoyProps()
    {
        yield return new WaitForSeconds(4f);
        Destroy(objFallOff.objFall.gameObject);
    }
}
