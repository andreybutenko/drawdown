using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUITooltip : MonoBehaviour {
    bool tooltipEnabled = false;
    Text tooltipText;
    RawImage tooltipBackground;

	void Start() {
        tooltipText = gameObject.GetComponentInChildren<Text>();
        tooltipBackground = gameObject.GetComponent<RawImage>();
	}
	
	void Update() {
		if(tooltipEnabled) {
            gameObject.transform.position = Input.mousePosition + new Vector3(5, 5);
        }
	}

    private void hideTooltip() {
        tooltipEnabled = false;
        tooltipBackground.enabled = false;
        tooltipText.enabled = false;
    }

    private void showTooltip() {
        tooltipEnabled = true;
        tooltipBackground.enabled = true;
        tooltipText.enabled = true;
    }

    public void displayTooltip(string text) {
        showTooltip();
        tooltipText.text = text;
    }

    public void removeTooltip() {
        hideTooltip();
    }
}
