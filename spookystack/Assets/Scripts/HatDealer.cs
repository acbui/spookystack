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
			if ((Input.GetKeyDown (KeyCode.D) || Input.GetMouseButtonDown(1)) && !(Input.GetKeyDown (KeyCode.A) && Input.GetKeyDown (KeyCode.W)))
			{
				if (aPlayer.aCandies >= aHatCost)
				{
					aPlayer.aCandies -= aHatCost; 
					aPlayer.aHats++;
					aPlayer.makeHat (); 
					Destroy (gameObject); 
				}
			}
			if ((Input.GetKeyDown (KeyCode.A) || Input.GetMouseButtonDown (0)) || !(Input.GetKeyDown (KeyCode.D) && Input.GetKeyDown (KeyCode.W)))
			{
				Destroy (gameObject); 
			}
		}

		if (aID == 2)
		{
			if (Input.GetKeyDown (KeyCode.RightArrow) && !Input.GetKeyDown (KeyCode.LeftArrow) && !Input.GetKeyDown (KeyCode.UpArrow))
			{
				if (aPlayer.aCandies >= aHatCost)
				{
					aPlayer.aCandies -= aHatCost; 
					aPlayer.aHats++;
					aPlayer.makeHat (); 
					Destroy (gameObject); 
				}
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow) && !Input.GetKeyDown (KeyCode.RightArrow) && !Input.GetKeyDown (KeyCode.UpArrow))
			{
				Destroy (gameObject); 
			}
		}
	}
}
