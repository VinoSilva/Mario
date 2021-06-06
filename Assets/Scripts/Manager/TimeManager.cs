using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("Game Event References")]
    [SerializeField]
    private GameEvent OnTimeUpdated = null;

    [Header("Scriptable Variables References")]
    [SerializeField]
    private FloatVariable floatVariable = null;

    [SerializeField]
    private BoolVariable isPaused = null;

    // Update is called once per frame
    void Update()
    {
        if(isPaused.RuntimeValue){
            return;
        }
        
        floatVariable.RuntimeValue -= Time.deltaTime;
        floatVariable.RuntimeValue = Mathf.Clamp(floatVariable.RuntimeValue,0.0f,Mathf.Infinity);

        // KIV:Vino
        // Should not be called every second
        OnTimeUpdated.Raise();
    }
}
