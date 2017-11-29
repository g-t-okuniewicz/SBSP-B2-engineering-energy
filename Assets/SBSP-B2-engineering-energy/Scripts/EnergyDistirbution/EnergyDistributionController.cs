using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDistributionController : MonoBehaviour {

	private float time = 0.0f;

	private const float TIME_STEP = 1.0f;

	private EnergyDistributionModel distModel;

	private EnergyStorage energyStorage = null;

	private CoolantController coolantController = null;

	void Awake () {
		//energyStorage = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<ReactorController> ().GetEnergyStorage();

		distModel = new EnergyDistributionModel ();
		distModel.AddEnergyConsumer (new MyEnergyConsumer ("Beam", 1.0f, 1.0f));
		distModel.AddEnergyConsumer (new MyEnergyConsumer ("Missiles", 3.0f, 0.75f));
		distModel.AddEnergyConsumer (new MyEnergyConsumer ("Headlights", 0.3f, 0.5f));
		distModel.AddEnergyConsumer (new MyEnergyConsumer("Fridge", 2.5f, 0.25f));
		distModel.AddEnergyConsumer (new MyEnergyConsumer("New Consumer", 4.7f, 0.11f));

	}

	// Use this for initialization
	void Start () {
		
		/*
		//coolantController = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<CoolantView> ().coolController;
		coolantController.coolantFlag = true;// Set too true if coolant is needed from consumer,
		//needed coolant from consumer will be taken away from available coolant(set too 1000f, change as you want)
		//This will allow the consumer coolant to be taken away once from available coolant in Update
		coolantController.tempStorage.SetCoolantNeeded(true);
		coolantController.neededCoolant = 50f;//Example number, representing the consumer coolant needed
		coolantController.coolantPackageFlag = true;//This will allow to run once in update *1
		*/
	}
	
	// Update is called once per frame
	void Update () {

		// this is in Update to make sure to get references 
		if (energyStorage == null) {
			energyStorage = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<ReactorController> ().GetEnergyStorage();
			distModel.EnergyStorage = energyStorage;
		}

		// this is in Update to make sure to get references 
		if (coolantController == null) {
			coolantController = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<CoolantView> ().coolController;
			distModel.CoolantController = coolantController;
		}
			
		time += Time.deltaTime;

		if (time >= TIME_STEP) {
			time = 0.0f;
			distModel.UpdateModel ();
		}
	}

	public EnergyDistributionModel DistributionModel { get { return distModel; } }
}