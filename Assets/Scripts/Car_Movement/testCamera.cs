using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class testCamera : MonoBehaviour
{
    /* THIS WAS A TEST FOR CAMERA
    public Transform car; 
    public LayerMask groundLayer;
    public float distanceFromCar; 
    public float heightOffset;
    public float smoothTime;
    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
       
        Vector3 targetPosition = car.position - car.forward * distanceFromCar + Vector3.up * heightOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity ,Time.deltaTime * smoothTime);
        transform.LookAt(car);
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            Debug.DrawRay(transform.position, Vector3.down, Color.green);
            transform.position = hit.point + Vector3.up * heightOffset;
        }
       
        Vector3 carUp = car.up;
        if (Vector3.Dot(carUp, Vector3.up) < 0)
        {
            transform.rotation = Quaternion.LookRotation(transform.forward, -carUp);
        }
    }*/
}
