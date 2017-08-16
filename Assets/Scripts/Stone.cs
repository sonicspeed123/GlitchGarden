using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
	private Animator animator;

	void Start(){
		animator = GetComponent<Animator> ();
	}
	void OnTriggerStay2D(Collider2D col){
		Attackers attacker = col.gameObject.GetComponent<Attackers> ();

		if(attacker){
			animator.SetTrigger ("isAttacked");
		}

	}
}
