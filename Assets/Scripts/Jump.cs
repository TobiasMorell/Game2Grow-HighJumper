using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	/// <summary>
	/// Angiver hvilken knap man hopper på.
	/// </summary>
	public KeyCode jumpButton;
	/// <summary>
	/// Angiver hvor hurtigt man hopper.
	/// </summary>
	public float jumpSpeed;

	//Hvorfor kan du ikke se disse i inspectoren? - fordi de er 'private' og ikke 'public'
	private Rigidbody2D rb;
	private bool isInAir = true;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update bliver kørt en gang pr. frame
	void FixedUpdate () {
		if (Input.GetKeyDown (jumpButton) && !isInAir) {
			rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed);
			isInAir = true;
		}
	}

	//Denne metode bliver kørt hver gang objektet som scriptet sidder på støder ind i noget.
	void OnCollisionEnter2D(Collision2D collision) {
		ContactPoint2D cp = collision.contacts [0];

		if (cp.collider.CompareTag ("Ground") || cp.collider.CompareTag ("Platform")) {
			isInAir = false;
		}
	}
}
