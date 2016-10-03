using UnityEngine;
using System.Collections;

public class GivePoints : MonoBehaviour {
	public int pointsFromPickup;

	private bool isQuitting;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			Destroy (this.gameObject);
		}
	}
		
	public void OnDestroy() {
		if (!isQuitting) {
			ScoreBoard.Instance.AddPoints (pointsFromPickup);
		}
	}

	void OnApplicationQuit() {
		isQuitting = true;
	}
}
