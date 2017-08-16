using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float time = 100;
	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		FindYouWin ();
		winLabel.SetActive (false);
	}

	void FindYouWin ()
	{
		winLabel = GameObject.Find ("Win");
		if (!winLabel) {
			Debug.LogError ("need win text");
		}
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / time;

		if (Time.timeSinceLevelLoad >= time && !isEndOfLevel) {
			winLabel.SetActive (true);
			audioSource.Play ();
			Invoke ("LoadNextLevel", audioSource.clip.length);
			isEndOfLevel = true;	
		}

	}

	void LoadNextLevel(){
		levelManager.LoadNextLevel ();
	}
}
