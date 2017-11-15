using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDistributionController : MonoBehaviour {



	private EnergyDistributionModel distModel;

	void Awake () {
		distModel = new EnergyDistributionModel ();
		distModel.AddEnergyConsumer (new EnergyConsumer ("Beam", 1.0f));
		distModel.AddEnergyConsumer (new EnergyConsumer ("Missiles", 3.0f));
		distModel.AddEnergyConsumer (new EnergyConsumer ("Headlights", 0.3f));
		distModel.AddEnergyConsumer (new EnergyConsumer("Fridge", 2.5f));

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public EnergyDistributionModel DistributionModel { get { return distModel; } }
}