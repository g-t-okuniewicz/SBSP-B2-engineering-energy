//using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//using UnityEngine;

public class EnergyDistributionModel {
	
	private EnergyStorage energyStorage = null;
	public EnergyStorage EnergyStorage {
		get { return energyStorage; }
		set { energyStorage = value; }
	}

	private CoolantController coolantController;
	public CoolantController CoolantController {
		get { return coolantController; }
		set { coolantController = value; }
	}

	private float totalEnergyDemand;
	public float TotalEnergyDemand { get { return totalEnergyDemand; } }

	private float totalCoolantDemand;
	public float TotalCoolantDemand { get { return totalCoolantDemand; } }

	public const float MAX_HEAT = 10.0f;

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

	public float GetEnergyStorageCurrentCapacity() {
		if (energyStorage != null && energyStorage.currentCapacity > 0.0f)
			return energyStorage.currentCapacity;
		else
			return 0.0f;
	}

	/*public float GetTotalEnergyDemand() {
		float totalDemand = 0;
		foreach (EnergyConsumer consumer in consumers) {
			totalDemand += consumer.EnergyConsumption;
		}
		return totalDemand;
	}*/

	public void UpdateModel() {
		float newTotalEnergyDemand = 0.0f;
		float newTotalCoolantDemand = 0.0f;
		if (energyStorage != null && energyStorage.currentCapacity > 0.0f) {
			energyStorage.currentCapacity -= totalEnergyDemand;
			foreach (EnergyConsumer consumer in consumers) {
				newTotalEnergyDemand += consumer.CurrentEnergyDemand;
				newTotalCoolantDemand += consumer.CurrentCoolantDemand;
				if (consumer.Heat >= MAX_HEAT && !consumer.Overheated) {
					consumer.Heat = MAX_HEAT;
					consumer.Overheated = true;
					consumer.PowerSlider.value = 0.0f;
					consumer.PowerSlider.interactable = false;
				} else if (consumer.CurrentEnergyMultiplier > 1.0f && consumer.Heat < MAX_HEAT) {
					consumer.Heat += consumer.CurrentEnergyMultiplier * consumer.HeatFactor - consumer.CurrentCoolantDemand;
				} else if (consumer.CurrentEnergyMultiplier < 1.0f && consumer.Heat > 0) {
					consumer.Heat -= (1.0f - consumer.CurrentEnergyMultiplier) * consumer.HeatFactor + consumer.CurrentCoolantDemand;
				} else if (consumer.Heat <= 0.0f) {
					consumer.Heat = 0.0f;
					consumer.Overheated = false;
					consumer.PowerSlider.interactable = true;
				}
			}
		} else if (energyStorage != null && energyStorage.currentCapacity <= 0.0f) {
			energyStorage.currentCapacity = 0.0f;
			foreach (EnergyConsumer consumer in consumers) {
				newTotalEnergyDemand += consumer.CurrentEnergyDemand;
				newTotalCoolantDemand += consumer.CurrentCoolantDemand;
				consumer.CurrentEnergyMultiplier = 0.0f;
				if (consumer.PowerSlider != null) {
					consumer.PowerSlider.value = 0.0f;
					consumer.PowerSlider.interactable = false;
				}
				if (consumer.Heat <= 0.0f) {
					consumer.Heat = 0;
					consumer.Overheated = false;
				}
				else
					consumer.Heat -= consumer.HeatFactor + consumer.CurrentCoolantDemand;
			}
		}


		coolantController.coolantFlag = true;// Set too true if coolant is needed from consumer,
		//needed coolant from consumer will be taken away from available coolant(set too 1000f, change as you want)
		//This will allow the consumer coolant to be taken away once from available coolant in Update
		coolantController.tempStorage.SetCoolantNeeded(true);
		coolantController.neededCoolant = totalCoolantDemand;//Example number, representing the consumer coolant needed
		coolantController.coolantPackageFlag = true;

		totalEnergyDemand = newTotalEnergyDemand;
		totalCoolantDemand = newTotalCoolantDemand;

	}
}
