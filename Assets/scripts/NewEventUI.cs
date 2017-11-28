using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewEventUI : MonoBehaviour {
	public static NewEventUI instance = null;

	public GameMaster gameMaster;
	public TextAsset events;
	public GameObject eventPanel;
	public int cost;
	public int emission;
	public int saving;

	List<JSONObject> eventList;
	JSONObject currentEventObj;

	void Awake() {
		instance = this;
		JSONObject jsonObject = new JSONObject(events.text);
		JSONObject eventsArray = jsonObject.GetField("events");
		eventList = eventsArray.list;
		//GameMaster gameMaster = new GameMaster();
	}

	void Start() {
		eventPanel = GameObject.Find("EventPanel");
		eventPanel.SetActive (false);
		//GameMaster gameMaster = new GameMaster();
	}
	
	void Update() {

	}

	public void displayRandomEvent() {
		if (eventList.Count > 0) {
			eventPanel.SetActive (true);
			int index = Random.Range (0, eventList.Count - 1);
			displayEvent (eventList [index]);
			getEffect (eventList[index]);
			eventList.RemoveAt (index);
			gameMaster.gameRunning = false;
		}
	}

	public void displayEvent(JSONObject eventObj) {
		currentEventObj = eventObj;
		GameObject.Find ("Title").GetComponent<Text>().text = eventObj.GetField("title").str;
		GameObject.Find ("Description").GetComponent<Text> ().text = eventObj.GetField ("description").str;
		GameObject.Find ("Cost").GetComponent<Text> ().text = "Cost: " + eventObj.GetField ("cost").i.ToString ();
	}

	public void getEffect(JSONObject eventObj) {
		cost = (int) eventObj.GetField("cost").i;
		emission = (int) eventObj.GetField("emission").i;
		saving = (int) eventObj.GetField("saving").i;

	}
		


		
}
