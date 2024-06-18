using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LoadVC : MonoBehaviour
{
    public Parts parts;
    public GameObject parent;
    public WeightSystem weightSystem;
    
    public GameObject empty;
    
    public List<GameObject> wheels;
    
    private Vector3[,] wheelpos =
    {
        {
            new Vector3(0.86f, 0.02f, 0.39f),
            new Vector3(-0.87f, 0.02f, 0.39f),
            new Vector3(-0.87f, 0.02f, -0.63f),
            new Vector3(0.86f, 0.02f, -0.63f)
        },
        {
            new Vector3(0.86f, 0.02f, 0.92f),
            new Vector3(-0.87f, 0.02f, 0.92f),
            new Vector3(-0.87f, 0.02f, -0.92f),
            new Vector3(0.86f, 0.02f, -0.92f)
        }
    };
    private int indexer;
    
    GameObject ViechleDrivetrain;
    GameObject ViechleBody;
    GameObject ViechleWheels;
    GameObject instantiated;
            
    GameObject CharacterBody;
    GameObject CharacterHead;

    public GameObject start;

    private void Awake()
    {
        load(start);
    }

    public void load(GameObject position)
    {
        parent = position;
        
        Chassie(parent);
        BaseFrame(ViechleBody);
        
        if (ViechleBody.transform.Find("WheelMeshes") != null)
        {
            Wheels(ViechleBody.transform.Find("WheelMeshes").gameObject);
        }
        else
        {
            Wheels(ViechleDrivetrain);
        }
        
        Costume(ViechleBody);
        Helmet(CharacterBody);

        //Seat();
        
        //ViechleWheels.transform.position = new Vector3(0, -0.9f, 1.84f);
        
        //character
        //CharacterBody.transform.Rotate(0,-90,0);
        
    }

    private void Chassie(GameObject parent)
    {
        if (parts.selectedViechleBody == null)
        {
            ViechleBody = Instantiate(parts.viechleBody[0], parent.transform);
        }
        else
        {
            ViechleBody = Instantiate(parts.selectedViechleBody, parent.transform);
        }
        
        //name & tag
        ViechleBody.name = "ViechleBody";
        //ViechleBody.tag = "Car";
    }
    private void BaseFrame(GameObject parent)
    {
        ViechleDrivetrain = Instantiate(parts.viechleDrivetrain[parts.selectedViechleDrivetrain], parent.transform);
        
        //position & rotation
        ViechleDrivetrain.transform.Rotate(0, 90,0);
        ViechleDrivetrain.gameObject.transform.localPosition = new Vector3(0.13f, -0.34f, 0);
        
        //name
        ViechleDrivetrain.name = "ViechleDrivetrain";
    }
    private void Wheels(GameObject parent)
    {
        if (parent.transform.GetChild(0) == null)
        {
            if (parts.selectedViechleWheel == null)
            {
                for (int i = 0; i < 4; i++)
                {
                    instantiated = Instantiate(parts.viechleWheel[0], parent.transform);
                    wheels.Add(instantiated);
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    instantiated = Instantiate(parts.selectedViechleWheel, parent.transform);
                    wheels.Add(instantiated);
                }
            }
        }
        else
        {
            if (parts.selectedViechleWheel == null)
            {
                instantiated = Instantiate(parts.viechleWheel[0], parent.transform.GetChild(0).transform);
                wheels.Add(instantiated);
                instantiated = Instantiate(parts.viechleWheel[0], parent.transform.GetChild(1).transform);
                wheels.Add(instantiated);
                instantiated = Instantiate(parts.viechleWheel[0], parent.transform.GetChild(2).transform);
                wheels.Add(instantiated);
                instantiated = Instantiate(parts.viechleWheel[0], parent.transform.GetChild(3).transform);
                wheels.Add(instantiated);
            }
            else
            {
                ViechleWheels = Instantiate(empty, ViechleDrivetrain.transform);
                instantiated = Instantiate(parts.selectedViechleWheel, parent.transform.GetChild(0).transform);
                wheels.Add(instantiated);
                instantiated = Instantiate(parts.selectedViechleWheel, parent.transform.GetChild(1).transform);
                wheels.Add(instantiated);
                instantiated = Instantiate(parts.selectedViechleWheel, parent.transform.GetChild(2).transform);
                wheels.Add(instantiated);
                instantiated = Instantiate(parts.selectedViechleWheel, parent.transform.GetChild(3).transform);
                wheels.Add(instantiated);
            }
        }
        
        //position
        if (parent.transform.GetChild(0) == null)
        {
            if (parts.selectedViechleDrivetrain == 0)
            {
                //wheels
                wheels[0].transform.position = wheelpos[1, 0];
                wheels[1].transform.position = wheelpos[1, 1];
                wheels[2].transform.position = wheelpos[1, 2];
                wheels[3].transform.position = wheelpos[1, 3];
            }
            else if (parts.selectedViechleDrivetrain == 1)
            {
                //wheels
                wheels[0].transform.position = wheelpos[0, 0];
                wheels[1].transform.position = wheelpos[0, 1];
                wheels[2].transform.position = wheelpos[0, 2];
                wheels[3].transform.position = wheelpos[0, 3];
            }
        }
        else
        {
            if (ViechleBody.transform.Find("Sardine Car") != null)
            {
                wheels[0].transform.localPosition += new Vector3(0, 0, 0.3f); 
                wheels[1].transform.localPosition -= new Vector3(0, 0, 0.3f); 
                wheels[2].transform.localPosition -= new Vector3(0, 0, 0.3f); 
                wheels[3].transform.localPosition += new Vector3(0, 0f, 0.3f);
            }
            else if (ViechleBody.transform.Find("DraculaCart") != null)
            {
                wheels[0].transform.localPosition += new Vector3(0, 0, 0.1f); 
                wheels[1].transform.localPosition -= new Vector3(0, 0, 0.1f); 
                wheels[2].transform.localPosition += new Vector3(0, 0, 0.1f); 
                wheels[3].transform.localPosition -= new Vector3(0, 0, 0.1f); 
            }

            //parent.transform.Find("WheelColliders").GetChild(0).transform.position = wheels[0].transform.localPosition;
            //parent.transform.Find("WheelColliders").GetChild(1).transform.position = wheels[1].transform.localPosition;
        }

        //clear wheel list
        wheels.Clear();
    }
    private void Seat()
    {
        if (parts.selectedSeatPosition == 0)
        {
            weightSystem.FrontSeat();
        }
        else if (parts.selectedSeatPosition == 1)
        {
            weightSystem.MiddleSeat();
        }
        else
        {
            weightSystem.BackSeat();
        }
    }

    private void Costume(GameObject parent)
    {
        if (parts.selectedCharacterBody == null)
        {
            CharacterBody = Instantiate(parts.characterBody[0], ViechleBody.transform);
        }
        else
        {
            CharacterBody = Instantiate(parts.selectedCharacterBody, ViechleBody.transform);
        }
        
        //position & rotation
        if (parts.selectedSeatPosition == 0)
        {
            CharacterBody.transform.position = ViechleBody.GetComponentInChildren<SeatPositions>().frontSeatPos.position;
        }
        else if (parts.selectedSeatPosition == 1)
        {
            CharacterBody.transform.position = ViechleBody.GetComponentInChildren<SeatPositions>().middleSeatPos.position;
        }
        else if (parts.selectedSeatPosition == 2)
        {
            CharacterBody.transform.position = ViechleBody.GetComponentInChildren<SeatPositions>().backSeatPos.position;
        }
        CharacterBody.transform.Rotate(0,-90,0);
        CharacterBody.transform.position += new Vector3(0, 0.5f, 0);
        
        //name
        CharacterBody.name = "CharacterBody";
    }
    private void Helmet(GameObject parent)
    {
        if (parts.selectedCharacterHead == null)
        {
            CharacterHead = Instantiate(parts.characterHead[0], CharacterBody.transform);
        }
        else
        {
            CharacterHead = Instantiate(parts.selectedCharacterHead, CharacterBody.transform);
        }
        
        //position
        CharacterHead.transform.localPosition += new Vector3(-0.23f, 0.3f, 2.31f);
        CharacterHead.transform.Rotate(0, 180, 0);
        //name
        CharacterHead.name = "CharacterHead";
    }
}
