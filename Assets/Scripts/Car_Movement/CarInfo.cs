using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CarInfo", menuName = "CarInfo", order = 1)]
public class CarInfo : ScriptableObject
{
   public float acceleration;
   public float carMaxSpeed;

   public float breakTorque;

   public float steeringMax;
   public float steerRangeMaxSpeed;

   public float centerMassOffset;
   public float currentAccelaration;
   public float currentBreakTorque;
   public float currentSteeringAngle;
}
