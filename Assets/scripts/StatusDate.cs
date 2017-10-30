using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusDate : MonoBehaviour {
    public GameMaster gameMaster;
    Text dateText;

	void Start () {
        dateText = gameObject.GetComponent<Text>();
	}
	
	void Update () {
        int[] currentDate = gameMaster.getCurrentDate();
        dateText.text = withLeadingZero(currentDate[0]) + "/" + withLeadingZero(currentDate[1]) + "/" + currentDate[2];
    }

    string withLeadingZero(int num) {
        if(num < 10) {
            return "0" + num;
        }
        return "" + num;
    }
}
