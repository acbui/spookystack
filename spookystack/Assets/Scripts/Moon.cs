using UnityEngine;
using System.Collections;

public class Moon : MonoBehaviour {

	public float Mpos;
	public float Mspeed;
	public float EndTime;


	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		Mpos = Time.time;

		if (Mpos <= EndTime) {
			transform.position += Vector3.up * Mspeed;

		} else {
			print ("GAME IS DONE");
		}
	
	}
}
