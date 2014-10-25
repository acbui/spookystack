using UnityEngine;
using System.Collections;

public class Moon : MonoBehaviour {

	private float Mpos;
	private float Mspeed = 0.001f;
	public float EndTime;

	public WinCam cam; 

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		Mpos = Time.time;

		if (Mpos <= EndTime) {
			transform.position += Vector3.up * Mspeed;

		} else {

			Player[] ps = GameObject.FindObjectsOfType(typeof(Player)) as Player[];
			foreach (Player p in ps)
			{
				p.enabled = false; 
			}
			cam.enabled = true; 
		}
	
	}
}
