using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyStorage : MonoBehaviour {

	public int currentCapacity;
	public int maxCapacity;
	public bool okToDistribute;
	public string storageType;


	public int GetCurrentCapacity(){
		return currentCapacity;
	}

	public void SetCurrentCapacity(){
		this.currentCapacity = currentCapacity;
	}



	public int GetMaxCapacity(){
		return maxCapacity;
	}

	public void SetMaxCapacity(){
		this.maxCapacity = maxCapacity;
	}



	public bool GetOkToDistribute(){
		return okToDistribute;
	}

	public void SetOkToDistribute(){
		this.okToDistribute = okToDistribute;
	}



	public string GetStrorageType(){
		return storageType;
	}

	public void SetStorageTyep(){
		this.storageType = storageType;
	}




}
