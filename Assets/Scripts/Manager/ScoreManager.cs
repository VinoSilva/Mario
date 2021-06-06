using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Scriptable Variables References")]
    [SerializeField]
    private IntVariable scoreVariable = null;

    [SerializeField]
    private GameEvent OnScoreUpdated = null;

    public void OnScore(){
        scoreVariable.RuntimeValue += ScoreChangeEvent.ScoreAdd;

        OnScoreUpdated.Raise();
    }
}
