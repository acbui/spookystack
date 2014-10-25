using UnityEngine;
using System.Collections;

public class HatDealer : MonoBehaviour {

	public int aHatCost; 
	public Player aPlayer; 

	public int aID; 
	public int minCost;
	public int maxCost; 

	// Use this for initialization
	void Start () {
		aHatCost = Random.Range (minCost, maxCost+1); 
	}
	
	// Update is called once per frame
	void Update () {
		if (aID == 1)
		{
			if (Input.GetKeyDown (KeyCode.D) || Input.GetMouseButtonDown(1))
			{
				if (aPlayer.aCandies >= aHatCost)
				{
					aPlayer.aCandies -= aHatCost; 
					aPlayer.aHats++;
					aPlayer.makeHat (); 
					Destroy (gameObject); 
				}
			}
			if (Input.GetKeyDown (KeyCode.A) || Input.GetMouseButtonDown (0))
			{
				Destroy (gameObject); 
			}
		}

		if (aID == 2)
		{
			if (Input.GetKeyDown (KeyCode.RightArrow))
			{
				if (aPlayer.aCandies >= aHatCost)
				{
					aPlayer.aCandies -= aHatCost; 
					aPlayer.aHats++;
					aPlayer.makeHat (); 
					Destroy (gameObject); 
				}
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow))
			{
				Destroy (gameObject); 
			}
		}
	}
}
