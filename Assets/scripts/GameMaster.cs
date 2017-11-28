using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public static GameMaster instance = null;
	//public GameObject eventPanel;

    public float secPerTick = 0.5f;
    public bool gameRunning = true;
    //public EventUI eventUi;
	public NewEventUI eventUi;
    public StatusUITooltip tooltip;
    public int eventCooldownDays = 5;
    public int dailyEventChance = 5;

    GameMasterBuilder buildingsBuilder;
	GameMasterBuilder infrastructuresBuilder;
	GameMasterBuilder vehiclesBuilder;
	GameMasterBuilder boatsBuilder;

    int month = 1;
    int day = 1;
    int year = 18;
    int daysThisMonth = 31;
    float timeInTick = 0;
    int daysSinceLastEvent = 0;

    [HideInInspector]
    public int balance = 5000000;
    public int annualInflow = 100000;
    int totalEmissions = 0;
    public int annualEmissions = 3471000; // Seattle 2014

    int happiness = 6; // Seattle 2011


    // Dictionary<string, int> inflows = new Dictionary<string, int>();
    void Awake()
    {
        instance = this;
    }
    void Start() {
		buildingsBuilder = new GameMasterBuilder ("Bldg", 30, 1);
		infrastructuresBuilder = new GameMasterBuilder ("Infrastructure", 15, 1);
		vehiclesBuilder = new GameMasterBuilder ("Vehicle", 15, 1);
		boatsBuilder = new GameMasterBuilder ("BoatAndShip", 100, 1);

        //gameMasterBuilder = gameObject.GetComponent<GameMasterBuilder>();
		buildingsBuilder.clear ();
		infrastructuresBuilder.clear ();
		vehiclesBuilder.clear ();
		boatsBuilder.clear ();



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

        balance += annualInflow / 365;
        totalEmissions = annualEmissions / 365;
		//buildings [bldgIndex].SetActive (true);
		//bldgIndex++;
		buildingsBuilder.generate();
		infrastructuresBuilder.generate ();
		vehiclesBuilder.generate ();
		boatsBuilder.generate ();
    }

    public int[] getCurrentDate() {
        return new int[3] { month, day, year };
    }

    public int getCurrentBalance() {
        return balance;
    }

    public int getCurrentAnnualInflow() {
        return annualInflow;
    }

    public int getCurrentEmissions() {
        return annualEmissions;
    }

    public int getTotalEmissions() {
        return totalEmissions;
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
                annualInflow = value / (2050 - 2018);
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
