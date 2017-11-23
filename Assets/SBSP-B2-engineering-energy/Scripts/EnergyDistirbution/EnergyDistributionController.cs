using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDistributionController : MonoBehaviour {

	private float time = 0.0f;

	private const float TIME_STEP = 1.0f;

	private EnergyDistributionModel distModel;

	private EnergyStorage energyStorage = null;

	private CoolantView coolantView = null;
	private CoolantTempStorageModel ctsm = null;

	void Awake () {
		//energyStorage = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<ReactorController> ().GetEnergyStorage();

		distModel = new EnergyDistributionModel ();
		distModel.AddEnergyConsumer (new EnergyConsumer ("Beam", 1.0f, 1.0f));
		distModel.AddEnergyConsumer (new EnergyConsumer ("Missiles", 3.0f, 0.75f));
		distModel.AddEnergyConsumer (new EnergyConsumer ("Headlights", 0.3f, 0.5f));
		distModel.AddEnergyConsumer (new EnergyConsumer("Fridge", 2.5f, 0.25f));
	}

	// Use this for initialization
	void Start () {
		coolantView = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<CoolantView> ();
		ctsm = coolantView.coolController.tempStorage;
		Debug.Log ("Coolant View: " + coolantView.ToString ());
		Debug.Log ("Storage Model: " + ctsm.ToString ());
		ctsm.GetCoolantPackage ();
	}
	
	// Update is called once per frame
	void Update () {

		// this is in Update to make sure to get references 
		if (energyStorage == null) {
			energyStorage = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<ReactorController> ().GetEnergyStorage();
			distModel.EnergyStorage = energyStorage;
		}
			
		time += Time.deltaTime;

		if (time >= TIME_STEP) {
			time = 0.0f;
			distModel.UpdateModel ();
		}
	}

	public EnergyDistributionModel DistributionModel { get { return distModel; } }
}