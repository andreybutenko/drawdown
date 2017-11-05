using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterBuilder : MonoBehaviour {
    public GameObject[] buildings;
    public int maxPosition = 500;
    public int elevation = 3;
    
	void Start() {
		
	}
	
	void Update() {
		
	}

    public void generateBuildings(int count) {
        for(int i = 0; i < count; i++) {
            int index = Random.Range(0, buildings.Length - 1);
            GameObject newBuilding = Instantiate(buildings[i]);

            int xPos = Random.Range(0, maxPosition);
            int zPos = Random.Range(0, maxPosition);
            int rotation = Random.Range(0, maxPosition);

            newBuilding.transform.position = new Vector3(xPos, elevation, zPos);

            newBuilding.transform.rotation = Quaternion.Euler(0, rotation, 0);
        }
    }
}
