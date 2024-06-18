using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Breaker : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 0, 7000));
    }

    private void FixedUpdate()
    {
        Vector3 tempVector = new Vector3(0, 0, 1);
        tempVector = tempVector.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + tempVector);
    }
}
