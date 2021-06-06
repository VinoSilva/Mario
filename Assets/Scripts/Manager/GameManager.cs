using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Scriptable Variables")]
    [SerializeField]
    private BoolVariable isPaused;

    public void OnPause(){
        isPaused.RuntimeValue = true;
        Time.timeScale = 0.0f;
    }

    public void OnResume(){
        isPaused.RuntimeValue = false;
        Time.timeScale = 1.0f;
    }

}
