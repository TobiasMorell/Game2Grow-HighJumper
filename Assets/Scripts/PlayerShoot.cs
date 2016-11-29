using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class PlayerShoot : MonoBehaviour
	{
		public KeyCode shootKey;
		public GameObject shotPrefab;

		void Update() {
			if (Input.GetKeyDown (shootKey)) {
				Instantiate (shotPrefab, transform.position, Quaternion.identity);
			}
		}
	}
}

