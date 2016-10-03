using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		this.GetComponent<Animator> ().GetBehaviour<RemoveAtExit> ().holder = this.gameObject;
	}
}
