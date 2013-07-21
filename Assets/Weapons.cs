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
	public AudioClip slice, walkSound, jumpSound;
	public bool walkSoundTime;
	public float walkSoundTimer;
	
	// Use this for initialization
	void Start () {
		Lady = gameObject;
		readyTimer = 0;
		renderers = gameObject.GetComponentsInChildren<Renderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetButtonDown("Jump")){
			audio.PlayOneShot(walkSound);	
			
		}
		
		
		velocityMag = rigidbody.velocity.magnitude;
		
		if(health <= 0)
			Die();
		
		health = Mathf.Max(5, health - 1 * Time.deltaTime);
		
		foreach(Renderer r in renderers)
			r.material.SetFloat("_Outline",health/10000);
		
		
		if(Input.GetButtonDown("Fire1") && ready){
			audio.PlayOneShot(slice,.2f);
			ready = false;
			animation.Stop("idle");
			gameObject.animation.Play("swing sword");
			readyTimer = Time.time;
			startPos = transform.position;
			
			
		}
		
		
		
		if ( Mathf.Abs(Input.GetAxis("Horizontal")) > .1f ){
			walkSoundTimer = Time.time;
			animation.Stop("idle");
			animation.Blend("run");	
			animation.Blend("arm jog",.3f);
		}
		else{
			//walkSoundTimer = Time.time;
			if(!animation.IsPlaying("swing sword") )
			{
				animation.Blend("idle",1f,1);
			}
			//animation.Stop("run");
			animation.Blend("run",0,1);
			animation.Stop("arm jog");
			
		}
		
		if(walkSoundTimer + .2f < Time.time)
			animation.Stop("run");
		
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

	
	
	public void Walk(){
		audio.PlayOneShot(walkSound);
		
	}

	void Die(){
		
		
		Application.LoadLevel("final level 1");
		Destroy(gameObject);	
		
		
	}
	
	
	
	
	
}
