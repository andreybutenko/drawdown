using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StatusBalance : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public GameMaster gameMaster;
    Text balanceText;

    void Start() {
        balanceText = gameObject.GetComponent<Text>();
    }
	
	void Update() {
        balanceText.text = toDollar(gameMaster.getCurrentBalance());
	}

    string toDollar(int value) {
        return "$" + string.Format("{0:n0}", value);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        gameMaster.tooltip.displayTooltip(toDollar(gameMaster.getCurrentAnnualInflow()) + "/year");
    }

    public void OnPointerExit(PointerEventData eventData) {
        gameMaster.tooltip.removeTooltip();
    }
}
