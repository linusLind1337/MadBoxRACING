using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjFallOff : MonoBehaviour
{
    [Header("Prop objects reference")]
    public GameObject[] Props;
    public GameObject objFall;
    
    private Rigidbody rb;
    private float forceAmount;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void randomObjFallOff()
    {
        int randIndex = Random.Range(0, Props.Length);
        objFall = Props[randIndex];
        
        rb = objFall.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        objFall.transform.parent = null;
            
        Vector3 rand = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), Random.Range(-4f, 4f)) * Time.deltaTime;
        rb.AddForce(rand * forceAmount * Time.deltaTime, ForceMode.Impulse);
    }
}
