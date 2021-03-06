﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int aHats;
	public int aCandies;
	public int aHouses; 
	public int aID; 
	
	public GameObject aDealerPrefab; 
	public GameObject aCandyPrefab;
	public GameObject aHousePrefab; 
	public GameObject aHatPrefab; 
	public bool aChangingHouses; 

	public string aHousePrefix; 
	public Vector3 aHousePos; 
	public Vector3 aHatPos; 
	public float aHatInc; 
	public float aDelay;

	public Vector3 aCandyPos; 

	public int minCandies;
	public int maxCandies; 

	public AudioClip[] clips; 

	public float currentFrame; 
	public float coolDown; 

	public float candyFrame;
	public float coolCandy; 

	// Use this for initialization
	void Start () 
	{
		aHats = 0;
		aCandies = 0; 
		aHouses = 2; 
		currentFrame = 10;
		candyFrame = 0; 
		aChangingHouses = false; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentFrame++; 
		candyFrame++; 
		if (aID == 1)
		{
			if (currentFrame >= coolDown){
				if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown (KeyCode.A)) && !(Input.GetMouseButtonDown (2) || Input.GetKeyDown (KeyCode.W)))
				{
					collectCandy();
					makeDealer();
					currentFrame = 0;
				} 
			}

			if (candyFrame >= coolCandy){
				if ((Input.GetMouseButtonDown(2) || Input.GetKeyDown (KeyCode.W)) && !(Input.GetMouseButtonDown (0) || Input.GetKeyDown(KeyCode.A)))
				{
					if (aCandies > 0)
						throwCandy();
					candyFrame = 0;
				}
			}
		}
		else if (aID == 2)
		{
			if (currentFrame >= coolDown){
				if (Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown (KeyCode.UpArrow))
				{
					collectCandy();
					makeDealer();
					currentFrame = 0;
				}
			}

			if (candyFrame >= coolCandy){
				if (Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.LeftArrow))
				{
					if (aCandies > 0)
						throwCandy();
					candyFrame = 0;
				}
			}
		}
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * 
	 * -------------------------------------------------------------------------------------------------------------------- */
	void throwCandy()
	{
		audio.PlayOneShot (clips [2]);
		aCandies--;
		Instantiate (aCandyPrefab, aCandyPos, Quaternion.identity); 
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * COLLECT CANDY:
	 * - 
	 * -------------------------------------------------------------------------------------------------------------------- */
	void collectCandy()
	{
		aCandies += Random.Range (minCandies, maxCandies+1); 
		changeHouse(); 
		aHouses++;
	}

	void changeHouse()
	{
		audio.PlayOneShot(clips[0]);
		aChangingHouses = true; 
		House[] hs = GameObject.FindObjectsOfType(typeof(House)) as House[];
		foreach (House h in hs)
		{
			if (h.name.Contains(aHousePrefix))
				h.shiftHouse(); 
		}
		Invoke ("makeHouse", aDelay); 
	}

	public void makeHouse()
	{
		GameObject newHouse = Instantiate (aHousePrefab) as GameObject;
		House houseScript = newHouse.GetComponent<House>();
		houseScript.aPlayer = this; 
		houseScript.setColour(); 
		houseScript.gameObject.name = houseScript.aNamePrefix + 3;
		houseScript.aShiftHouse = false; 
	}

	public void makeHat()
	{
		GameObject newHat = Instantiate (aHatPrefab, new Vector3 (aHatPos.x, aHatPos.y + (aHatInc*(aHats-1)), aHatPos.z), Quaternion.identity) as GameObject;  
		Hat hatScript = newHat.GetComponent<Hat>();
		hatScript.aPlayer = this; 
		hatScript.aID = aHats; 
	}

	public void makeDealer()
	{
		if (Random.Range (1,5) == 1)
		{
			//audio.PlayOneShot(clips[1]); 
			GameObject dealer = Instantiate (aDealerPrefab) as GameObject; 
			HatDealer dealScript = dealer.GetComponent<HatDealer>();
			dealScript.aPlayer = this; 
		}
	}

	public void resetPlayer()
	{
		aHats = 0;
		aCandies = 0; 
		currentFrame = 10;
		candyFrame = coolCandy; 
		aChangingHouses = false; 
	}
}
