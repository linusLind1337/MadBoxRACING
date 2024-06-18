using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoadCar : MonoBehaviour
{
    public LevelManager levelManager;
    public ResetCar resetCar;
    public Button left;
    public Button right;
    public Button brake;
    public GameObject car;
    public BrakeButton brakeButtonCar;
    public CarControl carControls;

    public void Start()
    {
        levelManager = this.gameObject.GetComponent<LevelManager>();
        resetCar = this.gameObject.GetComponent<ResetCar>();
        car = GameObject.Find("ViechleBody");
        brakeButtonCar = car.GetComponent<BrakeButton>();
        carControls = car.GetComponent<CarControl>();



        MapCarControls();

        resetCar.car = car;
        resetCar.carRb = car.GetComponent<Rigidbody>();
        levelManager.rbCar = car.GetComponent<Rigidbody>();


    }

    private void MapCarControls()
    {
        //Add left turn
        EventTrigger triggerLeft = left.AddComponent<EventTrigger>();
        var pointerDownLeft = new EventTrigger.Entry();
        pointerDownLeft.eventID = EventTriggerType.PointerDown;
        pointerDownLeft.callback.AddListener(e => carControls.TurnLeft());
        var pointerUp = new EventTrigger.Entry();
        pointerUp.eventID = EventTriggerType.PointerUp;
        pointerUp.callback.AddListener(e =>carControls.StopTurningLeft());
        triggerLeft.triggers.Add(pointerDownLeft);
        triggerLeft.triggers.Add(pointerUp);

        //Add right turn
        EventTrigger triggerRight = right.AddComponent<EventTrigger>();
        var pointerDownRight = new EventTrigger.Entry();
        pointerDownRight.eventID = EventTriggerType.PointerDown;
        pointerDownRight.callback.AddListener(e => carControls.TurnRight());
        var pointerUpRight = new EventTrigger.Entry();
        pointerUpRight.eventID = EventTriggerType.PointerUp;
        pointerUpRight.callback.AddListener(e => carControls.StopTurningRight());
        triggerRight.triggers.Add(pointerDownRight);
        triggerRight.triggers.Add(pointerUpRight);

        //Add brake
        EventTrigger triggerBrake = brake.AddComponent<EventTrigger>();
        var brakeDown = new EventTrigger.Entry();
        brakeDown.eventID = EventTriggerType.PointerDown;
        brakeDown.callback.AddListener(e => brakeButtonCar.SetBrakeTorque());
        var brakeUp = new EventTrigger.Entry();
        brakeUp.eventID = EventTriggerType.PointerUp;
        brakeUp.callback.AddListener(e => brakeButtonCar.ResetBrakeTorque());
        triggerBrake.triggers.Add(brakeDown);
        triggerBrake.triggers.Add(brakeUp);
    }

}
