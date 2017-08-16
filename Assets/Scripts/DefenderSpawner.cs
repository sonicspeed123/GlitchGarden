using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
	public Camera myCamera;

	// Use this for initialization
	private GameObject parent;
	private StarDisplay starDisplay;
	void Start(){
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
		parent = GameObject.Find ("Defenders");

		if(!parent){
			parent = new GameObject("Defenders");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		Vector2 rawPos = CalculateWorldPointOfMouseClick ();
		Vector2 roundedPos = SnapToGrid (rawPos);
		GameObject defender = Buttons.selected;
		int defenderCost = defender.GetComponent<Defenders> ().starCost;

		if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender (roundedPos, defender);
		} else {
			Debug.Log ("not enough");
		}
	}

	void SpawnDefender (Vector2 roundedPos, GameObject defender)
	{
		Quaternion zeroRot = Quaternion.identity;
		GameObject newDef = Instantiate (defender, roundedPos, zeroRot) as GameObject;
		newDef.transform.parent = parent.transform;
	}

	Vector2 SnapToGrid (Vector2 rawPos){
		float newX = Mathf.RoundToInt (rawPos.x);
		float newY = Mathf.RoundToInt (rawPos.y);
		return new Vector2 (newX, newY);
	}

	Vector2 CalculateWorldPointOfMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);

		return worldPos;
	}

}
