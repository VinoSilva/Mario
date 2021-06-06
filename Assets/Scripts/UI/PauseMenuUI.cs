using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [Header("Button references")]
    [SerializeField]
    private Button continueBtn = null;

    [SerializeField]
    private Button saveQuitBtn = null;

    [SerializeField]
    private Button quitBtn = null;

    [Header("Game Event References")]
    [SerializeField]
    private GameEvent resumeEvent = null;

    private void OnEnable()
    {
        StaticEventSystem.Select(continueBtn.gameObject);

        continueBtn.onClick.AddListener (OnClickContinue);
        saveQuitBtn.onClick.AddListener (OnClickSave);
        quitBtn.onClick.AddListener (OnClickQuit);
    }

    private void OnClickContinue()
    {
        resumeEvent.Raise();
    }

    private void OnClickSave()
    {
        Debug.Log("Save");
    }

    private void OnClickQuit()
    {
        LevelManager.QuitGame();
    }
}
