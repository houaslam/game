using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movements : MonoBehaviour
{
	private Rigidbody2D rb;
	public float speed = 5;
	private float jump = 5;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D> ();
    }

    void Update()
    {
		rb.velocity = new Vector2 (Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * jump);
		// rb.AddForce (new Vector2 (Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * jump));
    }
}
