using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Camera2D : MonoBehaviour {

	public GameObject follow;
	public float followDistance = 3;
	public float followHeight = 2;

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Camera.main.gameObject.transform.position = new Vector3(follow.transform.position.x + followDistance, follow.transform.position.y + followHeight, follow.transform.position.z);
		Camera.main.transform.LookAt(follow.transform.position);
		transform.position =  new Vector3(0,transform.position.y,transform.position.z);
	}
}
