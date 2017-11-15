using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// *** ENERGY STORAGE MODEL ***


[System.Serializable]
public class EnergyStorage {

	public float currentCapacity;
	public float maxCapacity;
	public bool maxCapacityReached;
	public bool okToDistribute;
	public string storageType;
	public int maxNumberOfEnergyStorages;

	public EnergyStorage(){
		currentCapacity = 0.0f;
		maxCapacityReached = false;
		okToDistribute = false;
    	storageType = "";
		maxCapacity = 3000.0f;
		maxNumberOfEnergyStorages = 5;
    }

	public float GetCurrentCapacity(){
		return currentCapacity;
	}

	public void SetCurrentCapacity(float currentCapacity){
		this.currentCapacity = currentCapacity;
	}



	public bool GetMaxCapacityReached(){
		return maxCapacityReached;
	}

	public void SetMaxCapacityReached(bool maxCapacityReached){
		this.maxCapacityReached = maxCapacityReached;
	}



	public bool GetOkToDistribute(){
		return okToDistribute;
	}

	public void SetOkToDistribute(bool okToDistribute){
		this.okToDistribute = okToDistribute;
	}



	public string GetStrorageType(){
		return storageType;
	}
  
	public void SetStorageType(string storageType){
		this.storageType = storageType;
	}



	public float GetMaxCapacity(){
		return maxCapacity;
	}

	public void SetMaxCapacity(float maxCapacity){
		this.maxCapacity = maxCapacity;
	}


	public int GetMaxNumberOfEnergyStorages(){
		return maxNumberOfEnergyStorages;
	}

	public void SetMaxNumberOfEnergyStorages(int maxNumberOfEnergyStorages){
		this.maxNumberOfEnergyStorages = maxNumberOfEnergyStorages;
	}
}
