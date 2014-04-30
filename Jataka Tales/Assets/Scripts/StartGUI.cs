using UnityEngine;
using System.Collections;

public class StartGUI : MonoBehaviour 
{
	private int currentBooks;
	// Use this for initialization
	void Start () 
	{
		currentBooks = PlayerPrefs.GetInt("books");

		if (currentBooks < 2)
		{
			GameObject.Find("BookNumber").GetComponent<GUIText>().text = currentBooks.ToString() + "/2";
		}
		else
		{
			Destroy(GameObject.Find("BookNumber"));
			Destroy(GameObject.Find("WASD/Mouse"));
			GameObject.Find("Books").GetComponent<GUIText>().fontSize = 64;
			GameObject.Find("Books").GetComponent<GUIText>().text = "Game Over: You read all the books!";

			GameObject.Find("Controls").GetComponent<GUIText>().text = "Thank for Playing";
			GameObject.Find("Spacebar").GetComponent<GUIText>().text = "Press Spacebar to play again";

			PlayerPrefs.DeleteAll();
		}

	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Destroy (gameObject);
		}
	}
}
