#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class OpeningScript : MonoBehaviour {
	private ThalmicMyo myo;
	public Texture2D OpeningLevel;

	void Start () {
		myo = GameObject.Find("Myo").GetComponent<ThalmicMyo> ();
	}

	void OnGUI ()
	{

		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), OpeningLevel);

		GUI.skin.label.fontSize = 20;
		
		ThalmicHub hub = ThalmicHub.instance;
		
		// Access the ThalmicMyo script attached to the Myo object.
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		
		if (!hub.hubInitialized) {
			GUI.Label(new Rect (12, 8, Screen.width, Screen.height),
			          "Cannot contact Myo Connect. Is Myo Connect running?\n" +
			          "Press Q to try again."
			          );
		} else if (!thalmicMyo.isPaired) {
			GUI.Label(new Rect (12, 8, Screen.width, Screen.height),
			          "No Myo currently paired."
			          );
		} else if (!thalmicMyo.armSynced) {
			GUI.Label(new Rect (12, 8, Screen.width, Screen.height),
			          "Perform the Sync Gesture."
			          );
		} else {
			GUI.Label (new Rect (12, 8, Screen.width, Screen.height),
			         ""
			           );
		}
	}
	
	
	void Update () {
		Debug.Log (myo.pose);
		if (myo.pose == Thalmic.Myo.Pose.WaveOut) {
			Debug.Log("HEY WAVED");
			Application.LoadLevel(1);
		}
	}
}
