using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnergyStorage {

	public int currentCapacity;
	public bool maxCapacity;
	public bool okToDistribute;
	public string storageType;

	public EnergyStorage(){
		GetCurrentCapacity ();
		currentCapacity = 0;
		maxCapacity = false;
		okToDistribute = false;
    	storageType = "";
    }

	public int GetCurrentCapacity(){
		return currentCapacity;
	}

	public void SetCurrentCapacity(int currentCapacity){
		this.currentCapacity = currentCapacity;
	}

	public bool GetMaxCapacity(){
		return maxCapacity;
	}

	public void SetMaxCapacity(bool maxCapacity){
		this.maxCapacity = maxCapacity;
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
}
