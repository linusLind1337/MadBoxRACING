using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaybaleChecker : MonoBehaviour
{
    [Header("References")]
    public LayerMask bales;
    public CarControl carControl;
    public CarInfo carInfo;
    public Transform currentWheelTransform;
    [Space(5)]
    
    [Header("Car wobble settings")]
    public float maxDist;
    public float duration;
    public float angle;
    public float frequency;
    
    private bool _iscurrentWheelTransformNull;

    private void Awake()
    {
        _iscurrentWheelTransformNull = currentWheelTransform == null;
    }

    private void Start()
    {
        carInfo.currentBreakTorque = 0;
    }
 
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right, out hit, maxDist, bales))
        {
            Debug.DrawRay(transform.position, transform.right * hit.distance, Color.green);
            if (hit.collider != null)
            {
                if (hit.distance < 0.5f)
                {
                    Debug.DrawRay(transform.position, transform.right * hit.distance, Color.red);
                    StartCoroutine(WobbleLeftFrontWheel());
                }
                else if (hit.distance > 0.5f)
                {
                    carInfo.currentBreakTorque = 0;
                }
            }
        }
    }
 
    private IEnumerator WobbleLeftFrontWheel()
    {
        if (_iscurrentWheelTransformNull)
        {
            yield break;
        }
        
        Quaternion originalRotation = currentWheelTransform.localRotation;
 
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float factor = Mathf.Sin(Time.time * frequency * Mathf.PI * 2f) * 0.5f + 0.5f;
            float wobbleAngle = angle * factor;
            Quaternion targetRotation = Quaternion.Euler(originalRotation.eulerAngles + new Vector3(0, -wobbleAngle, 0));
            currentWheelTransform.localRotation = targetRotation;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
 
        currentWheelTransform.localRotation = originalRotation;
    }
}
