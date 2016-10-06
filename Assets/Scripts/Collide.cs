using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour {
	public bool ignorePlatforms;
	public string killMessage;

	//Denne metode bliver kaldt hver gang tingen som denne sidder på støder ind i noget.
	void OnTriggerEnter2D(Collider2D other) {

		//Ødelægger den ting som dette script sidder på, hvis den rammer jorden
		if (other.CompareTag ("Ground")) {
			Destroy (this.gameObject);
		}

		if (other.CompareTag ("Player") && Health.Instance != null) {
			//Får spilleren til at miste et liv
			Health.Instance.LoseLife();
			if (Health.Instance.lives == 0) {
				//Fjerner kameraet fra spilleren, så det ikke går amok.
				var cam = other.GetComponentInChildren<Camera> ();
				cam.transform.SetParent (null);

				Destroy (other.gameObject);

				//Display a splash on-screen
				ScoreBoard.Instance.DisplayGameoverSplash(killMessage, Color.red);
			}
			
			//Ødelægger objektet
			Destroy (this.gameObject);
		}

		//Ødelægger kun den ting som dette script sidder på, hvis den rammer en platform
		if (!ignorePlatforms) {
			if (other.CompareTag ("Platform")) {
				Destroy (this.gameObject);
			}
		}
	}
}
