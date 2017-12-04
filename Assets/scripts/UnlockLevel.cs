using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevel : MonoBehaviour {

	public GameObject button;
	public static UnlockLevel instance = null;
	public bool[] levels;


	void Awake() {
		instance = this;
	}
	// Use this for initialization
	void Start () {
		for (int i = 0; i < levels.Length; i++) {
			button = GameObject.Find ("ButtonLevel" + (i + 1));
			if (levels [i] == true) {
				button.GetComponent<ChangeScene>().enabled = true;
			} else {
				button.GetComponent<ChangeScene>().enabled = false;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
