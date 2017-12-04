using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public static GameMaster instance = null;
	//public GameObject eventPanel;
    
    //public EventUI eventUi;
	public EventUI eventUi;
    public StatusUITooltip tooltip;
    
	public float balance = 500; // billions of dollars
    public float emissions = 200; // gigatons of carbon
    public float emissionsTarget = 100; // gigatons of carbon

    int happiness = 6; // Seattle 2011

    void Awake() {
		balance = PassValue.balance;
		emissions = PassValue.balance;
		emissionsTarget = PassValue.balance;
        instance = this;
    }

    void Update() {

    }

    public float getCurrentBalance() {
        return balance;
    }

    public float getCurrentEmissions() {
        return emissions;
    }

    public float getTargetEmissions() {
        return emissionsTarget;
    }
}
