using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevel : MonoBehaviour {

	public static UnlockLevel instance = null;
	public bool[] level;

	void Awake() {
		instance = this;
	}
	// Use this for initialization
	void Start () {
		for (int i = 0; i < level.Length; i++) {
			GameObject button = GameObject.Find ("ButtonLevel" + (i + 1));
			button.GetComponent<ChangeScene > ().enabled = level [i];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
