using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public bool SpawnByTime;
	/// <summary>
	/// Angiver hvor langt tid der skal gå mellem missilerne.
	/// </summary>
	public float timeBetweenSpawn;
	/// <summary>
	/// Angiver den laveste x-værdi for hvor missilerne må spawne.
	/// </summary>
	public float lowestX;
	/// <summary>
	/// Angiver den højeste x-værdi for hvor missilerne må spawne.
	/// </summary>
	public float maxX;
	/// <summary>
	/// Angiver den laveste y-værdi for hvor missilerne må spawne.
	/// </summary>
	public float lowestY;
	/// <summary>
	/// Angiver den højeste y-værdi for hvor missilerne må spawne.
	/// </summary>
	public float maxY;
	/// <summary>
	/// Her kan du angive den ting som spawneren skal spawne.
	/// </summary>
	public Spawnable thingToSpawn;

	//Du kan ikke se denne fordi den er 'private'.
	private float timer = 0f;

	public bool KeepSpawning = false;

	void Start() {
		if (!SpawnByTime)
			spawn ();
	}

	void Update () {
		//Opdaterer tiden ved hver frame
		timer += Time.deltaTime;

		//Hvis timeren har overskredet din angivne tid vil koden mellem de to tuborgklammer ({}) blive kørt.
		if (KeepSpawning && SpawnByTime && timer > timeBetweenSpawn) {
			spawn ();
		}
	}

	public void SpawnNew() {
		if(!SpawnByTime && KeepSpawning)
			spawn ();
	}

	private void spawn() {
		//Opretter et nyt GameObject ud fra den ting du gerne vil spawne.
		var thing = Instantiate (thingToSpawn);
		//Sætter dens position til et sted mellem de to angivne x- og y-værdier.
		thing.transform.position = new Vector3 (Random.Range (lowestX, maxX), Random.Range (lowestY, maxY));
		//Nulstiller tiden, så der går lidt tid inden spawneren spawner igen.
		timer = 0f;

		thing.GetComponent<Spawnable> ().Spawn (this);
	}
}
