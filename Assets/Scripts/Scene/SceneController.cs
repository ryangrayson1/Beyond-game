using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The overall manager script for the entire scene.
/// </summary>
public class SceneController : MonoBehaviour
{
    public enum SceneState
    {
        LOADING,
        RUNNING,
        GAMEOVER
    }

    private SceneState state;
    private UIController timer; // the timer script

    private void Start()
    {
        //TODO: UNDO
        //state = SceneState.LOADING;
        timer = GetComponent<UIController>();


        //TODO: REMOVE, IS DEBUG
        state = SceneState.RUNNING;
        timer.startTimer();
    }

    private void Update()
    {
        // Press space to start
        switch (state)
        {
            case SceneState.LOADING:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    state = SceneState.RUNNING;
                    timer.startTimer();
                    timer.startPower();
                }
                break;
            case SceneState.RUNNING:
                if (timer.isTimerStopped())
                {
                    state = SceneState.GAMEOVER;
                }
                // TODO detect player victory
                break;
            case SceneState.GAMEOVER:
                break;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<ChangeScene>().LoadScene("MenuScene");
        }
    }

    public SceneState GetState()
    {
        return state;
    }
}
