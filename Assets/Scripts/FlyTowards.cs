using UnityEngine;
using System.Collections;

public class FlyTowards : MonoBehaviour {
	/// <summary>
	/// Angiver det mål som dette script skal flyve imod.
	/// </summary>
	public Transform target;
	/// <summary>
	/// Angiver hvor hurtigt scriptet skal flyve.
	/// </summary>
	public float speed;
	/// <summary>
	/// Angiver hvor tæt flyveren må flyve på målet. Den bevæger sig kun, hvis den er længere væk.
	/// </summary>
	public float minDistanceToTarget;

	void Start() {
		if (target == null) {
			target = GameObject.FindGameObjectWithTag ("Player").transform;
		}
	}

	void Update () {
		if (target != null) {
			//Kigger over mod målet
			Quaternion rotation = Quaternion.LookRotation (target.position - transform.position, transform.TransformDirection(Vector3.up));
			transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

			//Og bevæger sig frem mod det
			if(Mathf.Abs(Vector2.Distance(transform.position, target.position)) > minDistanceToTarget)
				transform.position += -transform.right * speed * Time.deltaTime;
		}
	}
}
