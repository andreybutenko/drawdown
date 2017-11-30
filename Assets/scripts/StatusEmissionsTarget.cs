using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StatusEmissionsTarget : MonoBehaviour {
    public GameMaster gameMaster;
    Text emissionsTargetText;

    void Start() {
        emissionsTargetText = gameObject.GetComponent<Text>();
    }

    void Update() {
        emissionsTargetText.text = "Target: " + formatEmission(gameMaster.getTargetEmissions()) + " GT";
    }

    string formatEmission(float value) {
        return string.Format("{0:n0}", value);
    }
}
