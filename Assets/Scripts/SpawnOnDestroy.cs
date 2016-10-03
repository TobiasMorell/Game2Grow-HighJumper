using UnityEngine;
using System.Collections;

public class SpawnOnDestroy : MonoBehaviour {
	public GameObject thingToSpawn;

	private bool isQuitting;

	public void OnDestroy() {
		if (!isQuitting) {
			Instantiate (thingToSpawn, this.transform.position, Quaternion.identity);
		}
	}

	void OnApplicationQuit() {
		isQuitting = true;
	}
}
