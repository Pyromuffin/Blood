using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour {
	public bool ready = true;
	public float readyTimer, readySpeed;
	public GameObject sword;
	private Vector3 startPos;
	public float velocityMag;
	public float health = 100;
	private Renderer[] renderers;
	public bool attacking = false;
	public static GameObject Lady;
	
	// Use this for initialization
	void Start () {
		Lady = gameObject;
		readyTimer = 0;
		renderers = gameObject.GetComponentsInChildren<Renderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		velocityMag = rigidbody.velocity.magnitude;
		
		if(health <= 0)
			Die();
		
		health = Mathf.Max(5, health - 1 * Time.deltaTime);
		
		foreach(Renderer r in renderers)
			r.material.SetFloat("_Outline",health/10000);
		
		
		if(Input.GetButtonDown("Fire1") && ready){
			ready = false;
			animation.Stop("idle");
			gameObject.animation.Play("swing sword");
			readyTimer = Time.time;
			startPos = transform.position;
			
			
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
			attacking = true;
			sword.GetComponentInChildren<ParticleSystem>().emissionRate = 1000;
			transform.Translate(0,0,4 * Time.deltaTime);	
		}else
			attacking = false;
			
		if(Time.time > readyTimer + readySpeed){
			ready = true;
			sword.GetComponentInChildren<ParticleSystem>().emissionRate = 10;
		}
	}



	void Die(){
		Destroy(gameObject);	
		
		
	}


}
