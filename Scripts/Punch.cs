#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class Punch : MonoBehaviour {
	public ThalmicMyo myo;
	public Texture2D punch1;
	public Texture2D punch2;
	public Texture2D nowPunch;
	public Texture2D punch_success;

	public float secondsPerFrame;
	public float frames;
	public float punchGForce;

	private Texture2D punch;
	private float startTime;
	
	void Start () {
		myo = GameObject.Find("Myo").GetComponent<ThalmicMyo> ();
		startTime = Time.time;
	}
	
	void OnGUI () {
		if (Time.time - startTime < frames * secondsPerFrame) {
			if (Mathf.RoundToInt ((Time.time - startTime) / secondsPerFrame) % 2 == 1) {
				punch = punch2;
			} else {
				punch = punch1;
			}
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), punch);
		} else {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), nowPunch);
			if (myo.accelerometer.z > punchGForce) {
				Debug.Log ("Calling GUI");
				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), punch_success);
				Debug.Log ("Success");
				StartCoroutine (delay ());
			}
		}
	}
	
	IEnumerator delay () {
		yield return new WaitForSeconds (1);
		Debug.Log ("Delayed 1 second");
		yield return null;
		Application.LoadLevel(3);
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
