using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroUI : MonoBehaviour {
    public GameObject eventUi;
    
	void Start () {
        eventUi.SetActive(false);
    }
	
	void Update () {
		
	}

    public void dismiss() {
        eventUi.SetActive(true);
        gameObject.SetActive(false);
    }
}
