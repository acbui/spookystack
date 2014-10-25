using UnityEngine;
using System.Collections;

public class HatRef : MonoBehaviour {

	private Vector3 initPos; 
	void Start()
	{
		initPos = transform.position;
	}

	void Update()
	{
		transform.position = initPos; 
	}
}
