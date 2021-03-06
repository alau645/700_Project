﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Y1 q7mouse drag for the pencils.
/// </summary>
public class Y1Q7mouseDrag : MonoBehaviour {

	static bool slot1 = false;
	static bool slot2 = false;
	static bool slot3 = false;
	
	// Y positions 0.3, 0.5, 0.7

	private bool displaySquiggles = false;

	private float squigglesTimer = 0.0f;
	private const float squigglesTimerMax = 5.0f;
	
	float distance = 1.0f;
	Vector3 objPosition;
	
	Vector3 currentPosition;
	float startX;
	float startY;
	float startZ;

	private Texture2D squigglyLine;

	// finished text
	private Texture2D finishedText;
	
	// Use this for initialization
	void Start () {
		slot1 = false;
		slot2 = false;
		slot3 = false;

		currentPosition = transform.position;
		startX = currentPosition.x;
		startY = currentPosition.y;
		startZ = currentPosition.z;

		squigglyLine = (Texture2D)Resources.Load ("pics/squiggle_left");

		finishedText = (Texture2D)Resources.Load ("Text/finished_text");
	}
	
	// Update is called once per frame
	void Update () {
		if (currentPosition.y == 0.3f) {
			if (currentPosition.z == 1.0f) { // pink z=1
				slot1 = true;
			} else {
				slot1 = false;
			}
		} else if (currentPosition.y == 0.5f) {
			if (currentPosition.z == 2.0f) { // yellow z=2
				slot2 = true;
			} else {
				slot2 = false;
			}
		} else if (currentPosition.y == 0.7f) {
			if (currentPosition.z == 3.0f) { // green z=3
				slot3 = true;
			} else {
				slot3 = false;
			}
		}

		// show squiggly lines as instant feedback for 5 seconds
		if (displaySquiggles) {
			squigglesTimer += Time.deltaTime;
			if (squigglesTimer >= squigglesTimerMax) {
				displaySquiggles = false;
				squigglesTimer = 0.0f;
			}
		}
	}

	void OnMouseDrag () {
		if (!StarDialog.displayStars && !SettingsDialog.displaySettings) {
			// drag logic
			Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		
			objPosition = Camera.main.ScreenToViewportPoint (mousePosition);
			objPosition.z = 5.0f;
		
			transform.position = objPosition;
		}
	}
	
	void OnGUI () {
		if (!SettingsDialog.displaySettings && !StarDialog.displayStars) {
			// finished button
			if (GUI.Button (new Rect (Screen.width * .65f, Screen.height * .45f, Screen.width * .2f, Screen.height * .1f), finishedText)) {
				displaySquiggles = true;
				// correct answer
				if (slot1 == true && slot2 == true && slot3 == true) {
					StarDialog.displayStars = true;
					AppManager.Instance.addCompletedTask (Y1Q7Scene.MEASUREMENT_Y1Q7, StarDialog.numIncorrect, HintButton.hintUsed);
				} else {
					StarDialog.numIncorrect++;
					IncorrectDialog.displayIncorrectDialog = true;
				}
			}

			drawSquigglyLines ();
		}
	}
	
	void OnMouseUp () {		
		if (transform.position.y > 0.2f & transform.position.y < 0.39f) { // slot 1
			transform.position = new Vector3(startX, 0.3f, startZ);
			currentPosition = transform.position;
		} else if (transform.position.y > 0.4f & transform.position.y < 0.59f) { // slot 2
			transform.position = new Vector3(startX, 0.5f, startZ);
			currentPosition = transform.position;
		} else if (transform.position.y > 0.6f & transform.position.y < 0.79f) { // slot 3
			transform.position = new Vector3(startX, 0.7f, startZ);
			currentPosition = transform.position;
		} else { // not valid drop slot, move back to before slot.
			transform.position = currentPosition;
		}
	}

	/// <summary>
	/// Draws the squiggly lines - instant feedback.
	/// </summary>
	private void drawSquigglyLines () {
		if (displaySquiggles) {
			if (slot1)
				GUI.DrawTexture (new Rect (Screen.width * .5f, Screen.height * .625f, Screen.width * .2f, Screen.height * .1f), squigglyLine);

			if (slot2)
				GUI.DrawTexture (new Rect (Screen.width * .4f, Screen.height * .425f, Screen.width * .2f, Screen.height * .1f), squigglyLine);

			if (slot3)
				GUI.DrawTexture (new Rect (Screen.width * .3f, Screen.height * .225f, Screen.width * .2f, Screen.height * .1f), squigglyLine);
		}
	}
}