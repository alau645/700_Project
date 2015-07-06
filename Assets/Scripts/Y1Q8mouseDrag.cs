﻿using UnityEngine;
using System.Collections;

public class Y1Q8mouseDrag : MonoBehaviour {

	static bool slot1 = false;
	static bool slot2 = false;
	static bool slot3 = false;
	static bool slot4 = false;

	private bool displayStars = false;
	private bool displayRedCross = false;
	private int numIncorrect = 0;
	
	private float crossTimer = 0.0f;
	private float crossTimerMax = 3.0f;
	
	// Y positions 0.2, 0.4, 0.6, 0.8
	static float curPinkPencilPos;
	static float curYellowPencilPos;
	static float curGreenPencilPos;
	static float curBluePencilPos;
	static float swapPos;
	
	float distance = 1.0f;
	Vector3 objPosition;
	
	Vector3 currentPosition;
	float startX;
	float startY;
	float startZ;

	private Texture2D star;
	private Texture2D starEmpty;
	private Texture2D redCross;
	
	// Use this for initialization
	void Start () {
		currentPosition = transform.position;
		startX = currentPosition.x;
		startY = currentPosition.y;
		startZ = currentPosition.z;
		
		if (startZ == 1.0f) { // yellow
			curPinkPencilPos = currentPosition.y;
		} else if (startZ == 2.0f) { // green
			curYellowPencilPos = currentPosition.y;
		} else if (startZ == 3.0f) { // blue
			curGreenPencilPos = currentPosition.y;
		} else if (startZ == 4.0f) { // pink
			curPinkPencilPos = currentPosition.y;
		}

		star = (Texture2D)Resources.Load("pics/Star/Star");
		starEmpty = (Texture2D)Resources.Load("pics/Star/star_empty");
		redCross = (Texture2D)Resources.Load("red-cross");
	}
	
	// Update is called once per frame
	void Update () {
		if (currentPosition.y == 0.8f) {
			if (currentPosition.z == 1.0f) { // yellow
				slot1 = true;;
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
		
		if (displayRedCross) {
			crossTimer += Time.deltaTime;
			if (crossTimer >= crossTimerMax) {
				displayRedCross = false;
				crossTimer = 0.0f;
			}
		}
	}
	
	void OnMouseDrag () {
		//Vector3 mousePosition = new Vector3(Input.mousePosition.x + 130.0f, Input.mousePosition.y - 140.0f, distance);
		
		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
		//mousePosition.z = transform.position.z;
		
		objPosition	= Camera.main.ScreenToViewportPoint(mousePosition);
		objPosition.z = 5.0f;
		
		transform.position = objPosition;
	}
	
	void OnGUI () {
		if (GUI.Button (new Rect (Screen.width * .15f, Screen.height * .45f, Screen.width * .2f, Screen.height * .1f), "Done!")) {
			if (slot1 == true && slot2 == true && slot3 == true) {
				displayStars = true;
			} else {
				numIncorrect++;
				displayRedCross = true;
			}
		}
		
		drawStars();
		drawRedCross();
	}
	
	void OnMouseUp () {		
		if (transform.position.y > 0.1f & transform.position.y < 0.29f) { // slot 1
			//changePos(0.3f);
			transform.position = new Vector3(startX, 0.2f, startZ);
			currentPosition = transform.position;
		} else if (transform.position.y > 0.3f & transform.position.y < 0.49f) { // slot 2
			//changePos(0.5f);
			transform.position = new Vector3(startX, 0.4f, startZ);
			currentPosition = transform.position;
		} else if (transform.position.y > 0.5f & transform.position.y < 0.69f) { // slot 3
			//changePos(0.7f);
			transform.position = new Vector3(startX, 0.6f, startZ);
			currentPosition = transform.position;
		} else if (transform.position.y > 0.7f & transform.position.y < 0.89f) { // slot 3
			//changePos(0.7f);
			transform.position = new Vector3(startX, 0.8f, startZ);
			currentPosition = transform.position;
		} else { // not valid drop slot, move back to before slot.
			transform.position = currentPosition;
		}
	}

	private void drawRedCross () {
		if (displayRedCross) {
			GUI.DrawTexture(new Rect(Screen.width * .25f, Screen.height * .05f, Screen.width * .5f, Screen.width * .5f), redCross);
		}
	}
	
	private void drawStars () {
		if (displayStars) {
			GUI.Box (new Rect (Screen.width * .3f, Screen.height * .25f, Screen.width * .4f, Screen.height * .5f), "Completed");
			
			GUI.DrawTexture(new Rect(Screen.width * .35f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), star);
			
			if (numIncorrect == 1) {
				GUI.DrawTexture(new Rect(Screen.width * .45f, Screen.height * .4f, Screen.width * .1f, Screen.width * .1f), star);
				GUI.DrawTexture(new Rect(Screen.width * .55f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), starEmpty);
			} else if (numIncorrect >= 2) {
				GUI.DrawTexture(new Rect(Screen.width * .45f, Screen.height * .4f, Screen.width * .1f, Screen.width * .1f), starEmpty);
				GUI.DrawTexture(new Rect(Screen.width * .55f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), starEmpty);
			} else {
				GUI.DrawTexture(new Rect(Screen.width * .45f, Screen.height * .4f, Screen.width * .1f, Screen.width * .1f), star);
				GUI.DrawTexture(new Rect(Screen.width * .55f, Screen.height * .35f, Screen.width * .1f, Screen.width * .1f), star);
			}
			
			// ok
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .6f, Screen.width * .2f, Screen.height * .1f), "OK")) {
				AppManager.Instance.exitTask(AppManager.TASK_SELECTION_SCENE);
			}
		}
	}
}
