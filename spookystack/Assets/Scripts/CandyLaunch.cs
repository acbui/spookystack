using UnityEngine;
using System.Collections;

public class CandyLaunch : MonoBehaviour {

	public GameObject aTarget; 
	public string aTargetName; 
	public float aSpeed;
	public float aAccel; 

	public Sprite[] aSprites; 

	/* --------------------------------------------------------------------------------------------------------------------
	 * START: 
	 * find the target: opponent's bottom hat
	 * -------------------------------------------------------------------------------------------------------------------- */
	void Start () {
		gameObject.GetComponent<SpriteRenderer> ().sprite = aSprites [Random.Range (0, aSprites.Length)]; 

		aTarget = GameObject.Find (aTargetName); 
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * FIXED UPDATE:
	 * - slerp the candy towards the opponent's bottom hat
	 * - accelerate the slerp
	 * -------------------------------------------------------------------------------------------------------------------- */
	void FixedUpdate()
	{
		transform.position = Vector3.Lerp (transform.position, aTarget.transform.position, aSpeed * Time.deltaTime); 
		aSpeed += aAccel; 
	}

	void OnTriggerEnter ()
	{
		Destroy (this.gameObject); 
	}
}
