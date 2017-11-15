using UnityEngine;
using UnityEngine.UI;

public class ReactorView {

	public Text energyLevel;
	public Text storageLevel;

	public EnergyStorage es;
	public ReactorModel rm;

	public ReactorView(Text energy, Text storage){

		energyLevel = energy;
		storageLevel = storage;

		es = new EnergyStorage ();

		energyLevel.text = "Energy level: ";
		storageLevel.text = "Current storage level: 0";
	}

	public Text GetEnergyLevel(){
		return energyLevel;
	}

	public void SetEnergyLevel(int energyLevel, int maxCapacity){
		this.energyLevel.text = "Energy level: " + energyLevel + " / " + maxCapacity;
	}



	public Text GetStorageLevel(){
		return storageLevel;
	}

	public void SetStorageLevel(int storageLevel){
		this.storageLevel.text = "Current storage level: " + storageLevel + " / " + es.GetMaxCapacity() ;
	}

}
