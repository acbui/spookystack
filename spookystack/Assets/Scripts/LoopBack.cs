using UnityEngine;
using System.Collections;

public class LoopBack : MonoBehaviour {

	public AudioClip clip; 
	// Use this for initialization
	void Start () {
		audio.PlayOneShot (clip); 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
		{
			Application.LoadLevel ("Title_Screen");
		}
	}
}
