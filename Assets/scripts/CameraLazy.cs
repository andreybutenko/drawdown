using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLazy : MonoBehaviour {
    public GameObject target;

	void Start () {
		
	}
	
	void Update () {
        transform.LookAt(target.transform);
        transform.Translate(Vector3.right * Time.deltaTime);
    }
}
