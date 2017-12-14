using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    private Rigidbody2D rb2d;

	void Start () {
        rb2d = GetComponent<Rigidbody2D> ();
        
	}
	void Update () {
        if (GameControl.instance.gameOver == true || GameControl.instance.isStart == false)
        {
            rb2d.velocity = Vector2.zero;
        }
        else
        {
            rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed * -1, 0);
        }
    }
}
