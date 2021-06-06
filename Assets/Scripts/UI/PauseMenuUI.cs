using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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

    [Header("Tween variables")]
    [SerializeField]
    private RectTransform ownRectTransform = null;

    [SerializeField]
    private Vector3 startScale = new Vector3(0.1f,0.1f,1.0f);

    [SerializeField]
    private Vector3 endScale = new Vector3(0.5f,0.5f,1.0f);

    [SerializeField]
    [Range(0.1f,5.0f)]
    private float scaleDuration = 1.0f;

    private Tween tween = null;

    private void Start() {
        continueBtn.onClick.AddListener (OnClickContinue);
        saveQuitBtn.onClick.AddListener (OnClickSave);
        quitBtn.onClick.AddListener (OnClickQuit);
    }

    private void OnEnable()
    {
        StaticEventSystem.Select(continueBtn.gameObject);

        BeginTween();
    }

    private void BeginTween(){
        SetButtonActive(false);

        ownRectTransform.localScale =  startScale;

        if(tween == null)
        {
           tween = ownRectTransform.DOScale(endScale,scaleDuration).SetAutoKill(false).OnComplete(OnEndTween);
        }
        else
        {
            tween.OnComplete(OnEndTween).Restart();
        }
    }

    private void OnEndTween(){
        SetButtonActive(true);
    }

    private void SetButtonActive(bool isActive){
        continueBtn.gameObject.SetActive(isActive);
        saveQuitBtn.gameObject.SetActive(isActive);
        quitBtn.gameObject.SetActive(isActive);
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
