using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonNo : MonoBehaviour  
{     

	public GameObject eventPanel;
	public GameMaster gameMaster;
	void Start ()  
	{  
		GetComponent<Button>().onClick.AddListener(() => { OnClick(); });  
		eventPanel = GameObject.Find("EventPanel");


	}  


	void OnClick(){  
		gameMaster.gameRunning = true;
		eventPanel.SetActive (false);   
	}  


} 