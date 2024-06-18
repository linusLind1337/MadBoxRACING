using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HayBale : MonoBehaviour
{
    [Header("Settings")]
    public float forceAmount;
    public float downForce;
    
    private Vector3 orginalPos;
    private Quaternion originalRot;
    private Rigidbody rb;
    private Vector3 force;

    private bool isCreated;
    
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        orginalPos = transform.position;
        originalRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        
        //rb.detectCollisions = false;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            Debug.Log("player hit");
            force = transform.right;
            rb.isKinematic = false;
            rb.detectCollisions = true;
            rb.AddForce(force * forceAmount * Time.deltaTime , ForceMode.Impulse);
            rb.AddForce(-transform.up * downForce, ForceMode.Impulse);
            if (!isCreated)
            {
                ps = Instantiate(ps, transform.position, transform.rotation);
                ps.Play();
                isCreated = true;
            }
            
            ResetPosAfterDelayTimer();
        }
    }

    void ResetPosAfterDelayTimer()
    {
        StartCoroutine(ResetBalePosition());
    }

    IEnumerator ResetBalePosition()
    {
        yield return new WaitForSeconds(4f);
        isCreated = false;
        ps.gameObject.SetActive(false);
        resetPos();
        rb.isKinematic = true;
        rb.detectCollisions = false;
    }

    void resetPos()
    {
        transform.position = orginalPos;
        transform.rotation = originalRot;
    }
}
