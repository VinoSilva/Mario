using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMenuUI : MonoBehaviour
{
    [Header("UI references")]
    [SerializeField]
    private Text scoreText = null; 

    [Header("Scriptable variable references")]
    [SerializeField]
    private IntVariable scoreVariable = null;

    public void OnScoreUpdated(){
        scoreText.text = scoreVariable.RuntimeValue.ToString("00000000");
    }
}
