using UnityEngine;
using System.Collections;

public class WinCam : MonoBehaviour {

	public Player p1;
	public Player p2; 

	public int maxHat; 
	public string winner; 
	public int winID;

	public Vector3 camSnap;
	public Vector3 initCam; 
	public float initOrtho; 
	public float zoomOrtho;
	public float aSpeed;
	public float winY; 

	public Moon moon; 
	public bool moonLerped; 

	// Use this for initialization
	void Start () {
		moonLerped = false; 
		initCam = transform.position;
		initOrtho = gameObject.camera.orthographicSize; 
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

		winY = (GameObject.Find (winner)).transform.position.y; 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, winY, transform.position.z), aSpeed * Time.deltaTime);
	}

	void Update()
	{
		if (transform.position.y >= winY - 0.05f) {
			//GameManager.ins.resetGame(); 
			moon.tieLerp = true; 
			if (winID == 0)
			{
				if (moonLerped)
				{
					if (Input.anyKeyDown)
					{
						resetGame (); 
						Application.LoadLevel ("Title_Screen");
					}
				}
			}
			else 
			{
				if (moonLerped)
				{
					resetGame (); 
					if (winID == 1)
					{
						Application.LoadLevel ("p1win");
					}
					else if (winID == 2)
					{
						Application.LoadLevel ("p2win");
					}
				}
			}
		}
	}

	public void resetGame()
	{
		p1.resetPlayer();
		p2.resetPlayer();

		Hat[] hs = GameObject.FindObjectsOfType(typeof(Hat)) as Hat[]; 
		foreach (Hat h in hs)
		{
			Destroy (h.gameObject); 
		}

		winID = 0; 
		moonLerped = false; 
		transform.position = initCam;
		gameObject.camera.orthographicSize = initOrtho;
	}
}
