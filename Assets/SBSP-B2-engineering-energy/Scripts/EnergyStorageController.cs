using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyStorageController : MonoBehaviour {

	public EnergyStorage es = new EnergyStorage();
	public GameObject storageSprite;
	public Image esSprite;

	private List<GameObject> storageArray = new List<GameObject>();


	public EnergyStorage GetEnergyStorage(){
		return es;
	}


	// Use this for initialization
	void Update () {
		es.SetMaxNumberOfEnergyStorages(storageArray.Count);
		if (es.GetCurrentCapacity () >= 500) { MaxCap (); }
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

		print ("Notified");

		if (es.GetCurrentCapacity() >= 3000) {

			print ("Initiated");

			es.SetMaxCapacityReached (true);

			// Add storage automatically if we run out of space
			AddStorage ();

			if (storageArray.Count == 1) {
				es.SetMaxCapacity (es.GetMaxCapacity()*2);
			}
		}
	}
}
