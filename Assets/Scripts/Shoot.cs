using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public GameObject ThingToShoot;
	public float HowOftenToShoot;
	public Transform Target;

	private float timer;

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), ThingToShoot.GetComponent<Collider2D> ());
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer > HowOftenToShoot) {
			var shot = Instantiate (ThingToShoot);

			//Kigger over mod målet
			Quaternion rotation = Quaternion.LookRotation (Target.position - transform.position, transform.TransformDirection (Vector3.up));
			shot.transform.rotation = new Quaternion (0, 0, rotation.z, rotation.w);
		}
	}
}
