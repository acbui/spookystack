using UnityEngine;
using System.Collections;

public class Moon : MonoBehaviour {

	private float Mpos;
	private float Mspeed = 0.001f;
	public float EndTime;
	public GameObject camera;


	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		Mpos = Time.time;

		if (Mpos <= EndTime) {
			transform.position += Vector3.up * Mspeed;

		} else {

		}
	
	}
}
