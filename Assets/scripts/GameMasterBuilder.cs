using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterBuilder : MonoBehaviour {
    public GameObject[] buildings;
    //public int maxPosition = 300;
    //public int elevation = 3;
	int bldgIndex = 0;
	string tag;
	int rate;
	int updateRate;

	public GameMasterBuilder(string tag, int updateRate, int rate) {
		this.tag = tag;
		this.updateRate = updateRate;
		this.rate = rate;
	}

	void Start() {
		
	}
	
	void Update() {

	}

	public void disruptList() {
		//Random rand = new Random ();
		for (int i = 0; i < buildings.Length; i++) {
			int index1 = Random.Range (0, buildings.Length);
			int index2 = Random.Range (0, buildings.Length);
			GameObject temp = buildings [index1];
			buildings [index1] = buildings [index2];
			buildings [index2] = temp;
		}
			
	}

	public void emptyCity() {
		buildings = GameObject.FindGameObjectsWithTag (tag);
		disruptList ();
		foreach (GameObject bldg in buildings) {
			bldg.SetActive(false);
		}

	}

	public void generateBuildings() {
		if (bldgIndex % updateRate == 0) {
			for (int i = 0; i < rate; i++) {
				buildings [bldgIndex].SetActive (true);
				bldgIndex++;
			}
		}
		bldgIndex++;
	}

 /*   public void generateBuildings(int count) {
       for(int i = 0; i < count; i++) {
            int index = Random.Range(0, buildings.Length - 1);
            GameObject newBuilding = Instantiate(buildings[i]);

            int xPos = Random.Range(0, maxPosition);
            int zPos = Random.Range(0, maxPosition);
            int rotation = Random.Range(0, maxPosition);

            newBuilding.transform.position = new Vector3(xPos, elevation, zPos);

            newBuilding.transform.rotation = Quaternion.Euler(0, rotation, 0);
        }
		


    }*/
}
