using UnityEngine;
using System.Collections;

public class TitleFade : MonoBehaviour 
{
	public float fadeInterval;
	public float middleInterval;
	public float middleInterval2;
	public float middleInterval3;

	private float _alpha;

	void Start () 
	{
		guiText.color = new Color(guiText.color.r, guiText.color.g, guiText.color.b, 0);
		_alpha = 0;

		StartCoroutine(fade());
	}
	
	void Update () 
	{
		guiText.color = new Color(guiText.color.r, guiText.color.g, guiText.color.b, _alpha);
	}

	IEnumerator fadeWithMessage(string message, float interval)
	{


		yield return new WaitForSeconds (interval);
	}

	IEnumerator fade()
	{
		yield return new WaitForSeconds (fadeInterval);

		while (_alpha < 1)
		{

			_alpha += 0.01f * Time.deltaTime;
		}

		yield return new WaitForSeconds(middleInterval);

		while (_alpha > 0)
		{
			_alpha -= 0.01f * Time.deltaTime;
		}

		yield return new WaitForSeconds(middleInterval);

		guiText.text = "Controls: (W,A,S,D or Arrow Keys) + (E)";

		if (Application.loadedLevelName == "FOB_1")
		{
			guiText.text = "Controls: (W,A,S,D or Arrow Keys)";
		}
		guiText.fontSize = 48;

		while (_alpha < 1)
		{
			_alpha += 0.01f * Time.deltaTime;
		}

		yield return new WaitForSeconds(middleInterval2);

		while (_alpha > 0)
		{
			_alpha -= 0.01f * Time.deltaTime;
		}


	}
}
