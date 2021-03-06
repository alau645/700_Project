﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Star dialog: the completion dialog which is shown in all task scenes upon completion.
/// </summary>
public class StarDialog : MonoBehaviour {

	public static int guiDepth = -10; // infront

	public static bool displayStars = false;
	public static int numIncorrect = 0;
	public static bool helpNeededUpdated = false;

	private Texture2D star;
	private Texture2D starEmpty;
	private Texture2D blobCorrect;

	private Texture2D excellentText;
	private Texture2D goodText;
	private Texture2D completedText;

	private Texture2D menuText;
	private Texture2D nextText;

	// Use this for initialization
	void Start () {
		displayStars = false;
		numIncorrect = 0;

		star = (Texture2D)Resources.Load("pics/Star/Star");
		starEmpty = (Texture2D)Resources.Load("pics/Star/star_empty");
		blobCorrect = (Texture2D)Resources.Load ("correct");

		excellentText = (Texture2D)Resources.Load ("Text/excellent_text");
		goodText = (Texture2D)Resources.Load ("Text/good_text");
		completedText = (Texture2D)Resources.Load ("Text/completed_text");

		menuText = (Texture2D)Resources.Load ("Text/menu_text");
		nextText = (Texture2D)Resources.Load ("Text/next_text");
	}
	
	// Update is called once per frame
	void Update () {
		// set helped need for student if num incorrect is >= 3 and hint is used
		if (numIncorrect >= 3 && HintButton.hintUsed && !helpNeededUpdated) {
			AppManager.Instance.setHelpNeeded(true);
			helpNeededUpdated = true;
		}
	}

	void OnGUI () {
		GUI.depth = guiDepth;

		if (displayStars) {
			GUI.Box (new Rect (Screen.width * .3f, Screen.height * .25f, Screen.width * .4f, Screen.height * .5f), "");
			
			GUI.DrawTexture(new Rect(Screen.width * .35f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), star);

			// 2 stars if number of incorrect attempts == 1
			if (numIncorrect == 1) {
				GUI.DrawTexture(new Rect (Screen.width * .4f, Screen.height * .25f, Screen.width * .2f, Screen.height * .1f), goodText);
				GUI.DrawTexture(new Rect(Screen.width * .45f, Screen.height * .4f, Screen.width * .1f, Screen.width * .1f), star);
				GUI.DrawTexture(new Rect(Screen.width * .55f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), starEmpty);
			// 1 star if number of incorrect attempts >= 2
			} else if (numIncorrect >= 2) {
				GUI.DrawTexture(new Rect (Screen.width * .3f, Screen.height * .25f, Screen.width * .4f, Screen.height * .1f), completedText);
				GUI.DrawTexture(new Rect(Screen.width * .45f, Screen.height * .4f, Screen.width * .1f, Screen.width * .1f), starEmpty);
				GUI.DrawTexture(new Rect(Screen.width * .55f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), starEmpty);
			// 3 stars if number of incorrect attempts == 1
			} else {
				GUI.DrawTexture(new Rect (Screen.width * .3f, Screen.height * .25f, Screen.width * .4f, Screen.height * .1f), excellentText);
				GUI.DrawTexture(new Rect(Screen.width * .45f, Screen.height * .4f, Screen.width * .1f, Screen.width * .1f), star);
				GUI.DrawTexture(new Rect(Screen.width * .55f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), star);
			}
			
			// menu button
			if (GUI.Button (new Rect (Screen.width * .3125f, Screen.height * .6f, Screen.width * .18f, Screen.height * .1f), menuText)) {
				AppManager.Instance.exitTask(AppManager.TASK_SELECTION_SCENE);
			}

			// next button
			if (GUI.Button (new Rect (Screen.width * .5075f, Screen.height * .6f, Screen.width * .18f, Screen.height * .1f), nextText)) {
				AppManager.Instance.nextTask();
			}
			// red blob buddy guy
			GUI.DrawTexture(new Rect (Screen.width * .70f, Screen.height * .28f, Screen.width * .22f, Screen.height * .25f), blobCorrect);
		}
	}
}
