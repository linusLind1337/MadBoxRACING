using System.Collections;
using System.Collections.Generic;
using GhostSystem;
using UnityEngine;

public class WeightSystem : MonoBehaviour
{
    private Rigidbody rb;
    private float weightToAdd;

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
            Debug.Log("No rb found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Remove later on!!!
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FrontSeat();
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MiddleSeat();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
           BackSeat();
        }
    }

    public void FrontSeat()
    {
        rb.centerOfMass = new Vector3(0f, 0f, 0.5f);
        rb.mass = 3000f;
        Debug.Log("player in front, New center of mass: " + rb.centerOfMass);
    }

    public void MiddleSeat()
    {
        rb.centerOfMass = new Vector3(0f, 0f, 0);
        rb.mass = 2500f;
        Debug.Log("player in middle, New center of mass: " + rb.centerOfMass);
    }

    public void BackSeat()
    {
        rb.centerOfMass = new Vector3(0f, 0f, -0.5f);
        rb.mass = 3000f;
        Debug.Log("player in back, New center of mass: " + rb.centerOfMass);
    }
    
    public void addWeight()
    {
        if (rb != null)
        {
            rb.mass += weightToAdd;
            Debug.Log("New added weight is: " + rb.mass);
        }
    }

    public void removeWeight()
    {
        if (rb != null && rb.mass > 0)
        {
        rb.mass = Mathf.Max(0f, rb.mass - weightToAdd);
        Debug.Log("New removed weight is: " + rb.mass);
        }
    }
}
