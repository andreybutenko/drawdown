using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    public float secPerTick = 0.5f;
    public bool gameRunning = true;
    public EventUI eventUi;
    public int eventCooldownDays = 5;
    public int dailyEventChance = 5;

    GameMasterBuilder gameMasterBuilder;

    int month = 1;
    int day = 1;
    int year = 18;
    int daysThisMonth = 31;
    float timeInTick = 0;
    int daysSinceLastEvent = 0;

    int balance = 5000000;
    int inflow = 0;
    int totalEmissions = 0;
    int annualEmissions = 3471000; // Seattle 2014

    int happiness = 6; // Seattle 2011

    // Dictionary<string, int> inflows = new Dictionary<string, int>();

    void Start() {
        gameMasterBuilder = gameObject.GetComponent<GameMasterBuilder>();
    }

    void Update() {
        if(gameRunning) {
            timeInTick += Time.deltaTime;
            if(timeInTick > secPerTick) {
                timeInTick -= secPerTick;
                daysSinceLastEvent++;
                incrementDay();

                if(daysSinceLastEvent > eventCooldownDays && Random.Range(1, dailyEventChance) == 1) {
                    eventUi.displayRandomEvent();
                    daysSinceLastEvent = 0;
                }
            }
        }
    }

    void incrementDay() {
        day++;

        if(day >= daysThisMonth) {
            month++;
            day = 1;

            if(month > 12) {
                year++;
                month = 1;
            }

            daysThisMonth = System.DateTime.DaysInMonth(year, month);
        }

        balance += inflow;
        totalEmissions = annualEmissions / 365;
        gameMasterBuilder.generateBuildings(2);
    }

    public int[] getCurrentDate() {
        return new int[3] { month, day, year };
    }

    public int getCurrentBalance() {
        return balance;
    }

    public int getCurrentEmissions() {
        return annualEmissions;
    }

    public int getCurrentHappiness() {
        return happiness;
    }

    public void executeOption(JSONObject optionObj) {
        for(int j = 0; j < optionObj.GetField("effects").list.Count; j++) {
            JSONObject effectObj = optionObj.GetField("effects").list[j];
            executeEffect(effectObj);
        }
    }

    private void executeEffect(JSONObject effectObj) {
        string type = effectObj.GetField("type").str;
        int value = (int) effectObj.GetField("value").i;

        switch(type) {
            case "cost":
                balance = balance - value;
                break;
            case "saving":
                inflow = value / (12 * 365 * (2050 - 2018));
                break;
            case "emissions":
                annualEmissions = annualEmissions + value;
                break;
            case "happiness":
                happiness = happiness + value;
                break;
            default:
                break;
        }
    }
}
