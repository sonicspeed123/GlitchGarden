using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour {
	public float speed,damage;

	void Update(){
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col){
		Attackers attacker = col.gameObject.GetComponent<Attackers> ();
		Health health = col.gameObject.GetComponent<Health> ();

		if(attacker && health){
			health.DealDamage (damage);
			Destroy (gameObject);
		}
	}
}
