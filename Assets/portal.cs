using UnityEngine;
using System.Collections;

public class portal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,60 * Time.deltaTime,0);
	
	}
	
	
	void OnTriggerEnter(Collider c){
		
		if (c.tag == "Player")
			Application.LoadLevel("ending");
		
		
	}
}
