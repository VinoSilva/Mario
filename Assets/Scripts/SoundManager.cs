using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance = null;

    public static SoundManager Instance { get => _instance; private set => _instance = value; }

    [Header("Component references")]
    [SerializeField]
    private AudioSource audioSource = null;

    // Start is called before the first frame update
    void Start()
    {
        if(!_instance){
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }
    }

    public void PlayOneShot(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
