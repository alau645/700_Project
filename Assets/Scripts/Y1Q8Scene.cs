﻿using UnityEngine;
using System.Collections;

public class Y1Q8Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q8 = "Measurement/Y1/Q8";
	
	//textures
	private Texture2D hintLine;

	// Use this for initialization
	void Start () {
		hintLine = (Texture2D)Resources.Load("y1q8_hintline");
		
		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q8);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		if (!SettingsDialog.displaySettings) {
			drawHintLine ();
		}
	}

	private void drawHintLine () {
		if (HintButton.displayHint) {
			GUI.DrawTexture(new Rect(Screen.width * .306f, Screen.height * .17f, Screen.width * 0.62f, Screen.height * .7f), hintLine);
		}
	}
}
