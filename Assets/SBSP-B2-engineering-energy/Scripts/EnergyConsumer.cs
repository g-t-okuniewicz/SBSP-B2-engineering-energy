//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

public class EnergyConsumer {

	private string name;

	// no. of units of energy consumed per time unit
	// during normal operation - when currEnergyMultiplier = 1.0f
	private float baseEnergyConsumption;

	// < 1.0f - underperforming
	// = 1.0f - normal operation
	// > 1.0f - overdrive
	private float currentEnergyMultiplier = 1.0f;


	private const float MAX_ENERGY_OVERDRIVE = 2.0f;

	// ---- to add later -----
	//private float currCoolantLevel = 0.0f;
	//private const float MAX_COOLANT_LEVEL = 1.0f;
	//public float heatLevel;
	//--

	public EnergyConsumer(string name, float baseEnergyConsumption) {
		this.name = name;
		this.baseEnergyConsumption = baseEnergyConsumption;
	}

	public string Name { get { return name; } }

	public float GetCurrentEnergyConsumption() {
		return currentEnergyMultiplier * baseEnergyConsumption;
	}

	//----
	public float CurrentEnergyMultiplier {
		get {
			return currentEnergyMultiplier;
		}
		set  {
			if (value <= MAX_ENERGY_OVERDRIVE) {
				currentEnergyMultiplier = value;
			} else if (value > MAX_ENERGY_OVERDRIVE) {
				currentEnergyMultiplier = MAX_ENERGY_OVERDRIVE;
			} else {
				currentEnergyMultiplier = 0;
			}
		}
		
	}

	public float EnergyConsumption { get { return currentEnergyMultiplier * baseEnergyConsumption; } }
}
