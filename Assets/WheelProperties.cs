using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelProperties : MonoBehaviour
{
    public CarControl carcontrol;
    WheelFrictionCurve myWfc;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //use at own risk, we are not respsonibly for any errors
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
           
            myWfc = carcontrol.frontLeft.sidewaysFriction;
            myWfc = carcontrol.frontRight.sidewaysFriction;
            myWfc = carcontrol.backRight.sidewaysFriction;
            myWfc = carcontrol.backLeft.sidewaysFriction;
            myWfc.extremumSlip = 0.07f;
            myWfc.asymptoteSlip = 0.07f;
            
            carcontrol.frontLeft.sidewaysFriction = myWfc;
            carcontrol.frontRight.sidewaysFriction = myWfc;
            carcontrol.backRight.sidewaysFriction = myWfc;
            carcontrol.backLeft.sidewaysFriction = myWfc;

            myWfc = carcontrol.frontLeft.forwardFriction;
            myWfc = carcontrol.frontRight.forwardFriction;
            myWfc = carcontrol.backRight.forwardFriction;
            myWfc = carcontrol.backLeft.forwardFriction;
            myWfc.extremumSlip = 0.07f;
            myWfc.asymptoteSlip = 0.07f;
            
            carcontrol.frontLeft.forwardFriction = myWfc;
            carcontrol.frontRight.forwardFriction = myWfc;
            carcontrol.backRight.forwardFriction = myWfc;
            carcontrol.backLeft.forwardFriction = myWfc;
 
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            myWfc = carcontrol.frontLeft.sidewaysFriction;
            myWfc = carcontrol.frontRight.sidewaysFriction;
            myWfc = carcontrol.backRight.sidewaysFriction;
            myWfc = carcontrol.backLeft.sidewaysFriction;
            myWfc.extremumSlip = 0.2f;
            myWfc.asymptoteSlip = 0.8f;
            
            carcontrol.frontLeft.sidewaysFriction = myWfc;
            carcontrol.frontRight.sidewaysFriction = myWfc;
            carcontrol.backRight.sidewaysFriction = myWfc;
            carcontrol.backLeft.sidewaysFriction = myWfc;

            myWfc = carcontrol.frontLeft.forwardFriction;
            myWfc = carcontrol.frontRight.forwardFriction;
            myWfc = carcontrol.backRight.forwardFriction;
            myWfc = carcontrol.backLeft.forwardFriction;
            myWfc.extremumSlip = 0.4f;
            myWfc.asymptoteSlip = 0.8f;
            
            carcontrol.frontLeft.forwardFriction = myWfc;
            carcontrol.frontRight.forwardFriction = myWfc;
            carcontrol.backRight.forwardFriction = myWfc;
            carcontrol.backLeft.forwardFriction = myWfc;
        }
        

    }

}
