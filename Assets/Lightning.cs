using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {
	
	public float Speed = 2;
	
	// Use this for initialization
	void Start () {
		//var f = GameObject.FindGameObjectWithTag("floor");
		//var cols = gameObject.GetComponentsInChildren<Collider>();
		//foreach (Collider c in cols)
		//	Physics.IgnoreCollision(c, f.collider);
			
		
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime * Speed;
		transform.Rotate(0,0,Time.deltaTime * Speed * 10);
		
		if(transform.position.y < -50)
			Destroy(gameObject);
	}
	
	
		public void Hit(){
		
			
		//;	particleSystem.Emit(500);
			Destroy(gameObject);
		
		
	}
	
	
	void OnCollisionEnter(Collision c){
		
		if(c.collider.gameObject.tag == "sword" && c.gameObject.GetComponent<Weapons>().attacking){
			Hit();
			//Debug.Log("hit");	
		}
		
		if(c.gameObject.tag == "floor"){
			//Debug.Log("floor");
			//particleSystem.Emit(10);	
			//gameObject.renderer.enabled = false;
			//Physics.IgnoreCollision(c.collider,gameObject.collider);
			Destroy(gameObject,5);
		}
		if(c.gameObject.tag == "Player"){
			//attackTimer = 0;
			c.gameObject.GetComponent<Weapons>().health -= 5;
			//rigidbody.velocity= -transform.forward * 3;
			//Debug.Log("hit");
			Destroy(gameObject);
		}
		
	}

}
