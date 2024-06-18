using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Inputs : MonoBehaviour
{
    //public List<ButtonLock> BtnLocks;
    public Slider slider;
    public TextMeshProUGUI valueOut;
    public int sceneID = 0;

    public PlayerInfo playerInfo;
    public void SceneBtn(int sceneIndex)
    {
        Debug.Log("enterd SceneBtn");
        if (sceneIndex == -1)
        {
            Debug.Log("SceneID = " + sceneID);
            if (sceneID >= 0 && sceneID <= SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadSceneAsync(sceneID);
                Debug.Log("load level scene" + sceneID);
            }
            else
            {
                Debug.Log("level scene " + sceneIndex + " dose not exist");
            }
        }
        else if (sceneIndex == SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadSceneAsync(sceneIndex);
            Debug.Log("reload scene");
        }
        //Loads every scene
        else if (sceneIndex >= 0 && sceneIndex <= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadSceneAsync(sceneIndex);
            if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 2)
            {
                GameState.Instance.DefaultPlayer();
            }
            Debug.Log("load scene" + sceneIndex);
        }
        else
        {
            Debug.Log("scene " + sceneIndex + " dose not exist");
        }
    }
    /*
    public void LevelButton(int sceneIndex)
    {
        sceneID = sceneIndex;
        Debug.Log("SceneID = " + sceneID);
    }
    */
    public void NextPlayer()
    {
        GameState.Instance.SwitchPlayer();
    }
    //Loads 
    public void NextLevel(int sceneIndex)
    {
        if (GameState.Instance.GetPlayerTurn() == PlayerTurn.Player2Turn)
        {
            SceneBtn(sceneIndex);
        }
        else
        {
            SceneBtn(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void RestartBtn()
    {
        SceneBtn(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        Debug.Log("pause");
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void SliderValue()
    {
        float value = 0;
        if (slider != null)
        {
            value = slider.value * 100;
        }

        if (valueOut != null)
        {
            int returnValue = (int)value;
            valueOut.text = returnValue.ToString();
        }
    }
}
