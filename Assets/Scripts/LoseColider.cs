﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColider : MonoBehaviour {

	private LevelManager levelManager;

	void Start(){
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnTriggerEnter2D(){
		levelManager.LoadLevel ("Lose");
	}
}
