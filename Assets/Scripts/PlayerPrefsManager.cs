﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class PlayerPrefsManager : MonoBehaviour {

	//controls all player pref

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	const string DIFF_KEY = "difficulty";


	public static void SetMasterVolume(float volume){
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Master volume out of range.");
		}
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel (int level){
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(), 1); // 1 for true
		} else {
			Debug.LogError ("level not existing");
		}
	}

	public static bool IsLevelUnlocked(int level){
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());
		bool islevelUnlocked = (levelValue == 1);

		if(level <= SceneManager.sceneCountInBuildSettings - 1){
			return islevelUnlocked;
		} else {
			Debug.LogError ("level no exist");
			return false;
		}
	}

	public static void SetDifficulty(float difficulty){
		
		if (difficulty >= 1 && difficulty <= 3) {
			PlayerPrefs.SetFloat (DIFF_KEY, difficulty);
		} else {
			Debug.LogError ("difficulty out of range.");
		}
	}

	public static float GetDifficulty(){
		
		return PlayerPrefs.GetFloat (DIFF_KEY);

	}

}