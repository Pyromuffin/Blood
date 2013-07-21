using UnityEngine;
using System.Collections;

public class DEAD : MonoBehaviour {
	public AudioClip dead;
	public GameObject blood;

	// Use this for initialization
	void Start () {
	
		particleSystem.gravityModifier = 1;
		particleSystem.startSpeed = 5;
		particleSystem.Emit(2000);
		GameObject.Instantiate(blood,transform.position,Quaternion.identity);
		audio.PlayOneShot(dead);
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
