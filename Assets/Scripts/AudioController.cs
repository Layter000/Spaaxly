using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public float CrossFadeTime = 0.5f;
    public float CrossFadeDelay;

    public AudioClip menuSound;
    public AudioClip gameSound;
    public AudioClip gameoverSound;

    private DoubleAudioSource audioSource;

    private bool isStart = false;

    void Start ()
    {
        audioSource = GetComponent<DoubleAudioSource>();
        audioSource.CrossFade(menuSound, 1, 0);
    }

    public void PlayMenuSound()
    {
        audioSource.CrossFade(menuSound, 1, CrossFadeTime, CrossFadeDelay);
    }

    public void PlayGameSound()
    {
        audioSource.CrossFade(gameSound, 1, CrossFadeTime, CrossFadeDelay);
    }

    public void PlayGameOverSound()
    {
        audioSource.CrossFade(gameoverSound, 1, CrossFadeTime, CrossFadeDelay);
    }
}
