using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {
	// Use this for initialization


	void Start () {
		GetComponent<Button>().onClick.AddListener(() => { switchScene(); });  

	}

	public void switchScene() {
		SceneManager.LoadScene ("menu");
	}

	// Update is called once per frame
	void Update () {
		
	}


}
