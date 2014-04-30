using UnityEngine;
using System.Collections;

public class FinishedCamera : MonoBehaviour 
{
	// Get position of floor to calculate distance of camera view
	public Transform floor;
	
	
	// Various variables to handle positioning
	private float x = 0.0f;
	private float xSmooth = 0.0f;
	private float xVelocity = 0.0f;
	
	private float smoothTime = 0.3f;
	private Vector3 posSmooth = Vector3.zero;
	private Vector3 posVelocity = Vector3.zero;
	public float yCameraAngle;
	public float distance;
	
	public GUIStyle labelStyle;
	
	private Camera secondaryCamera;

	public bool enable;


	// Use this for initialization
	void Start () 
	{
		if (!enable)
		{
			Destroy(gameObject);
		}

		secondaryCamera = gameObject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Destroy(gameObject);
		}
	}
	
	void LateUpdate()
	{
		// IMPORTANT
		// Handles the positioning of the camera
		if (floor) 
		{
	        Vector3 mousePos = Input.mousePosition;
			mousePos.x -= Screen.width/2;
			mousePos.y -= Screen.height/2;
			
			// Create camrea dead zone at center, must move mouse to edges to look around (makes for a better feel)
			x += 1;
				 			
	        xSmooth = Mathf.SmoothDamp(xSmooth, x, ref xVelocity, smoothTime);
	 
	        var rotation = Quaternion.Euler(yCameraAngle, xSmooth, 0);
	 
	        posSmooth = Vector3.SmoothDamp(posSmooth, floor.position, ref posVelocity, smoothTime);
	 
	        posSmooth = floor.position; // no follow smoothing
	 
	        transform.rotation = rotation;
	        transform.position = rotation * (new Vector3(0.0f, 0.0f, -distance)) + posSmooth;
		}
	}
	
	// IMPORTANT
	// Helper function for the positioning of the camera
	static float ClampAngle (float angle, float min, float max) 
	{
	    if (angle < -360)
		{
	        angle += 360;
		}
	    if (angle > 360)
		{
	        angle -= 360;
		}
		
	    return Mathf.Clamp (angle, min, max);
	}

	void OnGUI()
	{
		// Shows stats

	}
}















