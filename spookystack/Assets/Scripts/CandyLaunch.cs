using UnityEngine;
using System.Collections;

public class CandyLaunch : MonoBehaviour {

	public Vector3 aTarget; 
	public string aTargetName;
	public float aSpeed;
	public float aAccel;

	public Sprite[] aSprites; 
	public AudioClip clip;

	/* --------------------------------------------------------------------------------------------------------------------
	 * START: 
	 * find the target: opponent's bottom hat
	 * -------------------------------------------------------------------------------------------------------------------- */
	void Start () {
		if (GameObject.Find(aTargetName) != null)
		{
			aTarget = GameObject.Find(aTargetName).transform.position; 
		}
		gameObject.GetComponent<SpriteRenderer> ().sprite = aSprites [Random.Range (0, aSprites.Length)]; 
	}

	/* --------------------------------------------------------------------------------------------------------------------
	 * FIXED UPDATE:
	 * - slerp the candy towards the opponent's bottom hat
	 * - accelerate the slerp
	 * -------------------------------------------------------------------------------------------------------------------- */
	void FixedUpdate()
	{
		transform.position = Vector3.Lerp (transform.position, aTarget, aSpeed * Time.deltaTime); 
		aSpeed += aAccel; 

		if (GameObject.Find(aTargetName) == null && Mathf.Abs(transform.position.x - aTarget.x) <= 0.05f)
		{
			audio.PlayOneShot(clip);
			Destroy (gameObject);
		}
	}

	//void OnCollisionEnter2D ()
	//{
	//	Destroy (gameObject); 
	//}
}
