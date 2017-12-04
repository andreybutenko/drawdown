using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public float newBalance;
	public float newEmissions;
	public float newEmissionsTarget;

	// Use this for initialization


	void Start () {
		GetComponent<Button>().onClick.AddListener(() => { switchScene(); });  

	}

	public void switchScene() {
		adjustParameters ();
		SceneManager.LoadScene ("test3.5");
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void adjustParameters() {
		PassValue.balance = newBalance;
		PassValue.emissions = newEmissions;
		PassValue.emissionsTarget = newEmissionsTarget;

	}
}
