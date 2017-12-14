using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

    public float upForce = - 1000f;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    private Vector2 positionStart;
    private Vector2 rotationStart;

    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        positionStart = gameObject.transform.position;
        GameControl.instance.OnGameRestart += Restart;
    }
	
	void Update () {

        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                rb2d.velocity = Vector2.zero;
                rb2d.gravityScale = rb2d.gravityScale * -1f;
                rb2d.AddForce(new Vector2(0, upForce * rb2d.gravityScale));
                if (rb2d.gravityScale < 0)
                {
                    anim.SetTrigger("tapUp");
                }
                else
                {
                    anim.SetTrigger("tapDown");
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (GameControl.instance.gameOver == false)
        {
            GameControl.instance.PlayerDied();
            rb2d.velocity = Vector2.zero;
            rb2d.gravityScale = 0;
            isDead = true;
            anim.SetTrigger("die");
        }
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
