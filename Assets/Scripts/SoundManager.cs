using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [Header("Component references")]
    [SerializeField]
    private AudioSource audioSource = null;

    // Start is called before the first frame update
    void Start()
    {
        ServiceLocator.instance.AddService<SoundManager>(this);
    }

    public void PlayOneShot(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    private void OnDestroy() {
        ServiceLocator.instance.RemoveService<SoundManager>(this);
    }
}
