using UnityEngine;
using UnityEngine.UI;

public class ReactorView {

	public Text energyLevel;
	public Text storageLevel;

	//public EnergyStorage es;
	public ReactorModel rm;

	public ReactorView(Text energy){

	
		energyLevel = energy;

		energyLevel.text = "Energy level: ";
	}

	public Text GetEnergyLevel(){
		return energyLevel;
	}

	public void SetEnergyLevel(float energyLevel, float maxCapacity){
		this.energyLevel.text = "Energy level: " + energyLevel + " / " + maxCapacity;
	}




}
