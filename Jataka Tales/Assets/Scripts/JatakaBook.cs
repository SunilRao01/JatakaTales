using UnityEngine;
using System.Collections;

public class JatakaBook : MonoBehaviour 
{
	private bool hasEntered = false;

	private float promptAlpha;
	public GUIStyle promptStyle;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		if (hasEntered)
		{
			promptAlpha = 1;
		}
		else
		{
			promptAlpha = 0;
		}

		if (hasEntered && Input.GetKeyDown(KeyCode.E))
		{
			// Start jataka tale
			GameObject.Find("Player").GetComponent<FirstPersonDrifter>().lockMovement = true;
			GetComponent<FadeOut>().fade = true;
		}
	}

	void OnGUI()
	{
		Color outColor = Color.black;
		outColor.a = promptAlpha;
		Color inColor = Color.white;
		inColor.a = promptAlpha;

		// Prompt
		GUI.color = new Color(GUI.color.r, GUI.color.b, GUI.color.b, promptAlpha);

		string booktext;

		if (transform.parent.gameObject.name == "Forest: Story 2 Area")
		{
			booktext = "Press E to read the Flight of the Beasts";
		}
		else
		{
			booktext = "Press E to read the Tale of the Golden Mallard";
		}
		ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) - 200, (Screen.height/2) - 200, 400, 400), booktext, promptStyle, inColor, outColor, 1);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			hasEntered = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			hasEntered = false;
		}
	}
}
