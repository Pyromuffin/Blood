using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {
		
		var box = gameObject.AddComponent<BoxCollider>();
		box.size =  new Vector3(3,3,1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	
	void OnCollisionEnter(Collision c){
		Debug.Log("hit");
		if(c.gameObject.tag == "Enemy"){
			Debug.Log("enemy");
			if(player.GetComponent<Weapons>().attacking){
				Debug.Log("sword hit");		
				c.gameObject.GetComponent<Enemy>().Hit();
			}
		}
	}
	 
	 


}
