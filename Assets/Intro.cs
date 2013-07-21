using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	public int stage = 0;
	public Texture2D one,two,three,four;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButtonDown("Fire1") )
			stage++;
		
	}


	void OnGUI(){
		
		if(stage == 0)
			GUILayout.Label(one, GUILayout.MaxHeight(512) );
		if(stage == 1)
			GUILayout.Label(two, GUILayout.MaxHeight(512) );
		if(stage == 2)
			GUILayout.Label(three, GUILayout.MaxHeight(512));
		if(stage == 3)
			GUILayout.Label(four, GUILayout.MaxHeight(512) );
		if(stage == 4)
			Application.LoadLevel("final level 1");
		
		
	}


}
