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
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(150, Screen.height * proportion);
    }
}
