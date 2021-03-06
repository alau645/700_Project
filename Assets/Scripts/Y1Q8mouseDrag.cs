﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Y1 q8mouse drag for pencils.
/// </summary>
public class Y1Q8mouseDrag : MonoBehaviour {
	
	static bool slot1 = false;
	static bool slot2 = false;
	static bool slot3 = false;
	static bool slot4 = false;

	private bool displaySquiggles = false;

	private float squigglesTimer = 0.0f;
	private const float squigglesTimerMax = 5.0f;
	
	// Y positions 0.2, 0.4, 0.6, 0.8
	
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
		slot4 = false;

		currentPosition = transform.position;
		startX = currentPosition.x;
		startY = currentPosition.y;
		startZ = currentPosition.z;

		squigglyLine = (Texture2D)Resources.Load ("pics/squiggle_right");

		finishedText = (Texture2D)Resources.Load ("Text/finished_text");
	}
	
	// Update is called once per frame
	void Update () {
		if (currentPosition.y == 0.8f) {
			if (currentPosition.z == 1.0f) { // yellow
				slot1 = true;
			} else {
				slot1 = false;
			}
		} else if (currentPosition.y == 0.6f) {
			if (currentPosition.z == 2.0f) { // green
				slot2 = true;
			} else {
				slot2 = false;
			}
		} else if (currentPosition.y == 0.4f) {
			if (currentPosition.z == 3.0f) { // blue
				slot3 = true;
			} else {
				slot3 = false;
			}
		} else if (currentPosition.y == 0.2f) {
			if (currentPosition.z == 4.0f) { // pink
				slot4 = true;
			} else {
				slot4 = false;
			}
		}

		// instant feedback, draw squiggly line next to pencils in correct positions for 5 seconds
		if (displaySquiggles) {
			squigglesTimer += Time.deltaTime;
			if (squigglesTimer >= squigglesTimerMax) {
				displaySquiggles = false;
				squigglesTimer = 0.0f;
			}
		}
	}
	
	void OnMouseDrag () {
		if (!StarDialog.displayStars  && !SettingsDialog.displaySettings) {
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
			if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .45f, Screen.width * .2f, Screen.height * .1f), finishedText)) {
				displaySquiggles = true;
				// correct answer
				if (slot1 == true && slot2 == true && slot3 == true) {
					StarDialog.displayStars = true;
					AppManager.Instance.addCompletedTask (Y1Q8Scene.MEASUREMENT_Y1Q8, StarDialog.numIncorrect, HintButton.hintUsed);
				} else {
					StarDialog.numIncorrect++;
					IncorrectDialog.displayIncorrectDialog = true;
				}
			}

			drawSquigglyLines ();
		}
	}
	
	void OnMouseUp () {		
		if (transform.position.y > 0.1f & transform.position.y < 0.29f) { // slot 1
			transform.position = new Vector3(startX, 0.2f, startZ);
			currentPosition = transform.position;
		} else if (transform.position.y > 0.3f & transform.position.y < 0.49f) { // slot 2
			transform.position = new Vector3(startX, 0.4f, startZ);
			currentPosition = transform.position;
		} else if (transform.position.y > 0.5f & transform.position.y < 0.69f) { // slot 3
			transform.position = new Vector3(startX, 0.6f, startZ);
			currentPosition = transform.position;
		} else if (transform.position.y > 0.7f & transform.position.y < 0.89f) { // slot 3
			transform.position = new Vector3(startX, 0.8f, startZ);
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
				GUI.DrawTexture (new Rect (Screen.width * .235f, Screen.height * .15f, Screen.width * .2f, Screen.height * .1f), squigglyLine);
		
			if (slot2)
				GUI.DrawTexture (new Rect (Screen.width * .335f, Screen.height * .35f, Screen.width * .2f, Screen.height * .1f), squigglyLine);
		
			if (slot3)
				GUI.DrawTexture (new Rect (Screen.width * .435f, Screen.height * .55f, Screen.width * .2f, Screen.height * .1f), squigglyLine);

			if (slot4)
				GUI.DrawTexture (new Rect (Screen.width * .535f, Screen.height * .75f, Screen.width * .2f, Screen.height * .1f), squigglyLine);
		}
	}
}
