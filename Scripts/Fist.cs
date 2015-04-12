#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class Fist : MonoBehaviour {
	public Texture2D fist_go; 
	public Texture2D fist_success;

	private ThalmicMyo myo;
	private Texture2D fist;
	private bool madeFist;

	void Awake () {
		myo = GameObject.Find("Myo").GetComponent<ThalmicMyo> ();
		fist = fist_go;
	}

	void OnGUI () {
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fist);
		if (myo.pose == Thalmic.Myo.Pose.Fist && !madeFist) {
			madeFist = true;
			fist = fist_success;
			Debug.Log ("Calling GUI");
			Debug.Log ("Success");
			StartCoroutine (delay ());
		}
	}

	IEnumerator delay () {
		myo.Vibrate (Thalmic.Myo.VibrationType.Short);
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
