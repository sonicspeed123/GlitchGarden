using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Attackers))]
public class Lizard : MonoBehaviour {

	private Animator anim;
	private Attackers attacker;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		attacker = GetComponent<Attackers> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D collider){
		GameObject obj = collider.gameObject;

		//abourt if not defender
		if(!obj.GetComponent<Defenders>()){
			return;
		}
		anim.SetBool ("isAttacking", true);
		attacker.Attack (obj);
	}
}
