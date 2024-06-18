using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script does not serve a function
public class HandlePlayersFinished : MonoBehaviour
{
    public GameActionVoid finishLinePassed;

    private void OnEnable()
    {
        finishLinePassed.callActionVoid += HandleFinish;
    }

    private void OnDisable()
    {
        finishLinePassed.callActionVoid -= HandleFinish;
    }

    private void HandleFinish()
    {
        //GameState.Instance.SwitchPlayer();
        //StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(5);
        if (GameState.Instance.GetActiveState() == GameStates.Player1Turn)
        {
            GameState.Instance.UpdateState(GameStates.Player2Turn);
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadSceneAsync(scene.name);
        }
        else if (GameState.Instance.GetActiveState() == GameStates.Player2Turn)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;

            GameState.Instance.UpdateState(GameStates.Player1Turn);
            SceneManager.LoadSceneAsync(sceneIndex + 1);
        }
    }
}
