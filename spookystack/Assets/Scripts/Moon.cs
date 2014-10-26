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

	public AudioClip[] clips;
	private AudioClip clip; 

	// Use this for initialization
	void Start () {
		clip = null; 
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
				if (clip == null)
				{
					clip = clips[Random.Range(0, clips.Length)];
					audio.clip = clip;
					audio.Play();
					StartCoroutine(zoomMoon());
					StartCoroutine(endMoon());
				}
			}
		}
	}

	public void resetMoon()
	{
		transform.position = initPos; 
		tieLerp = false; 
	}

	IEnumerator zoomMoon ()
	{
		yield return new WaitForSeconds (clip.length/2);
		cam.camera.orthographicSize = 1; 
	}

	IEnumerator endMoon()
	{ 
		yield return new WaitForSeconds (clip.length);
		cam.moonLerped = true; 
	}
}
