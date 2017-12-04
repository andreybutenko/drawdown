using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventUI : MonoBehaviour {
	public static EventUI instance = null;

	public GameMaster gameMaster;
	public TextAsset events;
	public GameObject eventPanel;
    public GameObject resultPanel;
	public GameObject finalResultPanel;

    RawImage bodyImage;
    RawImage hatImage;

	List<JSONObject> eventList;
	JSONObject currentEventObj = null;

	void Awake() {
		instance = this;
		JSONObject jsonObject = new JSONObject(events.text);
		JSONObject eventsArray = jsonObject.GetField("events");
		eventList = eventsArray.list;
	}

	void Start() {
		eventPanel = GameObject.Find("EventPanel");
        resultPanel = GameObject.Find("ResultPanel");
		finalResultPanel = GameObject.Find ("FinalResultPanel");
        bodyImage = eventPanel.transform.Find("Body").GetComponent<RawImage>();
        hatImage = eventPanel.transform.Find("Hat").GetComponent<RawImage>();
        resultPanel.SetActive(false);
		finalResultPanel.SetActive (false);
    }

    void Update() {
		if(currentEventObj == null) {
            displayRandomEvent();
        }
    }

    public void displayRandomEvent() {
		if (eventList.Count > 0) {
			eventPanel.SetActive (true);
			int index = Random.Range (0, eventList.Count - 1);
			displayEvent (eventList [index]);
			eventList.RemoveAt (index);
		}
	}

	public void displayEvent(JSONObject eventObj) {
		currentEventObj = eventObj;

        eventPanel.transform.Find("Title").GetComponent<Text>().text = eventObj.GetField("name").str;
        eventPanel.transform.Find("Description").GetComponent<Text> ().text = eventObj.GetField ("description").str;
        eventPanel.transform.Find("CostBg/Cost").GetComponent<Text> ().text = "Cost: $" + eventObj.GetField("cost").n + "B";

        bodyImage.color = Random.ColorHSV();
        hatImage.color = Random.ColorHSV();

        resultPanel.transform.Find("Title").GetComponent<Text>().text = eventObj.GetField("name").str;
        resultPanel.transform.Find("Cost").GetComponent<Text>().text = "This policy will cost <color=green>$" + eventObj.GetField("cost").n + "B</color> to implement initially.";
        resultPanel.transform.Find("Savings").GetComponent<Text>().text = "However, it will save the world <color=green>$" + eventObj.GetField("savings").n + "B</color> by 2050.";
        resultPanel.transform.Find("Emissions").GetComponent<Text>().text = "It will also mitigate <color=green>" + eventObj.GetField("emissions").n + " GT</color> of emissions.";
    }

    public void acceptEvent() {
		if (gameMaster.balance >= currentEventObj.GetField ("cost").n) {
			eventPanel.SetActive (false);
			resultPanel.SetActive (true);

			gameMaster.balance -= currentEventObj.GetField ("cost").n;
			gameMaster.emissions -= currentEventObj.GetField ("emissions").n;
		}
    }

    public void rejectEvent() {
			currentEventObj = null;
		if (eventList.Count == 0) {
			eventPanel.SetActive (false);
			finalResultPanel .SetActive (true);
		}
    }

    public void dismissEvent() {
        resultPanel.SetActive(false);
		currentEventObj = null;
		if (eventList.Count > 0) {
			eventPanel.SetActive (true);
		}
    }
}
