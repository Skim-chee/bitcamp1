#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class Block : MonoBehaviour {
	public Texture2D block1;
	public Texture2D block2;
	public Texture2D nowBlock;
	public Texture2D blockSuccess;
	
	public float secondsPerFrame;
	public float frames;
	public float blockGForce;
	
	private ThalmicMyo myo;
	private Texture2D block;
	private float startTime;
	private bool blocked;
	
	void Start () {
		myo = GameObject.Find("Myo").GetComponent<ThalmicMyo> ();
		startTime = Time.time;
	}
	
	void OnGUI () {
		if (Time.time - startTime < frames * secondsPerFrame) {
			if (Mathf.RoundToInt ((Time.time - startTime) / secondsPerFrame) % 2 == 1) {
				block = block2;
			} else {
				block = block1;
			}
		} else {
			if (!blocked) {
				block = nowBlock;
			} else {
				block = blockSuccess;
			}

			if (Mathf.Abs(myo.accelerometer.y) > blockGForce && Mathf.Abs(myo.accelerometer.x) > (blockGForce/2) && !blocked) {
				blocked = true;
				Debug.Log ("YOUBLOCKING");
				//Debug.Log ("Success");
				StartCoroutine (delay ());
			}
		}
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), block);
	}
	
	IEnumerator delay () {
		yield return new WaitForSeconds (1);
		myo.Vibrate (Thalmic.Myo.VibrationType.Medium);
		yield return new WaitForSeconds (1);
		Debug.Log ("Delayed 1 second");
		yield return null;
		Application.LoadLevel(3);
	}

	
	/*void FixedUpdate () {
		if (myo.pose == Thalmic.Myo.Pose.Fist) {
			Debug.Log ("GET READY TO RUMBLE");
		}
		if (myo.accelerometer.z > 0.5) {
			Debug.Log("YOU PUNCHED");
		}
	}*/
}
