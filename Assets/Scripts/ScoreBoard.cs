using System;
using UnityEngine;
using UnityEngine.UI;


public class ScoreBoard : MonoBehaviour
{
	public static ScoreBoard Instance;

	public Text pointText;
	public Text SplashText;
	public Button RestartButton;

	public int points;
	public int targetPoints;

	public GameObject SmileyPrefab;

	private CanvasGroup splashCanvas;
	private Button restart;

	void Start() {
		Instance = this;
		SplashText.color = Color.black;
		splashCanvas = GetComponentInChildren<CanvasGroup> ();
		restart = GetComponentInChildren<Button> ();
		HideCanvas (splashCanvas);
	}

	void Update() {
		if (targetPoints != 0 && points == targetPoints) {
			DisplayGameoverSplash ("You just won this game! Awesome :D", Color.green);
		}
	}

	public void AddPoints(int pointsToAdd) {
		points += pointsToAdd;

		pointText.text = "Points: " + points;
	}

	public void RestartGame() {
		points = 0;
		HideCanvas (splashCanvas);
		
		setSpawnersTo(true);
		if(!playerIsAlive) 
			Instantiate (SmileyPrefab);
	}
	private bool playerIsAlive = true;
	private void destroyAllSpawns()
	{
		playerIsAlive = false;
		foreach (var spawn in GameObject.FindObjectsOfType<Spawnable>())
		{
			if (!spawn.CompareTag("Player"))
				Destroy(spawn.gameObject);
			else
				playerIsAlive = true;
		}
	}

	private void setSpawnersTo(bool state)
	{
		foreach (var spawner in GameObject.FindObjectsOfType<Spawner>())
		{
			spawner.KeepSpawning = state;
		}
	}

	public void DisplayGameoverSplash(string splash, Color displayColor) {
		SplashText.text = splash;
		SplashText.color = displayColor;
		ShowCanvas (splashCanvas);

		setSpawnersTo(false);
		destroyAllSpawns();
	}

	void ShowCanvas(CanvasGroup cg) {
		cg.alpha = 1f;
		cg.blocksRaycasts = true;
		restart.gameObject.SetActive (true);
	}
	void HideCanvas(CanvasGroup cg) {
		cg.alpha = 0f; //this makes everything transparent
		cg.blocksRaycasts = false; //this prevents the UI element to receive input events
		restart.gameObject.SetActive(false);
	}
}

