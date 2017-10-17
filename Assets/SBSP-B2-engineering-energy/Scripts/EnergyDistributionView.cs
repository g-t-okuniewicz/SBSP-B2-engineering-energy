using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDistributionView : MonoBehaviour {

	public Text connectedConsumers;

	private EnergyDistributionModel distModel;

	void Awake() {
		string message = "Connected consumers:\n";
		EnergyDistributionController distController = GetComponent<EnergyDistributionController> ();
		distModel = distController.DistributionModel;
		List<EnergyConsumer> consumers = distModel.Consumers;
		foreach (EnergyConsumer consumer in consumers) {
			message += "" 
				+ consumer.Name.ToUpper() 
				+ " pwr setting: " 
				+ consumer.CurrentEnergyMultiplier 
				+ " pwr cons.: "
				+ consumer.GetCurrentEnergyConsumption()
				+ "\n";
		}

		connectedConsumers.text = message;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
