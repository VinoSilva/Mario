using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerMenuUI : MonoBehaviour
{
    [SerializeField]
    private Text timerTxt = null;

    [SerializeField]
    private FloatVariable timerVariable = null;

    public void OnTimerUpdated()
    {
        timerTxt.text = timerVariable.RuntimeValue.ToString("0");
    }
}
