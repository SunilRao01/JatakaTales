using UnityEngine;
using System.Collections;

public class RandomHouse : MonoBehaviour 
{
	public Color randomColor;

	private bool isGoal;

	private bool hasEntered = false;
	private bool fadeAway = false;

	public GameObject audioObject;
	// Use this for initialization
	void Start () 
	{
		randomColor = new Color(Random.Range(0.0f, 1.0f), (Random.Range(0.0f, 1.0f)), (Random.Range(0.0f, 1.0f)), 1);

		GetComponent<SpriteRenderer>().color = randomColor;

		if (gameObject.name == "GoalHouse")
		{
			Debug.Log("Goal House checking itself...");
			isGoal = true;
			GameObject.Find("GoldenMallard").GetComponent<GoldenMallard>().goalHouseColor = randomColor;
			GameObject tempAudio =  (GameObject) Instantiate(audioObject, transform.position, transform.rotation);
			tempAudio.transform.parent = this.gameObject.transform;
		}
		else
		{
			isGoal = false;
		}

		//gameObject.AddComponent<AudioSource>().
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (hasEntered && Input.GetKeyDown(KeyCode.E))
		{
			if (isGoal)
			{
				GameObject.Find("Main Camera").GetComponent<FadeOut>().fade = true;
			}
			else
			{
				fadeAway = true;
			}
		}

		if (fadeAway)
		{
			GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g,
			                                                 GetComponent<SpriteRenderer>().color.b, GetComponent<SpriteRenderer>().color.a - 0.02f);
		}

		if (GetComponent<SpriteRenderer>().color.a <= 0)
		{
			Destroy(gameObject);
		}

		transform.rotation = GameObject.Find("Main Camera").transform.rotation;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			hasEntered = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			hasEntered = false;
		}
	}
}
