using UnityEngine;
using System.Collections;

public class MoveWithArrows : MonoBehaviour {
	/// <summary>
	/// Angiver hvor hurtigt den ting som scriptet sidder på skal bevæge sig.
	/// </summary>
	public float speed;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
	}
}
