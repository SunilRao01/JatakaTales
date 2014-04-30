using UnityEngine;
using System.Collections;

public class Animal : MonoBehaviour 
{
	private bool followPlayer = false;
	public float movementSpeed;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		Vector2 playerPosition = GameObject.Find("Player").transform.position - transform.position;
		
		if (followPlayer)
		{
			transform.parent.rigidbody2D.AddForce(playerPosition * movementSpeed);
		}

		Physics2D.IgnoreLayerCollision(8, 9, true);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			followPlayer = true;
			other.GetComponent<BunnyPlayer>().animalCount++;
		}
	}
}
