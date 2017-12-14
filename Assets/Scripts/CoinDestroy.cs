using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : MonoBehaviour {

    void OnTriggerEnter2D()
    {
        GameControl.instance.PlayerScored();
        Destroy(gameObject);
    }
}
