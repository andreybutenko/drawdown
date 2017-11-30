using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Button>().onClick.AddListener(() => { switchScene(); });  

	}

	public void switchScene() {
		SceneManager.LoadScene ("test3.0");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
