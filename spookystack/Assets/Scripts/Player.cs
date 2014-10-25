using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int aHats;
	public int aCandies;
	public int aHouses; 
	public int aID; 

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

	// Use this for initialization
	void Start () 
	{
		aHats = 0;
		aCandies = 0; 
		aHouses = 2; 
		aChangingHouses = false; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (aID == 1)
		{
			if (Input.GetMouseButtonDown(0))
			{
				collectCandy();
			}

			if (Input.GetMouseButtonDown(1))
			{
				aHats++;
				makeHat ();
			}
		}
		else if (aID == 2)
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				changeHouse(); 
				aHouses++;
			}
			
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				aHats++;
				makeHat ();
			}
		}
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * 
	 * -------------------------------------------------------------------------------------------------------------------- */
	void throwCandy()
	{
		aCandies--;
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

	/* --------------------------------------------------------------------------------------------------------------------
	 * 
	 * -------------------------------------------------------------------------------------------------------------------- */
	void tradeCandy()
	{

	}

	void changeHouse()
	{
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
}
