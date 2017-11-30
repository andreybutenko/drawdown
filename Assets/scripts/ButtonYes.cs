using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonYes : MonoBehaviour  
{     

	public GameObject eventPanel;
	public GameMaster gameMaster;
	//private NewEventUI eventUi;



	void Start ()  
	{  
		GetComponent<Button>().onClick.AddListener(() => { OnClick(NewEventUI.instance.cost, NewEventUI.instance.emission, NewEventUI.instance.saving); });  
		eventPanel = GameObject.Find("EventPanel");




	}  


	void OnClick(int cost, int emission, int saving){  
		if (cost <= GameMaster.instance.balance) {
			GameMaster.instance.balance -= cost;
			GameMaster.instance.annualEmissions += emission;
			GameMaster.instance.annualInflow += saving;
			gameMaster.gameRunning = true;
			eventPanel.SetActive (false);   
		}
	}  


} 