using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUIPercentage : MonoBehaviour {
    public GameMaster gameMaster;
    float initialValue = 0;
    
	void Start () {
        initialValue = PassValue.emissions;
    }
	
	void Update () {
        float proportion = (gameMaster.getCurrentEmissions() - initialValue) / (gameMaster.getTargetEmissions() - initialValue);
        transform.localScale = new Vector3(1, proportion, 1);
    }
}
