#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class FileWriter : MonoBehaviour {
	public ThalmicMyo myo;
	private StreamWriter sw;
	private bool reading = true;

	// Use this for initialization
	void Start () {
		sw = new StreamWriter ("Assets/Data/sample1.txt");
	}
	
	// Update is called once per frame
	void Update () {
		if (reading) {
			sw.WriteLine (myo.accelerometer.ToString ());

			if (Input.GetKeyDown ("space")) {
				reading = false;
				sw.Close ();

				#if UNITY_EDITOR
				AssetDatabase.Refresh ();
				#endif
			}
		}
	}
}
