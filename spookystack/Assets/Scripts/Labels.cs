using UnityEngine;
using System.Collections;

public class Labels : MonoBehaviour {

	public TextMesh Label1;
	public TextMesh Label2;
	public GameObject P1;
	public GameObject P2;

	// Use this for initialization
	void Start () {

		Label1.GetComponent<MeshRenderer> ().sortingLayerID = 8;
		Label2.GetComponent<MeshRenderer> ().sortingLayerID = 8;
	}
	
	// Update is called once per frame
	void Update () 
	
	{
		Label1.text = P1.GetComponent<Player>().aCandies.ToString(); 

		Label2.text = P2.GetComponent<Player>().aCandies.ToString(); 

	}
}
