using UnityEngine;
using UnityEngine.UI;

public class ReactorView {

	public Image reactor;
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

	public void SetEnergyLevel(int energyLevel){
		this.energyLevel.text = "Energy level: " + energyLevel;
	}



	public Text GetStorageLevel(){
		return storageLevel;
	}

	public void SetStorageLevel(int storageLevel){
		this.storageLevel.text = "Current storage level: " + storageLevel;
	}


	public Image GetReactor(){
		return reactor;
	}

	public void SetReactor(){
		this.reactor = reactor;
	}

}
