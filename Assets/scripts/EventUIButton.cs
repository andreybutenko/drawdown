using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class EventUIButton : MonoBehaviour, IPointerDownHandler {
    public EventUI eventUi;
    public enum ButtonType { accept, reject, dismiss };
    public ButtonType buttonType;
    
    void Start() {

    }
    
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