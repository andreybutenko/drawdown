using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonOption : MonoBehaviour, IPointerDownHandler {
    public NewEventUI eventUi;
    public enum ButtonType { accept, reject, dismiss };
    public ButtonType buttonType;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnPointerDown(PointerEventData eventData) {
        if(buttonType == ButtonType.accept)
            eventUi.acceptEvent();
        else if(buttonType == ButtonType.reject)
            eventUi.rejectEvent();
        else
            eventUi.dismissEvent();
    }
}