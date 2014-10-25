using UnityEngine;
using System.Collections;

public class CandyLaunch : MonoBehaviour {

	public GameObject aTarget; 
	public string aTargetName; 
	public float aSpeed;
	public float aAccel; 

	/* --------------------------------------------------------------------------------------------------------------------
	 * START: 
	 * find the target: opponent's bottom hat
	 * -------------------------------------------------------------------------------------------------------------------- */
	void Start () {
		aTarget = GameObject.Find (aTargetName); 
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
