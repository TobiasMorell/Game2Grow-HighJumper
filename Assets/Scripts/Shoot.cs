using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public GameObject ThingToShoot;
	public float HowOftenToShoot;
	public Transform target;

	private float timer;

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), ThingToShoot.GetComponent<Collider2D> ());
	}

	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;

		if (timer > HowOftenToShoot)
		{
			//Reset timer
			timer = 0;

			Vector3 myPos = new Vector3(transform.position.x, transform.position.y) + transform.forward;
			Vector2 direction = target.position - myPos;
			direction.Normalize();
			GameObject projectile = (GameObject)Instantiate(ThingToShoot, myPos, Quaternion.identity);
			projectile.GetComponent<Rigidbody2D>().velocity = direction * 7;
		}
	}
}
