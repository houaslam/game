using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movements : MonoBehaviour
{
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private float py;
	public Sprite idle;
	public Sprite moving;
	public float speed = 5;
	private float jump = 10;
	private bool lookingRight = true;
	public Camera cam;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D> ();
		sr = this.GetComponent<SpriteRenderer> ();
		py = transform.position.y + 0.5f;
		Debug.Log(py);
    }

    void Update()
    {
		playerMovement(Input.GetAxisRaw("Horizontal"));
		cameraFollow();
		if (!lookingRight)
			transform.rotation = Quaternion.Euler(0, 180, 0);
		else
			transform.rotation = Quaternion.Euler(0, 0, 0);
    }

	void playerMovement(float x)
	{
		if (x != 0)
		{
			lookingRight = x == 1;
			sr.sprite = moving;
		}
		else
			sr.sprite = idle;
		rb.velocity = new Vector2 (x * speed, rb.velocity.y);
		if (Input.GetKeyDown("up") && IsGrounded())
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
		Debug.Log(rb.velocity.y);
		return (rb.velocity.y < 0.001f);
	}
}
