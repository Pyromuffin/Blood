using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnCollisionEnter(Collision c){
		Debug.Log("hit");
		if(c.gameObject.tag == "Enemy")
			if(player.GetComponent<Weapons>().attacking){
				Debug.Log("sword hit");		
				c.gameObject.GetComponent<Enemy>().Hit();
		}
		
	}



}
