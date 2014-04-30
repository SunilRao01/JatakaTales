using UnityEngine;
using System.Collections;

public class BunnyPlayer : MonoBehaviour 
{
	public float movementSpeed;

	public int animalCount;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		handleInput();

		Debug.Log("Player animal count: " + animalCount.ToString());

		if (animalCount >= 24)
		{
			GameObject.Find("Main Camera").GetComponent<FadeOut>().fade = true;
		}
	}

	void handleInput()
	{
		Vector2 movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		movementDirection *= movementSpeed;

		rigidbody2D.AddForce(movementDirection);
	}
}
