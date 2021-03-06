﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StatusEmissions : MonoBehaviour {
    public GameMaster gameMaster;
    Text emissionsText;

    void Start() {
        emissionsText = gameObject.GetComponent<Text>();
    }

    void Update() {
        emissionsText.text = "Emissions: " + formatEmission(gameMaster.getCurrentEmissions()) + " GT";
    }

    string formatEmission(float value) {
        return string.Format("{0:n0}", value);
    }
}
