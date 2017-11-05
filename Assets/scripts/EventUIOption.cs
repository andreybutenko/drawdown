using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventUIOption : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {
    EventUI eventUi;
    public JSONObject optionJson;
    
	void Start () {
        eventUi = GameObject.Find("EventUI").GetComponent<EventUI>();
	}
	
	void Update () {
		
	}

    public void OnPointerEnter(PointerEventData eventData) {
        eventUi.onHighlightOption(optionJson.GetField("description").str);
    }

    public void OnPointerExit(PointerEventData eventData) {
        eventUi.onHighlightOption(null);
    }

    public void OnPointerClick(PointerEventData eventData) {
        eventUi.onSelectOption(optionJson);
    }
}
