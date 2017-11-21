using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyStorageVIew : MonoBehaviour {

	public Text storageLevel;


	public EnergyStorageController esc;

	// Use this for initialization
	public EnergyStorageVIew(Text storage){

		storageLevel = storage;

		esc = new EnergyStorageController ();
		storageLevel.text = "Current storage level: 0";

	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public Text GetStorageLevel(){
		return storageLevel;
	}

	public void SetStorageLevel(float storageLevel){
		this.storageLevel.text = "Current storage level: " + storageLevel + " / " + esc.GetEnergyStorage ().GetMaxCapacity() ;
	}
}
