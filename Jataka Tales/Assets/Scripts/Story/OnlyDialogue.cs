using UnityEngine;
using System.Collections;

public struct dialoguePiece
{
	public int person;
	public string dialogueText;
}

public class OnlyDialogue : MonoBehaviour 
{
	// Dialogue Box
	public Texture2D dialogueBoxImage;
	private float _alpha = 0;
	private string dialogue;
	public GUIStyle dialogueStyle;
	public float dialogueWidth;
	public float dialogueHeight;
	
	// Variables
	public bool complete;
	
	// Scrolling Text Effect
	public float letterPause = 0.1f;


	// Text person change
	public Color textColor;

	private string dialogueText;
	
	private bool scrollComplete;
	
	private dialoguePiece[] dialogues;
	public string[] stringArray;
	private int iterator;
	
		

	// Use this for initialization
	void Start() 
	{	
		iterator = 0;
		dialogues = new dialoguePiece[stringArray.Length];
		for (int i = 0; i < stringArray.Length; i++)
		{
			dialogues[i].dialogueText = stringArray[i];
			dialogues[i].person = 0;
		}
		
		complete = false;
		scrollComplete = false;
		
		// Starting dialogue
		dialogue = dialogues[iterator].dialogueText;

		startDialogue();

		// Set dialogue text bounds
		dialogueWidth = (Screen.width) - (2 * (Screen.width/8));
		dialogueHeight = (Screen.height) - (2 * (Screen.height/8));
	}
	
	void Update() 
	{
		if (Input.GetKeyDown(KeyCode.Delete))
		{
			PlayerPrefs.DeleteAll();
		}

		//textColor = Color.white;
		// Make everything alpha==0, complete flag set to true
		if (iterator == stringArray.Length)
		{
			_alpha = 0;
			complete = true;



			iterator = 0;

			if (Application.loadedLevelName == "GoldenMallardNarrative_4" || Application.loadedLevelName == "FOBNarrative_2")
			{
				int currentBooks = PlayerPrefs.GetInt("books");
				currentBooks++;
				PlayerPrefs.SetInt("books", currentBooks);
			}

			GameObject.Find("Main Camera").GetComponent<FadeOut>().fade = true;
		}
		
		if (!complete)
		{
			
			// Handles Input
			if (Input.GetKeyDown(KeyCode.Space) && scrollComplete)
			{
				iterator++;
				dialogueText = "";
				
				if (iterator < stringArray.Length)
				{
					// Change voice actor to position iterator

					dialogue = dialogues[iterator].dialogueText;

					if (GameObject.Find("One shot audio") != null)
					{
						Destroy(GameObject.Find("One shot audio"));
					}
					StartCoroutine(TypeText ());
				}
			}
		}

	}
	
	public void startDialogue()
	{
		_alpha = 1;
		iterator = 0;
		dialogues = new dialoguePiece[stringArray.Length];
		for (int i = 0; i < stringArray.Length; i++)
		{
			dialogues[i].dialogueText = stringArray[i];
			dialogues[i].person = 0;
		}
		
		complete = false;
		scrollComplete = false;
		
		// Starting dialogue
		dialogue = dialogues[iterator].dialogueText;
		
		StartCoroutine(TypeText());

	}
	
	void OnGUI()
	{
		
		// Make GUI visible/invisible
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, _alpha);
		



		// Display Dialogue Box

		GUI.DrawTexture(new Rect(5, 5, Screen.width - 2, Screen.height - 5), dialogueBoxImage);
		//GUI.Box(new Rect((Screen.width/2) - 250, (Screen.height/2) + 150, 600, 120), "");
		
		// Dialogue text
		//ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) - 200, (Screen.height/2) + 170, dialogueWidth, dialogueHeight), dialogueText, dialogueStyle, Color.black, textColor, 4);
		GUI.Label(new Rect((Screen.width/8), (Screen.height/8), dialogueWidth, dialogueHeight), dialogueText, dialogueStyle);
		
	}

	IEnumerator TypeText()
	{
		scrollComplete = false;
		int count = 1;
		
		foreach (char letter in dialogue.ToCharArray()) 
		{
			dialogueText += letter;

			yield return new WaitForSeconds (letterPause);
			
			count++;
		}
		
		scrollComplete = true;
	}
	
	
	
}
