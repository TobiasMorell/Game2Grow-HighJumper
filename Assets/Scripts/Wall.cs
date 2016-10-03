using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	//Denne metode bliver kaldt hver gang noget støder ind i objektet, som scriptet sidder på
	void OnCollisionEnter2D(Collision2D collision) {
		ContactPoint2D cp = collision.contacts [0];
		Debug.Log ("Collision with wall: " + cp.collider.tag);

		//Kalder metoden HitWall, hvis det der er stødt ind i væggen er en platform
		if (cp.collider.CompareTag ("Platform")){
			cp.collider.GetComponent<MovePlatform> ().HitWall ();
		}
	}
}
