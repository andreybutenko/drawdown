using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class IntroUIButton : MonoBehaviour, IPointerDownHandler {
    public IntroUI introUi;
    public enum ButtonType { play, drawdown };
    public ButtonType buttonType;
    
    void Start() {

    }
    
    void Update() {

    }

    public void OnPointerDown(PointerEventData eventData) {
        if(buttonType == ButtonType.play)
            introUi.dismiss();
        else if(buttonType == ButtonType.drawdown)
            Application.OpenURL("http://www.drawdown.org/");
    }
}