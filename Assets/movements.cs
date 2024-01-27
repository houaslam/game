using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movements : MonoBehaviour
{
	private Rigidbody2D rb;
	public float speed = 5;
	private float jump = 10;
	private bool lookingRight = true;
	public Camera cam;
	private 
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D> ();
    }

    void Update()
    {
		playerMovement();
		cameraFollow();
		if (!lookingRight)
			transform.rotation = Quaternion.Euler(0, 180, 0);
		else
			transform.rotation = Quaternion.Euler(0, 0, 0);
    }

	void playerMovement()
	{
		if (Input.GetAxisRaw("Horizontal") != 0)
			lookingRight = Input.GetAxisRaw("Horizontal") == 1;
		rb.velocity = new Vector2 (Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
		if (Input.GetAxisRaw("Vertical") == 1 && IsGrounded())
			rb.velocity = new Vector2(rb.velocity.x, jump);
	}
	void cameraFollow()
	{
		if (transform.position.x > cam.transform.position.x + 1)
			cam.transform.position = new Vector3 (transform.position.x - 1, cam.transform.position.y, cam.transform.position.z);
		if (transform.position.x < cam.transform.position.x - 4)
			cam.transform.position = new Vector3 (transform.position.x + 4, cam.transform.position.y, cam.transform.position.z);
	}
	bool IsGrounded()
	{
		return this.GetComponent<Rigidbody2D>().velocity.y < 0.5f;
	}

}
