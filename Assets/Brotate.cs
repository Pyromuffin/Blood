using UnityEngine;
using System.Collections;

public class Brotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		animation.Play("wiggle");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(30 * Time.deltaTime,0,0);
	}
	
	
	void OnTriggerEnter(Collider c){
		//Debug.Log("collide");
		if(c.gameObject.tag == "Player" ){
			//Debug.Log(c.gameObject);
			c.gameObject.GetComponent<Weapons>().health += 15;
			Destroy(transform.parent.gameObject);
		}
	}
	
}
