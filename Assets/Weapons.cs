using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour {
	public bool ready = true;
	public float readyTimer, readySpeed;
	public GameObject sword;
	private Vector3 startPos;
	public float velocityMag;
	
	// Use this for initialization
	void Start () {
		readyTimer = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		velocityMag = rigidbody.velocity.magnitude;
		
		
		if(Input.GetButtonDown("Fire1") && ready){
			ready = false;
			animation.Stop("idle");
			gameObject.animation.Play("swing sword");
			readyTimer = Time.time;
			//startPos = transform.position;
			
			
		}
		
		if ( Mathf.Abs(Input.GetAxis("Horizontal")) > .1f ){
			animation.Stop("idle");
			animation.Blend("run");	
			animation.Blend("arm jog",.3f);
		}
		else{
			if(!animation.IsPlaying("swing sword") )
			{
				animation.Blend("idle",1f,1);
			}
			animation.Blend("run",0,1);
			animation.Stop("arm jog");
			
		}
		
		if (animation.IsPlaying("swing sword") ){
			sword.GetComponentInChildren<ParticleSystem>().emissionRate = 1000;
			transform.Translate(0,0,4 * Time.deltaTime);	
		}
			
		if(Time.time > readyTimer + readySpeed){
			ready = true;
			sword.GetComponentInChildren<ParticleSystem>().emissionRate = 10;
		}
	}
}
