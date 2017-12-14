using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroid : MonoBehaviour {

    void Start()
    {
        GameControl.instance.OnGameRestart += Restart;
    }

    void Restart()
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        GameControl.instance.OnGameRestart -= Restart;
    }
}
