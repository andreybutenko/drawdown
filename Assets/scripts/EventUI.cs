using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventUI : MonoBehaviour {
    public string PANEL_NAME = "EventPanel 1(Clone)";

    public GameMaster gameMaster;
    public TextAsset events;
    public GameObject eventPanel;
    public GameObject eventOption;
    public GameObject eventRow;

    List<JSONObject> eventList;
    JSONObject currentEventObj;
    
    void Start () {
        JSONObject jsonObject = new JSONObject(events.text);
        JSONObject eventsArray = jsonObject.GetField("events");
        eventList = eventsArray.list;
    }
    
    void Update () {
		
	}

    public void displayRandomEvent() {
        int index = Random.Range(0, eventList.Count - 1);
        displayEvent(eventList[index]);
        eventList.RemoveAt(index);
        gameMaster.gameRunning = false;
    }

    public void onHighlightOption(string desc) {
        Text descriptionText = gameObject.transform.FindChild(PANEL_NAME).FindChild("description").gameObject.GetComponent<Text>();
        descriptionText.text = desc != null ? desc : currentEventObj.GetField("description").str.Replace("\\n", "\n");
    }

    public void onSelectOption() {
        gameMaster.gameRunning = true;
        Object.Destroy(gameObject.transform.FindChild(PANEL_NAME).gameObject);
    }

    public void displayEvent(JSONObject eventObj) {
        currentEventObj = eventObj;

        GameObject newPanel = Instantiate(eventPanel);
        newPanel.transform.SetParent(gameObject.transform);
        newPanel.transform.localPosition = new Vector3(0, 0, 0);

        Text titleText = newPanel.transform.FindChild("title").gameObject.GetComponent<Text>();
        titleText.text = eventObj.GetField("title").str;

        Text descriptionText = newPanel.transform.FindChild("description").gameObject.GetComponent<Text>();
        descriptionText.text = eventObj.GetField("description").str.Replace("\\n", "\n");

        for(int i = 0; i < eventObj.GetField("options").list.Count; i++) {
            JSONObject optionObj = eventObj.GetField("options").list[i];

            GameObject newOption = Instantiate(eventOption);
            newOption.transform.SetParent(newPanel.transform);

            RectTransform optionRectTransform = newOption.GetComponent<RectTransform>();
            optionRectTransform.offsetMin = new Vector2(40 + 260 * i, 10);
            optionRectTransform.offsetMax = new Vector2(-560 + 260 * i, -150);

            Text optionTitleText = newOption.transform.FindChild("title").GetComponent<Text>();
            optionTitleText.text = optionObj.GetField("title").str;

            EventUIOption optionScript = newOption.GetComponent<EventUIOption>();
            optionScript.description = optionObj.GetField("description").str;
            
            for(int j = 0; j < optionObj.GetField("effects").list.Count; j++) {
                JSONObject effectObj = optionObj.GetField("effects").list[j];

                GameObject newRow = Instantiate(eventRow);
                newRow.transform.SetParent(newOption.transform);

                RectTransform rowRectTransform = newRow.GetComponent<RectTransform>();
                rowRectTransform.offsetMin = new Vector2(8, 0);
                rowRectTransform.offsetMax = new Vector2(0, -40 - 40 * j);

                Text effectTitleText = newRow.transform.FindChild("label").GetComponent<Text>();
                effectTitleText.text = effectObj.GetField("label").str;

                Text effectValueText = newRow.transform.FindChild("value").GetComponent<Text>();
                effectValueText.text = effectObj.HasField("displayValue") ? effectObj.GetField("displayValue").str : effectObj.GetField("value").str;
            }
        }
    }
}
