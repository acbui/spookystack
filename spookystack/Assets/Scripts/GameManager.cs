using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static public GameManager ins;

	public float aTimer; 

	// KEEP TRACK OF 
	public int p1House;
	public int p2House; 

	void Awake () {
		//Setup instance
		DontDestroyOnLoad(this);
		ins = this;
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
}
