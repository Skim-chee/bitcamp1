#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class Fist : MonoBehaviour {
	public ThalmicMyo myo;
	public Texture2D fist; 
	public Texture2D fist_success;

	void Start () {
		myo = GameObject.Find("Myo").GetComponent<ThalmicMyo> ();
	}

	void OnGUI () {
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fist);
		if (myo.pose == Thalmic.Myo.Pose.Fist) {
			Debug.Log ("Calling GUI");
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fist_success);
			Debug.Log ("Success");
			StartCoroutine (delay ());
		}
	}

	IEnumerator delay () {
		yield return new WaitForSeconds (1);
		Debug.Log ("Delayed 1 second");
		yield return null;
		Application.LoadLevel(2);
	}

	void FixedUpdate () {
		if (myo.pose == Thalmic.Myo.Pose.Fist) {
			Debug.Log ("GET READY TO RUMBLE");
		}
		if (myo.accelerometer.z > 0.5) {
			Debug.Log("YOU PUNCHED");
		}
	}
}
