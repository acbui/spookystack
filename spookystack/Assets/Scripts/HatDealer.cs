using UnityEngine;
using System.Collections;

public class HatDealer : MonoBehaviour {

	public int aHatCost; 
	public Player aPlayer; 

	public int aID; 
	public int minCost;
	public int maxCost; 

	public bool fadingOut; 
	public SpriteRenderer aRender;
	public float aSpeed;  

	// Use this for initialization
	void Start () {
		fadingOut = false; 
		aRender = gameObject.GetComponent<SpriteRenderer>();
		aHatCost = Random.Range (minCost, (maxCost+1)*((aPlayer.aHats%5)+1)); 
	}
	
	// Update is called once per frame
	void Update () {
		if (!fadingOut)
		{
			if (aID == 1)
			{
				if (Input.GetKeyDown (KeyCode.D))
				{
					if (aPlayer.aCandies >= aHatCost)
					{
						aPlayer.aCandies -= aHatCost; 
						aPlayer.aHats++;
						aPlayer.makeHat (); 
						fadingOut = true; 
						//Destroy (gameObject); 
					}
				}
				if (Input.GetKeyDown (KeyCode.A))
				{
					fadingOut = true; 
					//Destroy (gameObject); 
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
						fadingOut = true; 
						//Destroy (gameObject); 
					}
				}
				if (Input.GetKeyDown (KeyCode.LeftArrow))
				{
					fadingOut = true; 
					//Destroy (gameObject); 
				}
			}
		}
	}

	void FixedUpdate()
	{
		if (fadingOut)
		{
			aRender.color = Color.Lerp (aRender.color, new Color (aRender.color.r, aRender.color.g, aRender.color.b, 0), aSpeed*Time.deltaTime);

			if (aRender.color.a <= 0.05f)
			{
				Destroy (gameObject);
			}
		}
	}
}
