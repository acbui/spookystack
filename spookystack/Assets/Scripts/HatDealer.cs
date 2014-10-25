using UnityEngine;
using System.Collections;

public class HatDealer : MonoBehaviour {

	public int aHatCost; 

	public int minCost;
	public int maxCost; 

	// Use this for initialization
	void Start () {
		aHatCost = Random.Range (minCost, maxCost+1); 
	}
	
	// Update is called once per frame
	void Update () {
	}
}
