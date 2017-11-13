using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StatusEmissions : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public GameMaster gameMaster;
    Text emissionsText;

    void Start() {
        emissionsText = gameObject.GetComponent<Text>();
    }

    void Update() {
        emissionsText.text = formatEmission(gameMaster.getCurrentEmissions()) + " tons/yr";
    }

    string formatEmission(int value) {
        return string.Format("{0:n0}", value);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        gameMaster.tooltip.displayTooltip(formatEmission(gameMaster.getCurrentAnnualInflow()) + " tons total");
    }

    public void OnPointerExit(PointerEventData eventData) {
        gameMaster.tooltip.removeTooltip();
    }
}
