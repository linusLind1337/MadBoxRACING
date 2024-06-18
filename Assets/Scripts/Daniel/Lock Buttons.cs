using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockButtons : MonoBehaviour
{
    public List<ButtonLock> BtnLocks;
    private void Start()
    {
        if (BtnLocks != null)
        {
            Lock();
        }
    }
    private void Lock()
    {
        foreach (ButtonLock world in BtnLocks)
        {
            if (world.isLocked == true)
            {
                foreach (Button btn in world.Buttons)
                {
                    btn.interactable = false;
                }
            }
        }
    }
    public void Lock(int index)
    {
        BtnLocks[index].isLocked = true;
        foreach (Button btn in BtnLocks[index].Buttons)
        {
            btn.interactable = false;
        }
    }
    public void UnLock(int index)
    {
        BtnLocks[index].isLocked = false;
        foreach (Button btn in BtnLocks[index].Buttons)
        {
            btn.interactable = true;
        }
    }
}
[System.Serializable]
public class ButtonLock
{
    public bool isLocked;
    public List<Button> Buttons;
}