using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {
	/// <summary>
	/// Angiver hvor hurtigt platformen skal bevæge sig - husk at negative værdier bevæger den til venstre :)
	/// </summary>
	public float xSpeed;
	public float ySpeed;
	/// <summary>
	/// Angiver om platformen skal flytte sig eller om den skal stå stille
	/// </summary>
	public bool moving;

	//Denne metode bliver kaldt hver gang der skal genereres en frame
	void Update () {
		if (moving) {
			transform.position += Vector3.right * xSpeed * Time.deltaTime;
			transform.position += Vector3.up * ySpeed * Time.deltaTime;
		}
	}

	public void HitWall() {
		xSpeed = -xSpeed;
		ySpeed = -ySpeed;
	}
}
