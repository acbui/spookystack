using UnityEngine;
using System.Collections;

public class Moon : MonoBehaviour {

	private float Mpos;
	private float Mspeed = 0.001f;
	public float EndTime;
	public float duration; 
	public Vector3 initPos; 

	public WinCam cam; 
	public bool tieLerp; 
	public float aSpeed; 

	// Use this for initialization
	void Start () {
		EndTime = Time.time + duration; 
		initPos = transform.position; 
		tieLerp = false; 	
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

	void FixedUpdate()
	{
		if (tieLerp)
		{
			transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, cam.winY, transform.position.z), aSpeed*Time.deltaTime); 

			if (transform.position.y >= cam.winY - 0.05f)
			{
				cam.moonLerped = true; 
			}
		}
	}

	public void resetMoon()
	{
		transform.position = initPos; 
		tieLerp = false; 
	}

}
