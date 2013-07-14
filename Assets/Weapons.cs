using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour {
	public bool ready = true;
	public float readyTimer, readySpeed;
	public GameObject sword;
	private Vector3 startPos;
	
	// Use this for initialization
	void Start () {
		readyTimer = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButtonDown("Fire1") && ready){
			ready = false;
			gameObject.animation.Play("swing sword");
			readyTimer = Time.time;
			startPos = transform.position;
			
			
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
