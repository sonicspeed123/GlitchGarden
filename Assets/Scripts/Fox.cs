using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//makes sure that any game object with this script has the required component
//if it doesn't, it will automatically add one.
[RequireComponent (typeof (Attackers))]
public class Fox : MonoBehaviour {

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

		if (obj.GetComponent<Stone> ()) {
			anim.SetTrigger ("JumpTrigger");
		} else {
			anim.SetBool ("isAttacking", true);
			attacker.Attack (obj);
		}
	}
}
