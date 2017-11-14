using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Movement
    public KeyCode moveUp;
    public KeyCode moveDown;
    public KeyCode moveLeft;
    public KeyCode moveRight;

    // Constants
    public float speed = 1;

    // "Body"
    private Rigidbody2D rb2;
    private float moveHorizontal;
    private float moveVertical;

	// Use this for initialization
	void Start () {
        rb2 = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate() {
        if(Input.GetKey(moveUp))
            {
                moveVertical = 1;
        //        animator.SetTrigger("up");
            }
        if(Input.GetKey(moveDown))
            {
                moveVertical = -1;
        //        animator.SetTrigger("down");
            }
        if(Input.GetKey(moveLeft))
            {
                moveHorizontal = -1;
        //        animator.SetTrigger("left");
            }
        if(Input.GetKey(moveRight))
            {
                moveHorizontal = 1;
        //        animator.SetTrigger("right");
            }

        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2.velocity = movement * speed;
        // Reset movement vector
        moveHorizontal = 0;
        moveVertical = 0;
    }
}
