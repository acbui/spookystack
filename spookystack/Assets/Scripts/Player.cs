using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int aHats;
	public int aCandies;
	public int aHouses; 

	public GameObject aHousePrefab; 
	public bool aChangingHouses; 

	public Vector3 aHousePos; 
	public float aDelay;

	// Use this for initialization
	void Start () 
	{
		aHats = 0;
		aCandies = 0; 
		aHouses = 0; 
		aChangingHouses = false; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			changeHouse(); 
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

	void changeHouse()
	{
		aChangingHouses = true; 
		House[] hs = GameObject.FindObjectsOfType(typeof(House)) as House[];
		foreach (House h in hs)
		{
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
}
