using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [Header("Game Event References")]
    [SerializeField]
    private GameEvent onScoreEvent = null;

    [Header("Sound Clip References")]
    [SerializeField]
    private AudioClip scoreClip;

    public void OnScore(int scoreToAdd){
        ServiceLocator.instance.GetService<SoundManager>().PlayOneShot(scoreClip);
        ScoreChangeEvent.Raise(onScoreEvent,scoreToAdd);
    }
}
