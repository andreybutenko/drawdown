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
		GetComponent<Button>().onClick.AddListener(() => { OnClickShot(); });  
		eventPanel = GameObject.Find("EventPanel");


	}  


	void OnClickShot(){  
		gameMaster.gameRunning = true;
		eventPanel.SetActive (false);   
	}  


} 