using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class MoveButtons : MonoBehaviour
{
    public ControllData Data;
    public MovebleButtuns moveButton;

    private void Start()
    {
        setPositions();
        //getPosition();
    }

    public void MoveUp(int distance)
    {
        bool reachedEnd = false;
        float temp = 0;
        foreach (MovebleButtunsL mBtn in moveButton.letf)
        {
            temp = mBtn.btn.transform.position.x;
            mBtn.btn.transform.position += new Vector3(0, distance);
            if (mBtn.btn.transform.position.y >= mBtn.maxPos.y)
            {
                reachedEnd = true;
            }
            if (mBtn.btn.transform.position.y < temp)
            {
                temp = mBtn.btn.transform.position.y;
            }   
        }
        foreach (MovebleButtunsR mBtn in moveButton.right)
        {
            temp = mBtn.btn.transform.position.x;
            mBtn.btn.transform.position += new Vector3(0, distance);
            if (mBtn.btn.transform.position.y >= mBtn.maxPos.y)
            {
                reachedEnd = true;
            }
            if (mBtn.btn.transform.position.y < temp)
            {
                temp = mBtn.btn.transform.position.y;
            }   
        }
        if (reachedEnd)
        {
            foreach (MovebleButtunsL mBtn in moveButton.letf)
            {
                float sub = temp - mBtn.minPos.y;
                mBtn.btn.transform.position += new Vector3(0, -sub);
            }
            foreach (MovebleButtunsR mBtn in moveButton.right)
            {
                float sub = temp - mBtn.minPos.y;
                mBtn.btn.transform.position += new Vector3(0, -sub);
            }
            reachedEnd = false;
        }
        setPositions();
    }

    public void MoveLBtnRight(int distance)
    {
        bool reachedEnd = false;
        float temp = 0;
        foreach (MovebleButtunsL mBtn in moveButton.letf)
        {
            temp = mBtn.btn.transform.position.x;
            mBtn.btn.transform.position += new Vector3(distance, 0);
            if (mBtn.btn.transform.position.x >= mBtn.maxPos.x)
            {
                Debug.Log("end reached");
                reachedEnd = true;
            }
            if (mBtn.btn.transform.position.x < temp)
            {
                temp = mBtn.btn.transform.position.x;
            }   
        }
        if (reachedEnd)
        {
            foreach (MovebleButtunsL mBtn in moveButton.letf)
            {
                float sub = temp - mBtn.minPos.x;
                mBtn.btn.transform.position += new Vector3(-sub, 0);
            }
            reachedEnd = false;
        }
        setPositions();
    }
    public void MoveRBtnLeft(int distance)
    {
        bool reachedEnd = false;
        float temp = 0;
        foreach (MovebleButtunsR mBtn in moveButton.right)
        {
            temp = mBtn.btn.transform.position.x;
            mBtn.btn.transform.position += new Vector3(-distance, 0);
            if (mBtn.btn.transform.position.x <= mBtn.maxPos.x)
            {
                Debug.Log("reached end");
                reachedEnd = true;
            }
            Debug.Log("pos: " + mBtn.btn.transform.position.x + "temp: " + temp);
            if (mBtn.btn.transform.position.x > temp)
            {
                temp = mBtn.btn.transform.position.x;
                Debug.Log("new temp: " + temp);
            }
        }
        if (reachedEnd)
        {
            foreach (MovebleButtunsR mBtn in moveButton.right)
            {
                float sub = temp - mBtn.minPos.x;
                mBtn.btn.transform.position += new Vector3(sub, 0);
            }
            reachedEnd = false;
        }
        setPositions();
    }

    private void setPositions()
    {
        foreach (MovebleButtunsL mBtn in moveButton.letf)
        {
            foreach (ControllButton btn in Data.Buttons)
            {
                if (mBtn.accelerate && btn.accelerate)
                {
                    btn.pos = mBtn.btn.transform.position;
                }
                if (mBtn._break && btn._break)
                {
                    btn.pos = mBtn.btn.transform.position;
                }
            }
        }
        foreach (MovebleButtunsR mBtn in moveButton.right)
        {
            foreach (ControllButton btn in Data.Buttons)
            {
                if (mBtn.left && btn.left)
                {
                    btn.pos = mBtn.btn.transform.position;
                }
                if (mBtn.right && btn.right)
                {
                    btn.pos = mBtn.btn.transform.position;
                }
            }
        }
    }
    public void getPosition()
    {
        foreach (MovebleButtunsL mBtn in moveButton.letf)
        {
            foreach (ControllButton btn in Data.Buttons)
            {
                if (mBtn.accelerate && btn.accelerate)
                {
                    mBtn.btn.transform.position = btn.pos;
                }
                if (mBtn._break && btn._break)
                {
                    mBtn.btn.transform.position = btn.pos;
                }
            }
        }
        foreach (MovebleButtunsR mBtn in moveButton.right)
        {
            foreach (ControllButton btn in Data.Buttons)
            {
                if (mBtn.left && btn.left)
                {
                    mBtn.btn.transform.position = btn.pos;
                }
                if (mBtn.right && btn.right)
                {
                    mBtn.btn.transform.position = btn.pos;
                }
            }
        }
    }
}

[System.Serializable]
public class MovebleButtunsL
{
    public bool accelerate;
    public bool _break;
    public Button btn;
    public Vector2 minPos;
    public Vector2 maxPos;
}
[System.Serializable]
public class MovebleButtunsR
{
    public bool left;
    public bool right;
    public Button btn;
    public Vector2 minPos;
    public Vector2 maxPos;
}
[System.Serializable]
public class MovebleButtuns
{
    public List<MovebleButtunsR> right;
    public List<MovebleButtunsL> letf;
}