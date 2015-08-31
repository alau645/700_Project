﻿using UnityEngine;
using System.Collections;

public class Y2Q4Scene : MonoBehaviour {
	public const string MEASUREMENT_Y2Q4 = "Measurement/Y2/Q4";
	
	private bool displaySettings = false;
	private bool displayHelpButton = false;
	private bool displayRedCross = false;
	private bool displayHelpDialog = false;
	private bool displayStars = false;
	
	private int numIncorrect = 0;
	
	// update data timer
	private float timer = 0.0f;
	private float timerMax = 15.0f;
	
	private float crossTimer = 0.0f;
	private float crossTimerMax = 3.0f;
	
	// textures
	private Texture2D redCross;
	private Texture2D bg;
	private Texture2D star;
	private Texture2D starEmpty;
	//settings & help icon
	private Texture2D settingsIcon;
	private Texture2D helpIcon;

	// answer pool text
	private Texture2D oneText;
	private Texture2D twoText;
	private Texture2D threeText;
	private Texture2D fourText;
	private Texture2D fiveText;
	private Texture2D sixText;
	private Texture2D sevenText;
	private Texture2D eightText;
	private Texture2D nineText;
	
//	private string question = "How many ladybugs long is the blue pencil?";
	
	// Use this for initialization
	void Start () {
		redCross = (Texture2D)Resources.Load("red-cross");
		bg = (Texture2D)Resources.Load("black-bg");
		star = (Texture2D)Resources.Load("pics/Star/Star");
		starEmpty = (Texture2D)Resources.Load("pics/Star/star_empty");
		settingsIcon = (Texture2D)Resources.Load ("pics/cog");
		helpIcon = (Texture2D)Resources.Load ("pics/green_hand");

		oneText = (Texture2D)Resources.Load ("Text/1_2_text");
		twoText = (Texture2D)Resources.Load ("Text/2_2_text");
		threeText = (Texture2D)Resources.Load ("Text/3_2_text");
		fourText = (Texture2D)Resources.Load ("Text/4_2_text");
		fiveText = (Texture2D)Resources.Load ("Text/5_2_text");
		sixText = (Texture2D)Resources.Load ("Text/6_2_text");
		sevenText = (Texture2D)Resources.Load ("Text/7_2_text");
		eightText = (Texture2D)Resources.Load ("Text/8_2_text");
		nineText = (Texture2D)Resources.Load ("Text/9_2_text");
		
		// set current task
		AppManager.Instance.setCurrentTask(MEASUREMENT_Y2Q4);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (displayHelpButton == false && timer >= timerMax) {
			//Debug.Log("timerMax reached!");
			displayHelpButton = true;
		}
		
		if (displayRedCross) {
			crossTimer += Time.deltaTime;
			if (crossTimer >= crossTimerMax) {
				displayRedCross = false;
				crossTimer = 0.0f;
			}
		}
	}
	
	void OnGUI () {
		// settings button
		if (GUI.Button (new Rect (Screen.width * .95f, Screen.height * .0f, Screen.width * .05f, Screen.width * .05f), settingsIcon)) {
			if (displaySettings) {
				displaySettings = false;
			} else {
				displaySettings = true;
			}
		}
		
		// help dialog button (20sec wait) and display astronauts
		if (displayHelpButton) {
			if (GUI.Button (new Rect (Screen.width * .89f, Screen.height * .0f, Screen.width * .05f, Screen.width * .05f), helpIcon)) {
				// TODO don't need help dialog anymore?
				//if (displayHelpDialog) {
				//	displayHelpDialog = false;
				//} else {
				//	displayHelpDialog = true;
				//}
				numIncorrect++;
			}
		}
		
		// answer pool
		if (GUI.Button (new Rect (Screen.width * .05f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), oneText)) {
			displayRedCross = true;
			numIncorrect++;
		}
		
		if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), twoText)) {
			displayRedCross = true;
			numIncorrect++;
		}
		
		if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), threeText)) {
			displayRedCross = true;
			numIncorrect++;
		}
		
		if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), fourText)) {
			displayRedCross = true;
			numIncorrect++;
		}
		
		if (GUI.Button (new Rect (Screen.width * .45f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), fiveText)) {
			displayRedCross = true;
			numIncorrect++;
		}
		
		if (GUI.Button (new Rect (Screen.width * .55f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), sixText)) {
			displayRedCross = true;
			numIncorrect++;
		}
		
		if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), sevenText)) {
			displayRedCross = true;
			numIncorrect++;
		}
		
		if (GUI.Button (new Rect (Screen.width * .75f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), eightText)) {
			displayRedCross = true;
			numIncorrect++;
		}
		
		if (GUI.Button (new Rect (Screen.width * .85f, Screen.height * .83f, Screen.height * .1f, Screen.height * .1f), nineText)) {
			displayStars = true;
			AppManager.Instance.storeNumIncorrect(numIncorrect);
		}
		
		drawRedCross();
		drawSettings();
	}
	
	private void drawSettings () {
		if (displaySettings) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), bg);
			
			GUI.Box (new Rect (Screen.width * .3f, Screen.height * .3f, Screen.width * .4f, Screen.height * .5f), "");
			
			// continue
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .35f, Screen.width * .2f, Screen.height * .1f), "Continue")) {
				displaySettings = false;
			}
			
			// task selection
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .5f, Screen.width * .2f, Screen.height * .1f), "Main Menu")) {
				AppManager.Instance.exitTask(AppManager.MAIN_MENU_SCENE);
			}
			
			// quit
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .65f, Screen.width * .2f, Screen.height * .1f), "Quit")) {
				AppManager.Instance.exitTask(AppManager.TASK_SELECTION_SCENE);
			}
			
			// sound
			AppManager.Instance.sound = GUI.Toggle(new Rect(Screen.width * .0f, Screen.height * .0f, Screen.width * .15f, Screen.height * .07f), AppManager.Instance.sound, "  Sound");
		}
	}
	
	private void drawRedCross () {
		if (displayRedCross) {
			GUI.DrawTexture(new Rect(Screen.width * .25f, Screen.height * .05f, Screen.width * .5f, Screen.width * .5f), redCross);
		}
	}
}