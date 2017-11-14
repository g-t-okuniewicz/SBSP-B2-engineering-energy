//using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//using UnityEngine;

public class EnergyDistributionModel {

	/*// TEMPORARY - to be replaced with calls to actual storage
	private float temporaryEnergyStorage = 1000f;*/

	private EnergyStorage energyStorage = null;
	public EnergyStorage EnergyStorage {
		get { return energyStorage; }
		set { energyStorage = value; }
	}

	private const float MAX_HEAT = 10.0f;

	//list of energy consumers
	private List<EnergyConsumer> consumers;

	public EnergyDistributionModel() {
		consumers = new List<EnergyConsumer> ();
	}
		
	public List<EnergyConsumer> Consumers { get { return consumers; } }

	public bool AddEnergyConsumer(EnergyConsumer consumer) {
		consumers.Add (consumer);
		return true;
	}

	// TEMPORARY - to be replaced with calls to actual storage
	public float GetEnergyStorageCurrentCapacity() {
		if (energyStorage != null && energyStorage.currentCapacity > 0.0f)
			return energyStorage.currentCapacity;
		else
			return 0.0f;
	}

	/*public void DrawEnergy(float value) {
		energyStorage.currentCapacity -= value;
	}*/

	public float GetTotalEnergyDemand() {
		float totalDemand = 0;
		foreach (EnergyConsumer consumer in consumers) {
			totalDemand += consumer.EnergyConsumption;
		}
		return totalDemand;
	}

	public void UpdateModel() {
		if (energyStorage != null && energyStorage.currentCapacity > 0.0f) {
			energyStorage.currentCapacity -= GetTotalEnergyDemand ();
			foreach (EnergyConsumer consumer in consumers) {
				if (consumer.Heat > MAX_HEAT) {
					consumer.Heat = MAX_HEAT;
				} else if (consumer.CurrentEnergyMultiplier > 1.0f && consumer.Heat < MAX_HEAT) {
					consumer.Heat += consumer.CurrentEnergyMultiplier * consumer.HeatFactor;
				} else if (consumer.CurrentEnergyMultiplier < 1.0f && consumer.Heat > 0) {
					consumer.Heat -= (1.0f - consumer.CurrentEnergyMultiplier) * consumer.HeatFactor;
				} else if (consumer.Heat < 0.0f) {
					consumer.Heat = 0.0f;
				}
			}
		} else if (energyStorage != null && energyStorage.currentCapacity <= 0.0f) {
			energyStorage.currentCapacity = 0.0f;

			foreach (EnergyConsumer consumer in consumers) {
				consumer.CurrentEnergyMultiplier = 0.0f;
				consumer.PowerSlider.value = 0.0f;
				if (consumer.Heat <= 0.0f)
					consumer.Heat = 0;
				else
					consumer.Heat -= consumer.HeatFactor;
			}
		}

	}
}
