using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//static public GameManager ins;

	public Moon moon;
	public WinCam cam;

	public Player p1;
	public Player p2; 

	void Awake () {
		//Setup instance
		//DontDestroyOnLoad(this);
		//ins = this;
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * 
	 * -------------------------------------------------------------------------------------------------------------------- */
	void Start () {
	}
	
	/* --------------------------------------------------------------------------------------------------------------------
	 * 
	 * -------------------------------------------------------------------------------------------------------------------- */
	void Update () 
	{
	
	}

	public void resetGame()
	{
		if (cam.winID == 0)
		{
			moon.tieLerp = true; 
			if (cam.moonLerped)
			{
				if (Input.anyKeyDown)
				{
					cam.resetGame (); 
					Application.LoadLevel ("Title_Screen");
				}
			}
		}
		else 
		{
			if (cam.winID == 1)
			{
				Application.LoadLevel ("p1win");
			}
			else if (cam.winID == 2)
			{
				Application.LoadLevel ("p2win");
			}
		}
		cam.enabled = false;
		p1.enabled = true; 
		p2.enabled = true; 
	}
}
