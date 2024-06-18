using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public CarControl carControl;
    public Rigidbody rb;

    public WheelCollider FrontLeftWheelCol;
    public WheelCollider FrontRightWheelCol;
    public bool isGravityActivated;

    [Range(-50f, 50f)]public float gravity;
    public float airGravity;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (FrontLeftWheelCol.isGrounded && FrontRightWheelCol.isGrounded && !isGravityActivated)
        {
            Debug.Log("GROUNDED");
            activate();
        }
        else if(!FrontLeftWheelCol.isGrounded && FrontRightWheelCol.isGrounded && isGravityActivated)
        {
            Debug.Log("FLYYYYING");
            deactivated();
        }
    }

    void activate()
    {
        enableGravity();
        isGravityActivated = true;
    }

    void deactivated()
    {
        disableGravity();
        isGravityActivated = false;
    }
    
    void enableGravity()
    {
       // rb.AddForce(Physics.gravity * (rb.mass));
        Physics.gravity = new Vector3(0f, gravity, 0f);
        Debug.Log("Current gravity is: " +  Physics.gravity + rb.mass);
        Debug.Log("heaver gravity activated: ");
    }

    void disableGravity()
    {
        //make sure gravity is negative
        Physics.gravity = new Vector3(0f, airGravity, 0f);
        //Physics.gravity = new Vector3(0f, gravity, 0f);
        Debug.Log("Current gravity is: " +  Physics.gravity + rb.mass);
        Debug.Log("normal gravity activated: ");
    }
}
