using UnityEngine;
using System.Collections;

/// <summary>
/// Counter for Y1 - Q9, 10, 11, 12.
/// </summary>
public class Counter : MonoBehaviour
{
	public static int counter = 0;

	// position of the counter
	public float xPos = 0.0f;
	public float yPos = 0.0f;

	// images of text 0 to 10
	private Texture2D zeroText;
	private Texture2D oneText;
	private Texture2D twoText;
	private Texture2D threeText;
	private Texture2D fourText;
	private Texture2D fiveText;
	private Texture2D sixText;
	private Texture2D sevenText;
	private Texture2D eightText;
	private Texture2D nineText;
	private Texture2D tenText;

	private Texture2D textToDisplay;

	// Use this for initialization
	void Start ()
	{
		counter = 0;

		zeroText = (Texture2D)Resources.Load ("Text/0_text");
		oneText = (Texture2D)Resources.Load ("Text/1_text");
		twoText = (Texture2D)Resources.Load ("Text/2_text");
		threeText = (Texture2D)Resources.Load ("Text/3_text");
		fourText = (Texture2D)Resources.Load ("Text/4_text");
		fiveText = (Texture2D)Resources.Load ("Text/5_text");
		sixText = (Texture2D)Resources.Load ("Text/6_text");
		sevenText = (Texture2D)Resources.Load ("Text/7_text");
		eightText = (Texture2D)Resources.Load ("Text/8_text");
		nineText = (Texture2D)Resources.Load ("Text/9_text");
		tenText = (Texture2D)Resources.Load ("Text/10_text");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnGUI ()
	{
		textToDisplay = zeroText;

		if (counter == 0)
			textToDisplay = zeroText;
		else if (counter == 1)
			textToDisplay = oneText;
		else if (counter == 2)
			textToDisplay = twoText;
		else if (counter == 3)
			textToDisplay = threeText;
		else if (counter == 4)
			textToDisplay = fourText;
		else if (counter == 5)
			textToDisplay = fiveText;
		else if (counter == 6)
			textToDisplay = sixText;
		else if (counter == 7)
			textToDisplay = sevenText;
		else if (counter == 8)
			textToDisplay = eightText;
		else if (counter == 9)
			textToDisplay = nineText;
		else if (counter == 10)
			textToDisplay = tenText;

		GUI.Box (new Rect (Screen.width * xPos, Screen.height * yPos, Screen.height * .11f, Screen.height * .11f), textToDisplay);
	}
}

