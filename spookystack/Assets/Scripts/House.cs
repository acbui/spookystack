using UnityEngine;
using System.Collections;

public class House : MonoBehaviour {

	public Player aPlayer; 
	public Color[] aColors; 

	public string aNamePrefix; 
	public int aID; 

	public float[] aScales; 
	public float aVShift;
	public float aHShift; 
	public float aSpeed; 
	public Vector3 aShiftPos;
	public Vector3 aShiftScale; 
	public bool aShiftHouse; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * FIXED UPDATE: 
	 * Handles the house position lerp if the bottom house is destroyed 
	 * -------------------------------------------------------------------------------------------------------------------- */
	void FixedUpdate()
	{
		if (aShiftHouse)
		{
			transform.position = Vector3.Lerp (transform.position, aShiftPos, Time.deltaTime * aSpeed);
			transform.localScale = Vector3.Lerp (transform.localScale, aShiftScale, Time.deltaTime * aSpeed); 
			
			if (transform.position.y <= aShiftPos.y + 0.05f)
			{
				if (aID == 0)
				{
					Destroy (this.gameObject); 
				}
				transform.position = aShiftPos;
				transform.localScale = aShiftScale; 
				aPlayer.makeHouse (); 
				aShiftHouse = false; 
			}
		}
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * SHIFT HOUSE:
	 * when the player finishes with bottom house, shift all the houses  
	 * - change this house's id
	 * - change this house's name 
	 * - trigger shift of the hat  
	 * -------------------------------------------------------------------------------------------------------------------- */
	public void shiftHouse()
	{
		if (aPlayer.aChangingHouses)
		{
			aID--;
			gameObject.name = aNamePrefix + aID; 
			if (aID == 0)
			{

				aShiftPos = new Vector3 (transform.position.x + Mathf.Sign(aHShift), transform.position.y + Mathf.Sign(aVShift), transform.position.z); 
				aShiftScale = new Vector3 (aScales[aID]*2, aScales[aID]*2, transform.localScale.z); 
				 
			}
			else 
			{
				aShiftPos = new Vector3 (transform.position.x + aHShift, transform.position.y + aVShift, transform.position.z); 
				aShiftScale = new Vector3 (aScales[aID-1], aScales[aID-1], transform.localScale.z); 
			}
			aShiftHouse = true;
		}
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * SET MATERIAL:
	 * sets the house's material/colour depending on the house the player is at
	 * -------------------------------------------------------------------------------------------------------------------- */
	public void setColour()
	{
		gameObject.GetComponent<SpriteRenderer>().color = aColors [aPlayer.aHouses]; 
	}
}
