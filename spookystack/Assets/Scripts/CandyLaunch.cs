using UnityEngine;
using System.Collections;

public class CandyLaunch : MonoBehaviour {

	public GameObject aTarget; 
	public string aTargetNamePrefix; 
	public float aSpeed;
	public float aAccel; 

	/* --------------------------------------------------------------------------------------------------------------------
	 * START: 
	 * find the target: opponent's bottom hat
	 * -------------------------------------------------------------------------------------------------------------------- */
	void Start () {
		aTarget = GameObject.Find (aTargetNamePrefix + " 1"); 
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * FIXED UPDATE:
	 * - slerp the candy towards the opponent's bottom hat
	 * - accelerate the slerp
	 * -------------------------------------------------------------------------------------------------------------------- */
	void FixedUpdate()
	{
		transform.position = Vector3.Slerp (transform.position, aTarget.transform.position, aSpeed * Time.deltaTime); 
		aSpeed += aAccel; 
	}
}
