using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusHappiness : MonoBehaviour {
    public GameMaster gameMaster;
    Text happinessText;

    void Start() {
        happinessText = gameObject.GetComponent<Text>();
    }

    void Update() {
        happinessText.text = formatHappiness(gameMaster.getCurrentHappiness());
    }

    string formatHappiness(int value) {
        return value + " happiness";
    }
}
