using UnityEngine;
using UnityEngine.UI;

public class ReactorView {


	public Text energyLevel;
	public Text storageLevel;

	public ReactorView(Text energy, Text storage){

		energyLevel = energy;
		storageLevel = storage;

		energyLevel.text = "Energy level: ";
		storageLevel.text = "Current storage level: 0";
	}

	public Text GetEnergyLevel(){
		return energyLevel;
	}

	public void SetEnergyLevel(float energyLevel){
		this.energyLevel.text = "Energy level: " + energyLevel;
	}



	public Text GetStorageLevel(){
		return storageLevel;
	}

	public void SetStorageLevel(float storageLevel){
		this.storageLevel.text = "Current storage level: " + storageLevel;
	}




}
