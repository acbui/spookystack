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
		SendMessage ("shiftHouse"); 
		StartCoroutine(makeHouse ()); 
	}

	IEnumerator makeHouse()
	{
		yield return new WaitForSeconds (aDelay);
		GameObject newHouse = Instantiate (aHousePrefab, aHousePos, Quaternion.identity) as GameObject;
		House houseScript = newHouse.GetComponent<House>();
		houseScript.aPlayer = this; 
	}
}
