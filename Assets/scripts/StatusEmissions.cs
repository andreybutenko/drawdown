using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEmissions : MonoBehaviour {
    public GameMaster gameMaster;
    Text emissionsText;

    void Start() {
        emissionsText = gameObject.GetComponent<Text>();
    }

    void Update() {
        emissionsText.text = formatEmission(gameMaster.getCurrentEmissions());
    }

    string formatEmission(int value) {
        return string.Format("{0:n0}", value) + " tons/yr";
    }
}
