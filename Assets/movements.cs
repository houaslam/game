using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movements : MonoBehaviour
{
	private Rigidbody2D rb;
	public float speed = 5;
	private float jump = 10;
	public Camera cam;
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
		cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);

    }

	bool IsGrounded()
	{
		return GetComponent<Rigidbody2D>().velocity.y == 0;
	}

}
