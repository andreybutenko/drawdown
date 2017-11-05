using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBalance : MonoBehaviour {
    public GameMaster gameMaster;
    Text balanceText;

    void Start() {
        balanceText = gameObject.GetComponent<Text>();
    }
	
	void Update() {
        balanceText.text = toDollar(gameMaster.getCurrentBalance());
	}

    string toDollar(int value) {
        return "$" + string.Format("{0:n0}", value);
    }
}
