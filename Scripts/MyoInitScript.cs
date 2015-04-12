using UnityEngine;
using System.Collections;

public class MyoInitScript : MonoBehaviour {
	public GameObject myPrefab;
	private static GameObject my;

	void Awake () {
		if (my == null) {
			my = Instantiate (myPrefab) as GameObject;
		}
	}
}
