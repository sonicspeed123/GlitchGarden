using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	void Start(){
		animator = GameObject.FindObjectOfType<Animator>();

		//creates a parent if necessary
		projectileParent = GameObject.Find ("Projectiles");
		if(!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}
		SetMylaneSpawner ();
	}

	void Update(){
		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	//look through all spawners and set myLaneSpawner if found
	void SetMylaneSpawner(){
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();
		foreach(Spawner spawner in spawnerArray){
			if(spawner.transform.position.y == transform.position.y){
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError (name + " cant find spawner in lane");
	}

	bool IsAttackerAheadInLane(){
		//exit if no attackers in lane
		if(myLaneSpawner.transform.childCount <= 0){
			return false;
		}

		foreach(Transform attacker in myLaneSpawner.transform){
			if(attacker.transform.position.x > transform.position.x){
				return true;
			}
		}

		return false;
	}

	private void Fire(){
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
		
}
