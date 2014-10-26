using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static public GameManager ins;

	public Moon moon;
	public WinCam cam;

	public Player p1;
	public Player p2; 

	public GameObject p1Prefab;
	public GameObject p2Prefab;
	public GameObject moonPrefab;
	public GameObject camPrefab; 

	void Awake () {
		//Setup instance
		DontDestroyOnLoad(this);
		ins = this;
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * 
	 * -------------------------------------------------------------------------------------------------------------------- */
	void Start () {
		createGame();
	}
	
	/* --------------------------------------------------------------------------------------------------------------------
	 * 
	 * -------------------------------------------------------------------------------------------------------------------- */
	void Update () 
	{
	
	}

	public void createGame()
	{
		GameObject player1 = Instantiate (p1Prefab) as GameObject;
		GameObject player2 = Instantiate (p2Prefab) as GameObject;

		player1.name = "Player1";
		player2.name = "Player2";

		p1 = player1.GetComponent<Player>();
		p2 = player2.GetComponent<Player>(); 

		House[] hs = GameObject.FindObjectsOfType(typeof(House)) as House[]; 
		foreach (House h in hs)
		{
			if (h.gameObject.name.Contains ("P1"))
			{
				h.aPlayer = p1;
			}
			else if (h.gameObject.name.Contains ("P2"))
			{
				h.aPlayer = p2;
			}
		}

		GameObject m = Instantiate (moonPrefab) as GameObject;
		GameObject mainCam = Instantiate (camPrefab) as GameObject; 

		m.name = "Moon";
		mainCam.name = "Main Camera";

		Labels labs = mainCam.GetComponent<Labels>();
		labs.Label1 = (GameObject.Find ("P1_Text")).GetComponent<TextMesh>();
		labs.Label2 = (GameObject.Find ("P2_Text")).GetComponent<TextMesh>();
		labs.P1 = player1;
		labs.P2 = player2; 

		moon = m.GetComponent<Moon>();
		cam = mainCam.GetComponent<WinCam>();

		moon.cam = cam; 
		cam.p1 = p1;
		cam.p2 = p2; 
		cam.moon = moon; 

		moon.enabled = true; 
		foreach (House h in hs)
		{
			h.enabled = true; 
		}
		p1.enabled = true; 
		p2.enabled = true; 

	}

	public void endGame()
	{
		moon.tieLerp = true;
		if (cam.moonLerped)
		{
			if (cam.winID == 0)
			{ 
				if (Input.anyKeyDown)
				{
					destroyEverything();
					Application.LoadLevel ("Title_Screen");
				}
			}
			else 
			{
				destroyEverything();
				if (cam.winID == 1)
				{
					Application.LoadLevel ("p1win");
				}
				else if (cam.winID == 2)
				{
					Application.LoadLevel ("p2win");
				}
			}
		}
		cam.enabled = false;
		p1.enabled = true; 
		p2.enabled = true; 
	}

	void destroyEverything()
	{
		Destroy (cam.gameObject);
		Destroy (p1.gameObject);
		Destroy (p2.gameObject);
		Destroy (moon.gameObject);
	}
}
