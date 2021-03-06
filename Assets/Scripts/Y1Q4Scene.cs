﻿using UnityEngine;
using System.Collections;
/// <summary>
/// Script for game logics of task 4.
/// </summary>
public class Y1Q4Scene : MonoBehaviour {
	public const string MEASUREMENT_Y1Q4 = "Measurement/Y1/Q4";

	//textures
	private Texture2D hintLine;

	// Use this for initialization
	void Start () {
		hintLine = (Texture2D)Resources.Load("y1q2_line");
		
		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y1Q4);
		AppManager.Instance.setCurrentTaskYearAndNumber (1, 4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		if (!SettingsDialog.displaySettings && !StarDialog.displayStars) {
			drawHintLine ();
		}
	}
	/// <summary>
	/// Draws the hint line.
	/// </summary>
	private void drawHintLine () {
		if (HintButton.displayHint) {
			GUI.DrawTexture(new Rect(Screen.width * .0f, Screen.height * .1f, Screen.width * 1.0f, Screen.height * 1.0f), hintLine);
		}
	}
}
