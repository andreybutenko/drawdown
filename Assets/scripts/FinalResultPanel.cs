﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine .UI ;

public class FinalResultPanel: MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameMaster.instance.getCurrentEmissions () <= GameMaster.instance.getTargetEmissions ()) {
			GameObject.Find ("Description").GetComponent<Text> ().text = "Congratulations, you met your emissions target!";
			if (PassValue.currentLevel < PassValue.levels.Length) {
				PassValue.levels [PassValue.currentLevel] = true;
			}
		} else {
			GameObject.Find ("Description").GetComponent<Text> ().text = "Game over: you didn't meet your emissions target.";
		}

	}
}
