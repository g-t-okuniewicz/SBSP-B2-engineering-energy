//using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//using UnityEngine;

public class EnergyDistributionModel {

	// TEMPORARY - to be replaced with calls to actual storage
	private float temporaryEnergyStorage = 1000f;

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
	public float GetMockStorage() {
		return temporaryEnergyStorage;
	}

	public void DrawEnergy(float value) {
		temporaryEnergyStorage -= value;
	}

	public float GetTotalEnergyDemand() {
		float totalDemand = 0;
		foreach (EnergyConsumer consumer in consumers) {
			totalDemand += consumer.EnergyConsumption;
		}
		return totalDemand;
	}

	public void UpdateModel() {
		temporaryEnergyStorage -= GetTotalEnergyDemand ();

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
	}
}
