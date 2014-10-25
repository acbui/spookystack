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

<<<<<<< HEAD
=======
			Player[] ps = GameObject.FindObjectsOfType(typeof(Player)) as Player[];
			foreach (Player p in ps)
			{
				p.enabled = false; 
			}
			cam.enabled = true; 
>>>>>>> 32f5a2a30df0b4cf72be39f7302edc9cf21ac540
		}
	
	}
}
