using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movements : MonoBehaviour
{
	private Rigidbody2D rb;
	public float speed = 5;
	private float jump = 10;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D> ();
    }

    void Update()
    {
		rb.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * speed, rb.velocity.y);
		
		if (Input.GetAxisRaw("Vertical") == 1 && IsGrounded())
		{
			rb.velocity = new Vector2(rb.velocity.x, jump);
		}


    }

	bool IsGrounded()
	{
		return GetComponent<Rigidbody2D>().velocity.y == 0;
	}

}
