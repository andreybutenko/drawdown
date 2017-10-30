using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    public float secPerTick = 0.5f;
    public bool gameRunning = true;
    public EventUI eventUi;
    public int dailyEventChance = 5;

    int month = 1;
    int day = 1;
    int year = 18;
    int daysThisMonth = 31;
    float timeInTick = 0;

    void Start() {

    }

    void Update() {
        if(gameRunning) {
            timeInTick += Time.deltaTime;
            if(timeInTick > secPerTick) {
                timeInTick -= secPerTick;
                incrementDay();

                if(Random.Range(1, dailyEventChance) == 1) {
                    eventUi.displayRandomEvent();
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
    }

    public int[] getCurrentDate() {
        return new int[3] { month, day, year };
    }
}
