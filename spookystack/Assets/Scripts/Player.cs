﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int aHats;
	public int aCandies;
	public int aHouses; 

	// Use this for initialization
	void Start () 
	{
		aHats = 0;
		aCandies = 0; 
		aHouses = 0; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * 
	 * -------------------------------------------------------------------------------------------------------------------- */
	void throwCandy()
	{
		aCandies--;
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * 
	 * -------------------------------------------------------------------------------------------------------------------- */
	void collectCandy()
	{

	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * 
	 * -------------------------------------------------------------------------------------------------------------------- */
	void tradeCandy()
	{

	}
}
