using UnityEngine;
using System.Collections;

public class FlyDown : MonoBehaviour {
	public float speed;

	void Update () {
		//Flytter den ting som dette script sidder på en smule ned ad hver frame
		this.transform.position += Vector3.down * speed * Time.deltaTime;
	}
}
