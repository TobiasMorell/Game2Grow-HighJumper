using System;
using UnityEngine;


public class Spawnable : MonoBehaviour
{
	private Spawner spawner;

	private bool isQuitting;

	public void Spawn(Spawner spawner) {
		this.spawner = spawner;
	}

	public void OnDestroy() {
		if (!isQuitting && spawner != null) {
			spawner.SpawnNew ();
		}
	}

	void OnApplicationQuit() {
		isQuitting = true;
	}
}

