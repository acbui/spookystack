using UnityEngine;
using System.Collections;

public class Hat : MonoBehaviour {

	// SET IN INSPECTOR
	public Player aPlayer; 
	public Sprite[] aSprites;

	// hat attributes
	public string aNamePrefix; 
	public int aID; 

	// lerp stuff
	public float aVShift;
	public float aSpeed; 
	public Vector3 aShiftPos; 

	// DON'T TOUCH THIS IN INSPECTOR
	private bool aShiftHat; 

	/* --------------------------------------------------------------------------------------------------------------------
	 * START:
	 * - set the hat sprite
	 * - set the object name 
	 * -------------------------------------------------------------------------------------------------------------------- */
	void Start () {
		if (GameObject.Find (aNamePrefix + aID))
		{
			Destroy (gameObject);
		}
		setSprite(); 
		gameObject.name = aNamePrefix + aPlayer.aHats;
		aShiftHat = false; 
		transform.localScale = new Vector3 (0.3f, 0.3f, 1); 
	}

	void Update()
	{
		Hat[] hs = GameObject.FindObjectsOfType(typeof(Hat)) as Hat[];
		foreach (Hat h in hs)
		{
			if (h.name.Contains(aNamePrefix))
				h.changeName(); 
		}
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * FIXED UPDATE: 
	 * Handles the hat position lerp if the bottom hat is destroyed 
	 * -------------------------------------------------------------------------------------------------------------------- */
	void FixedUpdate()
	{
		if (aShiftHat)
		{
			transform.position = Vector3.Lerp (transform.position, aShiftPos, Time.deltaTime * aSpeed);

			if (transform.position.y <= aShiftPos.y + 0.05f )
			{
				transform.position = new Vector3 (transform.position.x, aShiftPos.y, transform.position.z);
				aShiftHat = false; 
			}
		}
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * SET SPRITE:
	 * randomly choose sprite from the aSprites array and set the sprite to that 
	 * -------------------------------------------------------------------------------------------------------------------- */
	void setSprite()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = aSprites[Random.Range (0, aSprites.Length)]; 
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * CHANGE NAME:
	 * when the bottom hat is destroyed, 
	 * - change this hat's id
	 * - change this hat's name 
	 * - trigger shift of the hat  
	 * -------------------------------------------------------------------------------------------------------------------- */
	public void changeName()
	{
		if (GameObject.Find (aNamePrefix + 1) == null)
		{
			aID--; 
			gameObject.name = aNamePrefix + aID; 
			aShiftPos = new Vector3 (transform.position.x, transform.position.y - aVShift, transform.position.z); 
			aShiftHat = true; 
		}
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * ON TRIGGER ENTER:
	 * - destroy the candy (that collided with the hat)
	 * - switch ID to 0 
	 * - call changeName on all hats of current player 
	 * - destroy this hat 
	 * -------------------------------------------------------------------------------------------------------------------- */
	void OnCollisionEnter2D (Collision2D col)
	{
		if (aID == 1)
		{
			if (col.gameObject.tag == "Candy")
			{
				aID--; 
				aPlayer.aHats--; 
				Destroy (this.gameObject); 
			}
		}
	}
}
