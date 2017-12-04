using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine .UI;

public class UnlockLevel : MonoBehaviour {

	public GameObject button;
	public static UnlockLevel instance = null;
	public bool[] levels;


	void Awake() {
		instance = this;
	}
	// Use this for initialization
	void Start () {
		for (int i = 0; i < PassValue.levels.Length; i++) {
			button = GameObject.Find ("ButtonLevel" + (i + 1));
			if (PassValue.levels [i] == true) {
				button.GetComponent<ChangeScene>().enabled = true;
				button.GetComponent <Image> ().color = Color.green;
			} else {
				button.GetComponent<ChangeScene>().enabled = false;
				button.GetComponent <Image> ().color = Color.red;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
