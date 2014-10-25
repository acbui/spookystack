using UnityEngine;
using System.Collections;

public class HatRef : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col)
	{
		print ("CANDY");
		Destroy (col.gameObject);
	}
}
