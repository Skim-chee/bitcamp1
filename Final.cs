#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class Final : MonoBehaviour {
	public Texture2D final; 
	public bool shared = false;
	private ThalmicMyo myo;
	
	void Start () {
		myo = GameObject.Find("Myo").GetComponent<ThalmicMyo> ();
	}

	const string Address = "http://twitter.com/intent/tweet";
	
	public static void Share(string text, string url,
	                         string related, string lang="en")
	{
		Application.OpenURL(Address +
		                    "?text=" + WWW.EscapeURL(text) +
		                    "&amp;url=" + WWW.EscapeURL(url) +
		                    "&amp;related=" + WWW.EscapeURL(related) +
		                    "&amp;lang=" + WWW.EscapeURL(lang));
	}

	void OnGUI () {
		if (myo.pose == Thalmic.Myo.Pose.WaveIn) {
			Application.LoadLevel(0);
		}

		if (myo.pose == Thalmic.Myo.Pose.WaveOut && !shared) {
			shared = true;
			Share("I completed #MyoDefender! 1v1 me @TheRock", "", "", "en"); 
			Application.LoadLevel(0);
		}	
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), final);
	}



	IEnumerator delay () {
		myo.Vibrate (Thalmic.Myo.VibrationType.Short);
		yield return new WaitForSeconds (1);
		Debug.Log ("Delayed 1 second");
		yield return null;
		Application.LoadLevel(0);
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

