using UnityEngine;
using System.Collections;

public class GoldenMallard : MonoBehaviour 
{
	public float movementSpeed;

	public Color goalHouseColor;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		Vector2 movementDirection = new Vector2(0, Input.GetAxisRaw("Vertical"));
		movementDirection *= movementSpeed;

		rigidbody2D.AddForce(transform.up * Input.GetAxisRaw("Vertical") * movementSpeed);

		transform.Rotate(new Vector3(0, 0, -Input.GetAxisRaw("Horizontal") * 2));

		GameObject.Find("RadarHouse").GetComponent<SpriteRenderer>().color = goalHouseColor;
	}

	void OnCollisionEnter2D(Collision2D other)
	{

	}

	void OnCollisionExit2D(Collision2D other)
	{

	}
}
