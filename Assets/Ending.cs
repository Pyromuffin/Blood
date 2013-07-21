using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour {
	
	public Texture2D end;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnGUI(){
	
		GUILayout.Label(end, GUILayout.MaxHeight(512));
		
	}
		


}
