using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VCEditor : MonoBehaviour
{
    public Parts parts;
    //public GameObject visualSeatPosition;
    public int partIndex = 0;
    public int partList = 0;        //partlist 0-3 = veichle, 4-5 = character
    public GameObject instantiated;
    public GameObject parent;
    private GameObject seat;
    public SeatPositions seatPositions;
    public List<GameObject> GameObjects;
    public List<GameObject> previewObjects;
    Vector3[,] wheelpos =
    {
        {
            new Vector3(0.86f, -0.3f, 0.39f),
            new Vector3(-0.87f, -0.3f, 0.39f),
            new Vector3(-0.87f, -0.3f, -0.63f),
            new Vector3(0.86f, -0.3f, -0.63f)
        },
        {
            new Vector3(0.86f, -0.3f, 0.92f),
            new Vector3(-0.87f, -0.3f, 0.92f),
            new Vector3(-0.87f, -0.3f, -0.92f),
            new Vector3(0.86f, -0.3f, -0.92f)
        }
    };
    
    private void Start()
    {
        //Preview();
        dracula();
    }
    public void PartList(int index)
    {
        partList = index;
        Delete();
        Preview();
    }
    
    public void NextPart()
    {
        Delete(GameObjects);
        partIndex++;
        //body
        if (partList == 0)
        {
            if (partIndex > parts.viechleBody.Count - 1)
            {
                partIndex = 0;
            }
        }
        //baseframe
        else if (partList == 1)
        {
            if (partIndex > parts.viechleDrivetrain.Count - 1)
            {
                partIndex = 0;
            }
        }
        //wheels
        else if (partList == 2)
        {
            if (partIndex > parts.viechleWheel.Count - 1)
            {
                partIndex = 0;
            }
        }
        //seat
        else if (partList == 3)
        {
            if (partIndex > 2)
            {
                partIndex = 0;
            }
        }
        //costume
        else if (partList == 4)
        {
            if (partIndex > parts.characterBody.Count - 1)
            {
                partIndex = 0;
            }
        }
        //head
        else if (partList == 5)
        {
            if (partIndex > parts.characterHead.Count - 1)
            {
                partIndex = 0;
            }
        }
        Preview();
    }
    public void PrevuesPart()
    {
        Delete(GameObjects);
        partIndex--;
        if (partIndex < 0)
        {
            if (partList == 0)
            {
                partIndex = parts.viechleBody.Count - 1;
            
            }
            else if (partList == 1)
            {
                partIndex = parts.viechleDrivetrain.Count - 1;;
            }
            else if (partList == 2)
            {
                partIndex = parts.viechleWheel.Count - 1;;
            }
            else if (partList == 3)
            {
                partIndex = 0;
            }
            else if (partList == 4)
            {
                partIndex = parts.characterBody.Count - 1;;
            }
            else if (partList == 5)
            {
                partIndex = parts.characterHead.Count - 1;;
            }
        }
        Preview();
    }

    public void Preview()
    {
        Delete(previewObjects);
        if (partList == 0)
        {
            Chassie(GameObjects, false);
            BaseFrame(previewObjects, true);
            Wheels(previewObjects, true);
            Seat(previewObjects, true);
        }
        else if (partList == 1)
        {
            Chassie(previewObjects, true);
            BaseFrame(GameObjects, false);
            Wheels(previewObjects, true);
            Seat(previewObjects, true);
        }
        else if (partList == 2)
        {
            Chassie(previewObjects, true);
            BaseFrame(previewObjects, true);
            Wheels(GameObjects, false);
            Seat(previewObjects, true);
        }
        else if (partList == 3)
        {
            Chassie(previewObjects, true);
            BaseFrame(previewObjects, true);
            Wheels(previewObjects, true);
            Seat(GameObjects, false);
        }
        else if (partList == 4)
        {
            Costume(GameObjects, false);
            Helmet(previewObjects, true);
        }
        else if (partList == 5)
        {
            Costume(previewObjects, true);
            Helmet(GameObjects, false);
        }
    }
    public void Delete(List<GameObject> list)
    {
        foreach (GameObject Object in list)
        {
            Destroy(Object);
        }
        list.Clear();
    }
    public void Delete()
    {
        foreach (GameObject Object in GameObjects)
        {
            Destroy(Object);
        }
        GameObjects.Clear();
        foreach (GameObject Object in previewObjects)
        {
            Destroy(Object);
        }
        previewObjects.Clear();
    }
    
    public void Select()
    {
        if (partList == 0)
        {
            parts.selectedViechleBody = parts.viechleBody[partIndex];
        }
        else if (partList == 1)
        {
            parts.selectedViechleDrivetrain = partIndex;
        }
        else if (partList == 2)
        {
            parts.selectedViechleWheel = parts.viechleWheel[partIndex];
        }
        else if (partList == 3)
        {
            parts.selectedSeatPosition = partIndex;
        }
        else if (partList == 4)
        {
            parts.selectedCharacterBody = parts.characterBody[partIndex];
        }
        else if (partList == 5)
        {
            parts.selectedCharacterHead = parts.characterHead[partIndex];
        }
    }

    private void Chassie(List<GameObject> list, bool selected)
    {
        if (selected)
        {
            parent = Instantiate(parts.selectedViechleBody);
        }
        else
        {
            parent = Instantiate(parts.viechleBody[partIndex]);
        }
        
        //position & rotarion
        //parent.transform.position = new Vector3(0, 0.35f, -0.11f);
        parent.transform.Rotate(0,90,0);
        list.Add(parent);
    }
    private void BaseFrame(List<GameObject> list, bool selected)
    {
        if (selected)
        {
            instantiated = Instantiate(parts.viechleDrivetrain[parts.selectedViechleDrivetrain], parent.transform);
        }
        else
        {
            instantiated = Instantiate(parts.viechleDrivetrain[partIndex], parent.transform);
        }
        list.Add(instantiated);
        
        //position & rotarion
        instantiated.gameObject.transform.position = new Vector3(0, -0.34f, -0.13f);
        instantiated.transform.Rotate(0,90,0);
    }
    private void Wheels(List<GameObject> list, bool selected)
    {
        if (selected)
        {
            if (parts.selectedViechleDrivetrain == 0)
            {
                instantiated = Instantiate(parts.selectedViechleWheel, parent.transform);
                instantiated.transform.position = wheelpos[0, 0];
                instantiated.transform.Rotate(0,90,0);
                list.Add(instantiated);
                instantiated = Instantiate(parts.selectedViechleWheel, parent.transform);
                instantiated.transform.position = wheelpos[0, 1];
                instantiated.transform.Rotate(0,90,0);
                list.Add(instantiated);
                instantiated = Instantiate(parts.selectedViechleWheel, parent.transform);
                instantiated.transform.position = wheelpos[0, 2];
                instantiated.transform.Rotate(0,90,0);
                list.Add(instantiated);
                instantiated = Instantiate(parts.selectedViechleWheel, parent.transform);
                instantiated.transform.position = wheelpos[0, 3];
                instantiated.transform.Rotate(0,90,0);
                list.Add(instantiated);
            }
            else if (parts.selectedViechleDrivetrain == 1)
            {
                instantiated = Instantiate(parts.selectedViechleWheel, parent.transform);
                instantiated.transform.position = wheelpos[1, 0];
                instantiated.transform.Rotate(0,90,0);
                list.Add(instantiated);
                instantiated = Instantiate(parts.selectedViechleWheel, parent.transform);
                instantiated.transform.position = wheelpos[1, 1];
                instantiated.transform.Rotate(0,90,0);
                list.Add(instantiated);
                instantiated = Instantiate(parts.selectedViechleWheel, parent.transform);
                instantiated.transform.position = wheelpos[1, 2];
                instantiated.transform.Rotate(0,90,0);
                list.Add(instantiated);
                instantiated = Instantiate(parts.selectedViechleWheel, parent.transform);
                instantiated.transform.position = wheelpos[1, 3];
                instantiated.transform.Rotate(0,90,0);
                list.Add(instantiated);
            }
        }
        else
        {
            if (parts.selectedViechleDrivetrain == 0)
            {
                instantiated = Instantiate(parts.viechleWheel[partIndex], parent.transform);
                instantiated.transform.position = wheelpos[0, 0];
                instantiated.transform.Rotate(0,90,0);
                list.Add(instantiated);
                instantiated = Instantiate(parts.viechleWheel[partIndex], parent.transform);
                instantiated.transform.position = wheelpos[0, 1];
                instantiated.transform.Rotate(0,90,0);
                list.Add(instantiated);
                instantiated = Instantiate(parts.viechleWheel[partIndex], parent.transform);
                instantiated.transform.position = wheelpos[0, 2];
                instantiated.transform.Rotate(0,90,0);
                list.Add(instantiated);
                instantiated = Instantiate(parts.viechleWheel[partIndex], parent.transform);
                instantiated.transform.position = wheelpos[0, 3];
                instantiated.transform.Rotate(0,90,0);
                list.Add(instantiated);
            }
            else if (parts.selectedViechleDrivetrain == 1)
            {
                instantiated = Instantiate(parts.viechleWheel[partIndex], parent.transform);
                instantiated.transform.position = wheelpos[1, 0];
                instantiated.transform.Rotate(0,90,0);
                list.Add(instantiated);
                instantiated = Instantiate(parts.viechleWheel[partIndex], parent.transform);
                instantiated.transform.position = wheelpos[1, 1];
                instantiated.transform.Rotate(0,90,0);
                list.Add(instantiated);
                instantiated = Instantiate(parts.viechleWheel[partIndex], parent.transform);
                instantiated.transform.position = wheelpos[1, 2];
                instantiated.transform.Rotate(0,90,0);
                list.Add(instantiated);
                instantiated = Instantiate(parts.viechleWheel[partIndex], parent.transform);
                instantiated.transform.position = wheelpos[1, 3];
                instantiated.transform.Rotate(0,90,0);
                list.Add(instantiated);
            }
        }
    }
    private void Seat(List<GameObject> list, bool selected)
    {
        if (selected)
        {
            if (parts.selectedSeatPosition == 0)
            {
                seat = Instantiate(parts.seat, parent.transform);
                if (parent.transform.Find("DraculaCart") != null)
                {
                    seat.transform.position = parent.transform.Find("DraculaCart").gameObject.GetComponent<SeatPositions>().frontSeatPos.position;
                }
                else if (parent.transform.Find("Sardine Car") != null)
                {
                    seat.transform.position = parent.transform.Find("Sardine Car").gameObject.GetComponent<SeatPositions>().frontSeatPos.position;
                }                list.Add(seat);
                Debug.Log("Front seat");
            }
            else if (parts.selectedSeatPosition == 1)
            {
                seat = Instantiate(parts.seat, parent.transform);
                if (parent.transform.Find("DraculaCart") != null)
                {
                    seat.transform.position = parent.transform.Find("DraculaCart").gameObject.GetComponent<SeatPositions>().middleSeatPos.position;
                }
                else if (parent.transform.Find("Sardine Car") != null)
                {
                    seat.transform.position = parent.transform.Find("Sardine Car").gameObject.GetComponent<SeatPositions>().middleSeatPos.position;
                }                list.Add(seat);
                Debug.Log("Middle seat");
            }
            else if (parts.selectedSeatPosition == 2)
            {
                seat = Instantiate(parts.seat, parent.transform);
                if (parent.transform.Find("DraculaCart") != null)
                {
                    seat.transform.position = parent.transform.Find("DraculaCart").gameObject.GetComponent<SeatPositions>().backSeatPos.position;
                }
                else if (parent.transform.Find("Sardine Car") != null)
                {
                    seat.transform.position = parent.transform.Find("Sardine Car").gameObject.GetComponent<SeatPositions>().backSeatPos.position;
                }                list.Add(seat);
                Debug.Log("Back seat");
            }
            else
            {
                Debug.Log("Error: Seat outside of range; " + partIndex);
            }
        }
        else
        {
            if (partIndex == 0)
            {
                seat = Instantiate(parts.seat, parent.transform);
                if (parent.transform.Find("DraculaCart") != null)
                {
                    seat.transform.position = parent.transform.Find("DraculaCart").gameObject.GetComponent<SeatPositions>().frontSeatPos.position;
                }
                else if (parent.transform.Find("Sardine Car") != null)
                {
                    seat.transform.position = parent.transform.Find("Sardine Car").gameObject.GetComponent<SeatPositions>().frontSeatPos.position;
                }
                list.Add(instantiated);
                Debug.Log("Front seat");
            }
            else if (partIndex == 1)
            {
                seat = Instantiate(parts.seat, parent.transform);
                if (parent.transform.Find("DraculaCart") != null)
                {
                    seat.transform.position = parent.transform.Find("DraculaCart").gameObject.GetComponent<SeatPositions>().middleSeatPos.position;
                }
                else if (parent.transform.Find("Sardine Car") != null)
                {
                    seat.transform.position = parent.transform.Find("Sardine Car").gameObject.GetComponent<SeatPositions>().middleSeatPos.position;
                }
                list.Add(instantiated);
                Debug.Log("Middle seat");
            }
            else if (partIndex == 2)
            {
                seat = Instantiate(parts.seat, parent.transform);
                if (parent.transform.Find("DraculaCart") != null)
                {
                    seat.transform.position = parent.transform.Find("DraculaCart").gameObject.GetComponent<SeatPositions>().backSeatPos.position;
                }
                else if (parent.transform.Find("Sardine Car") != null)
                {
                    seat.transform.position = parent.transform.Find("Sardine Car").gameObject.GetComponent<SeatPositions>().backSeatPos.position;
                }                list.Add(instantiated);
                Debug.Log("Back seat");
            }
            else
            {
                Debug.Log("Error: Seat outside of range; " + partIndex);
            }
        }
        seat.transform.Rotate(0,-90,0);
    }
    
    private void Costume(List<GameObject> list, bool selected)
    {
        if (selected)
        {
            parent = Instantiate(parts.selectedCharacterBody);
        }
        else
        {
            parent = Instantiate(parts.characterBody[partIndex]);
        }
        list.Add(parent);
        
        //position
        parent.transform.position = seat.transform.position;
    }
    private void Helmet(List<GameObject> list, bool selected)
    {
        if (selected)
        {
            instantiated = Instantiate(parts.selectedCharacterHead, parent.transform);
        }
        else
        {
            instantiated = Instantiate(parts.characterHead[partIndex], parent.transform);
        }
        instantiated.transform.Rotate(0, 180, 0);
        instantiated.transform.localPosition += new Vector3(0, 0, 0);
        list.Add(instantiated);
    }

    public void sardine()
    {
        Delete();
        partList = 0;
        partIndex = 1;
        parts.selectedViechleBody = parts.viechleBody[partIndex];
        Chassie(previewObjects, true);
        partList = 1;
        partIndex = 0;
        parts.selectedViechleDrivetrain = partIndex;
        BaseFrame(previewObjects, true);
        partList = 2;
        partIndex = 0;
        parts.selectedViechleWheel = parts.viechleWheel[partIndex];
        Wheels(previewObjects, true);
        partList = 3;
        partIndex = 1;
        parts.selectedSeatPosition = partIndex;
        Seat(previewObjects, true);
        partList = 4;
        partIndex = 0;
        parts.selectedCharacterBody = parts.characterBody[partIndex];
        //(previewObjects, true);
        partList = 5;
        partIndex = 0;
        parts.selectedCharacterHead = parts.characterHead[partIndex];
        //Helmet(previewObjects, true);
    }

    public void dracula()
    {
        Delete();
        partList = 0;
        partIndex = 0;
        parts.selectedViechleBody = parts.viechleBody[partIndex];
        Chassie(previewObjects, true);
        partList = 1;
        partIndex = 1;
        parts.selectedViechleDrivetrain = partIndex;
        BaseFrame(previewObjects, true);
        partList = 2;
        partIndex = 1;
        parts.selectedViechleWheel = parts.viechleWheel[partIndex];
        Wheels(previewObjects, true);
        partList = 3;
        partIndex = 1;
        parts.selectedSeatPosition = partIndex;
        Seat(previewObjects, true);
        partList = 4;
        partIndex = 0;
        parts.selectedCharacterBody = parts.characterBody[partIndex];
        partList = 5;
        partIndex = 0;
        parts.selectedCharacterHead = parts.characterHead[partIndex];
    }
}