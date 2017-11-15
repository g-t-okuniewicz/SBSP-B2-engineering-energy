using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyStorageController : MonoBehaviour {

	public EnergyStorage es;
	public GameObject storageSprite;
	public Image esSprite;

	private List<GameObject> storageArray = new List<GameObject>();


	void Awake(){
		es = new EnergyStorage();

	}


	// Use this for initialization
	void Update () {
		es.SetMaxNumberOfEnergyStorages(storageArray.Count);
	}

	public void AddStorage(){

		if (es.GetMaxNumberOfEnergyStorages() <= 3) {

			GameObject energyStorageList = Instantiate (storageSprite, new Vector3 (300, -69, 0), Quaternion.identity) as GameObject;

			Image[] storageImage = energyStorageList.GetComponentsInChildren<Image> () as Image[];

			energyStorageList.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);

			storageArray.Add (energyStorageList);
		}
	}

	public void MaxCap(){

		if (es.GetMaxCapacityReached()) {

			// Add storage automatically if we run out of space
			AddStorage ();

			if (es.GetMaxNumberOfEnergyStorages () == 2) {
				es.SetMaxCapacity (es.GetMaxCapacity()*2);
			}
		}
	}
}
