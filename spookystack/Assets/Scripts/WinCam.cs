using UnityEngine;
using System.Collections;

public class WinCam : MonoBehaviour {

	public Player p1;
	public Player p2; 

	public int maxHat; 
	public string winner; 
	public int winID;

	public Vector3 camSnap;
	public float zoomOrtho;
	public float aSpeed;
	Transform winh; 

	// Use this for initialization
	void Start () {
		transform.position = camSnap; 
		gameObject.camera.orthographicSize = zoomOrtho;
		if (p1.aHats > p2.aHats)
		{
			maxHat = p1.aHats;
			winner = "P1Hat " + maxHat; 
			winID = 1; 
		}
		else if (p1.aHats < p2.aHats)
		{
			maxHat = p2.aHats;
			winner = "P2Hat " + maxHat; 
			winID = 2; 
		}
		else 
		{
			maxHat = p1.aHats;
			winner = "P1Hat " + maxHat; 
			winID = 0; 
		}

		winh = (GameObject.Find (winner)).transform; 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, winh.position.y, transform.position.z), aSpeed * Time.deltaTime);
	}

	void Update()
	{
		if (transform.position.y >= winh.position.y - 0.05f) {
			if (winID == 1)
			{
				Application.LoadLevel ("p1win");
			}
			else if (winID == 2)
			{
				Application.LoadLevel ("p2win");
			}
			else 
			{
				if (Input.anyKeyDown)
				{
					Application.LoadLevel ("Title_Screen");
				}
			}
		}
	}
}
