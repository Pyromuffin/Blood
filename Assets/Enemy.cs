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
	public GameObject lightning;
	public AudioClip hit,cut1,cut2,dead;
	public GameObject Dead;
	
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		renderers = gameObject.GetComponentsInChildren<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
		foreach(Renderer r in renderers)
			r.material.SetFloat("_Outline",health/10000);
		
		
		
		if(health <= 0){
			Die();	
			
		}
		
		
		
		if (type ==  EnemyType.Headache){
			
			
			transform.Rotate(0,0,50 * Time.deltaTime);	
			if(hitTimer < 0){
				GameObject bolt = GameObject.Instantiate(lightning,gameObject.transform.position, gameObject.transform.rotation) as GameObject;	
				hitTimer += 2;
				//Physics.IgnoreCollision(bolt.collider, collider);
				Destroy(bolt, 10);
				
			}
			hitTimer -= Time.deltaTime;
			
			
			
		}
		
		
		

		
		
		else if(type == EnemyType.Cramps){
		
			if(hitTimer < Time.time + 2)
				rigidbody.useGravity = false;
			
			
			if ( (player.transform.position - transform.position).magnitude < engageDistance ){
				transform.LookAt(player.transform.position);
				attackTimer += Time.deltaTime;
				rigidbody.WakeUp();
				
				
				if(attackTimer > 1){
					rigidbody.WakeUp();
					particleSystem.emissionRate = 100;
					rigidbody.constraints = RigidbodyConstraints.None;
					//rigidbody.isKinematic = false;
					rigidbody.velocity += transform.forward * Time.deltaTime * explosionForce;
					//Debug.Log(rigidbody.velocity);
				}
					
				
				
				else if(attackTimer > .5){
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
		
		GameObject.Instantiate(Dead,transform.position,Quaternion.identity);
		Destroy(gameObject);
		
	}
	
	public void Hit(){
		if 	(type == EnemyType.Cramps){
			Debug.Log("enemy hit");
			particleSystem.Emit(100);
			health -= 20;
			rigidbody.velocity= (-transform.forward + transform.up) * 3;
			rigidbody.useGravity = true;
			hitTimer = Time.time;
		}
		
		if 	(type == EnemyType.Headache){
			Debug.Log("enemy hit");
			particleSystem.Emit(100);
			health -= 20;
			//rigidbody.velocity= (-transform.forward + transform.up) * 1;
			//rigidbody.useGravity = true;
			//hitTimer = Time.time;
		}
		
	}

	void OnCollisionEnter(Collision c){
	
		
		
		if(c.gameObject.tag == "Player" && c.gameObject.GetComponent<Weapons>().attacking){
			Hit();
			Debug.Log("hit");
			if(Random.Range(0,2) == 1)
				audio.PlayOneShot( cut1);
			else
				audio.PlayOneShot(cut2);
		}
		
		
		else if(c.gameObject.tag == "Player"){
			attackTimer = 0;
			c.gameObject.GetComponent<Weapons>().health -= 5;
			rigidbody.velocity= -transform.forward * 3;
			Debug.Log("hit lady");
			audio.PlayOneShot(hit);
		}
		
	}
	


}
