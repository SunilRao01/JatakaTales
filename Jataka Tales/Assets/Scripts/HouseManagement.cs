using UnityEngine;
using System.Collections;

public class HouseManagement : MonoBehaviour 
{
	GameObject[] houses;

	// Use this for initialization
	void Awake () 
	{
		houses = GameObject.FindGameObjectsWithTag("House");

		int randomHouse = Random.Range(0, houses.Length);
		for (int i = 0; i < houses.Length; i++)
		{
			if (i == randomHouse)
			{
				houses[i].name = "GoalHouse";
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
