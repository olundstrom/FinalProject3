using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller3 : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingLeft = true;
	private Rigidbody2D rb2d;
	public int Health = 3;
	public int MaxHealth = 3;
	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 500f;

	void Start() {

		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate() {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", rb2d.velocity.y);

		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		rb2d.velocity = new Vector2 (move * maxSpeed, rb2d.velocity.y);
	
		if (move < 0 && !facingLeft)
			Flip ();
		else if (move > 0 && facingLeft)
			Flip ();
	
	}

	void Update() {

		if (grounded && Input.GetKeyDown (KeyCode.UpArrow) && (rb2d.velocity.y < .0001 && rb2d.velocity.y > -.001)) {
			anim.SetBool ("Ground", false);
			rb2d.AddForce (new Vector2 (0, jumpForce));
		}
	}

	void Flip() {

		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}
}