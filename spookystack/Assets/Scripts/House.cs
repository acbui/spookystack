using UnityEngine;
using System.Collections;

public class House : MonoBehaviour {

	public Player aPlayer; 
	public Color[] aColors; 
	public Vector3[] aPositions; 
	public Vector3[] aScales; 
	public SpriteRenderer aRender; 

	public string aNamePrefix; 
	public int aID; 
	
	public float aVShift;
	public float aHShift; 
	public float aSpeed; 
	public Vector3 aShiftPos;
	public Vector3 aShiftScale; 
	public bool aShiftHouse; 

	// Use this for initialization
	void Start () {
		aRender = gameObject.GetComponent<SpriteRenderer>();
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
			transform.position = Vector3.Slerp (transform.position, aShiftPos, Time.deltaTime * aSpeed);
			transform.localScale = Vector3.Slerp (transform.localScale, aShiftScale, Time.deltaTime * aSpeed); 
			if (aID == 0)
			{
				aRender.color = Color.Lerp (aRender.color, new Color (aRender.color.r, aRender.color.g, aRender.color.b, 0), aSpeed*3 * Time.deltaTime);
			}
			else 
			{
				aRender.color = Color.Lerp (aRender.color, new Color (aRender.color.r, aRender.color.g, aRender.color.b, 255), aSpeed*2 * Time.deltaTime);
			}

			if (transform.position.y <= aShiftPos.y + 2)
			{
				if (aID == 0 && aRender.color.a <= 0.5f)
				{
					Destroy (this.gameObject);
				}
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
			if (gameObject.name.Equals (aNamePrefix + 1) && GameObject.Find (aNamePrefix + 0) != null)
			{
				Destroy (GameObject.Find (aNamePrefix + 0));
			}
			if (aID >= 1)
				aID--;
			gameObject.name = aNamePrefix + aID; 
			aShiftPos = aPositions[aID]; 
			aShiftScale = aScales[aID]; 
			aShiftHouse = true;
		}
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * SET MATERIAL:
	 * sets the house's material/colour depending on the house the player is at
	 * -------------------------------------------------------------------------------------------------------------------- */
	public void setColour()
	{
		gameObject.GetComponent<SpriteRenderer>().color = new Color (aColors [aPlayer.aHouses%3].r, aColors [aPlayer.aHouses%3].g, aColors [aPlayer.aHouses%3].b, 200); 
	}
}
