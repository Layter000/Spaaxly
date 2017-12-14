using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnOf : MonoBehaviour {

    public void AudioOff()
    {
        AudioListener.volume = 0;
    }
    public void AudioOn()
    {
        AudioListener.volume = 1;
    }
}
