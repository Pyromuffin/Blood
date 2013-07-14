using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	private GameObject player;
	public float health = 100;
	public float engageDistance = 10;
	public float attackTimer;
	public float explosionForce = 1;
	private Renderer [] renderers;
	public GameObject blood;
	public enum EnemyType{Cramps, Fatigue, Headache};
	public EnemyType type;
	public float hitTimer = 0;
	
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		renderers = gameObject.GetComponentsInChildren<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
		foreach(Renderer r in renderers)
			r.material.SetFloat("_Outline",health/10000);
		
		
		
		if(health < 0){
			Die();	
			
		}
		
		if(type == EnemyType.Cramps){
		
			if(hitTimer < Time.time + 2)
				rigidbody.useGravity = false;
			
			
			if ( (player.transform.position - transform.position).magnitude < engageDistance ){
				transform.LookAt(player.transform.position);
				attackTimer += Time.deltaTime;
				rigidbody.WakeUp();
				
				
				if(attackTimer > 3){
					rigidbody.WakeUp();
					particleSystem.emissionRate = 100;
					rigidbody.constraints = RigidbodyConstraints.None;
					//rigidbody.isKinematic = false;
					rigidbody.velocity += transform.forward * Time.deltaTime * explosionForce;
					//Debug.Log(rigidbody.velocity);
				}
					
				
				
				else if(attackTimer > 1){
					particleSystem.emissionRate = 50;
					//animation.Play("shake");
				}
			
				
		
			}else{
				rigidbody.constraints = RigidbodyConstraints.FreezePosition;
				attackTimer = 0;
				particleSystem.emissionRate = 10;
			}
		}
	}
	
	void Die(){
		particleSystem.gravityModifier = 0;
		particleSystem.startSpeed = 5;
		particleSystem.Emit(1000);
		GameObject.Instantiate(blood,transform.position,Quaternion.identity);
		Destroy(gameObject);
		
	}
	
	public void Hit(){
		if 	(type == EnemyType.Cramps){
			Debug.Log("enemy hit");
			particleSystem.Emit(500);
			health -= 20;
			rigidbody.velocity= (-transform.forward + transform.up) * 1;
			rigidbody.useGravity = true;
			hitTimer = Time.time;
		}
		
	}

	void OnCollisionEnter(Collision c){
		
		if(c.collider.gameObject.tag == "Sword" && c.gameObject.GetComponent<Weapons>().attacking){
			Hit();
			Debug.Log("hit");	
		}
		
		
		if(c.gameObject.tag == "Player"){
			attackTimer = 0;
			c.gameObject.GetComponent<Weapons>().health -= 5;
			rigidbody.velocity= -transform.forward * 1;
			//Debug.Log("hit");
		}
		
	}
	


}
