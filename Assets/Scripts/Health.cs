using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	public static Health Instance;

	public GameObject heart;

	public int lives;

	private GameObject healthbar;
	private float width = 50;

	// Use this for initialization
	void Start () {
		Instance = this;
		healthbar = GameObject.FindGameObjectWithTag ("Healthbar");

		for (int i = 0; i < lives; i++) {
			var inst = Instantiate (heart);
			inst.transform.SetParent (healthbar.transform, false);
			var rt = inst.GetComponent<RectTransform> ();
			Vector2 pos = new Vector2 (-i * width, 0);
			rt.localPosition = pos;
		}
	}
	
	// Update is called once per frame
	public void LoseLife () {
		lives--;
		Destroy(healthbar.GetComponentsInChildren<Image>()[lives].gameObject);
	}
}
