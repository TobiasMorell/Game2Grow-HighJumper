using UnityEngine;
using System.Collections;

public class RemoveAtExit : StateMachineBehaviour {
	public GameObject holder;

	void OnStateExit() {
		Destroy (holder);
	}
}
