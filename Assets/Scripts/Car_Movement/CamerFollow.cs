using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class CamerFollow : MonoBehaviour
{
    
    [Header("Camera Settings")]
    [Tooltip("Speed is the speed for the camera to catch up to the cameraTransform")]
    public float speed;
    [Tooltip("cameraGroundDistance is how far the distance should be from the camera to detect the ground and stay at that value")]
    public float cameraGroundDistance;
    public Vector3 distance;

    [Space(5)] [Header("References / layers")]
    [SerializeField]private Transform car;
    public Transform cameraTransform;
    public Transform lookAtTarget;
    public LayerMask groundLayer;

    private void Start()
    {
        if (car == null)
        {
            car = GameObject.FindGameObjectWithTag("Car").transform;
            if (car == null)
            {
                Debug.Log("NO CAR FOUND");
                return;
            }
        }

        cameraTransform = car.transform.Find("cameraTarget");
        lookAtTarget = car.transform.Find("lookAtTarget");
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = cameraTransform.position + distance;
        Vector3 setPosition = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);
        transform.position = setPosition;
        transform.LookAt(lookAtTarget.position);
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            Debug.DrawRay(transform.position, Vector3.down * cameraGroundDistance, Color.green);
            transform.position = hit.point + Vector3.up * cameraGroundDistance;
        }
    }
}
