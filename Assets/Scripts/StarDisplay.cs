using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text scoreText;
	private int scoreInt = 0;
	public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text> ();
		scoreText.text = scoreInt.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AddStars(int amount){
		scoreInt += amount;
		UpdateDisplay ();
	}

	public Status UseStars(int amount){
		if (scoreInt >= amount) {
			scoreInt -= amount;
			UpdateDisplay ();
			return Status.SUCCESS;
		} 

		return Status.FAILURE;
	}

	private void UpdateDisplay(){
		scoreText.text = scoreInt.ToString ();
	}
}
