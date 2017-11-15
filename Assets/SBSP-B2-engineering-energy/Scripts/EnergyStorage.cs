using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// *** ENERGY STORAGE MODEL ***


[System.Serializable]
public class EnergyStorage {

	public int currentCapacity;
	public int maxCapacity;
	public bool maxCapacityReached;
	public bool okToDistribute;
	public string storageType;
	public int maxNumberOfEnergyStorages;

	public EnergyStorage(){
		currentCapacity = 0;
		maxCapacityReached = false;
		okToDistribute = false;
    	storageType = "";
		maxCapacity = 3000;
		maxNumberOfEnergyStorages = 5;
    }

	public int GetCurrentCapacity(){
		return currentCapacity;
	}

	public void SetCurrentCapacity(int currentCapacity){
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



	public int GetMaxCapacity(){
		return maxCapacity;
	}

	public void SetMaxCapacity(int maxCapacity){
		this.maxCapacity = maxCapacity;
	}


	public int GetMaxNumberOfEnergyStorages(){
		return maxNumberOfEnergyStorages;
	}

	public void SetMaxNumberOfEnergyStorages(int maxNumberOfEnergyStorages){
		this.maxNumberOfEnergyStorages = maxNumberOfEnergyStorages;
	}
}
