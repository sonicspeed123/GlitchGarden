using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] Attackers;

	void Update(){
		foreach(GameObject thisAttacker in Attackers){
			if(isTimeToSpawn (thisAttacker)){
				Spawn (thisAttacker);
			}
		}
	}

	bool isTimeToSpawn(GameObject attacker){
		Attackers newAttacker = attacker.GetComponent<Attackers>();

		float meanSpawnDelay = newAttacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("capped by framerate");
		}

		float threshhold = spawnsPerSecond * Time.deltaTime;

		return (Random.value < threshhold);
	}

	void Spawn(GameObject obj){
		GameObject myAttacker = Instantiate (obj) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}


}
