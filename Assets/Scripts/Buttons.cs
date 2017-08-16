using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {


	public GameObject defPrefab;
	private Buttons[] buttonArray;

	//static makes it so that this is a unique variable across ALL things with
	//the button class
	public static GameObject selected;

	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Buttons> ();
		foreach(Buttons thisButton in buttonArray){
			thisButton.GetComponent<SpriteRenderer> ().color = Color.black;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		foreach(Buttons thisButton in buttonArray){
			thisButton.GetComponent<SpriteRenderer> ().color = Color.black;
		}

		GetComponent<SpriteRenderer> ().color = Color.white;
		selected = defPrefab;

	}
}
