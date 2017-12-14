using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;
    private Vector2 bgPositionStart;

	void Start () {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
        bgPositionStart = gameObject.transform.position;
        GameControl.instance.OnGameRestart += Restart;
    }
	void Update () {
		if (transform.position.x < - groundHorizontalLength)
        {
            RepositionBackGround();
        }
    }

    private void RepositionBackGround()
    {
        Vector2 groundoffset = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundoffset;
    }
    void Restart()
    {
        gameObject.transform.position = bgPositionStart;
    }

    void OnDestroy()
    {
        GameControl.instance.OnGameRestart -= Restart;
    }
}
