using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDistributionController : MonoBehaviour {

	private float time = 0.0f;

	private const float TIME_STEP = 1.0f;

	private EnergyDistributionModel distModel;

	void Awake () {
		distModel = new EnergyDistributionModel ();
		distModel.AddEnergyConsumer (new EnergyConsumer ("Beam", 1.0f, 1.0f));
		distModel.AddEnergyConsumer (new EnergyConsumer ("Missiles", 3.0f, 0.75f));
		distModel.AddEnergyConsumer (new EnergyConsumer ("Headlights", 0.3f, 0.5f));
		distModel.AddEnergyConsumer (new EnergyConsumer("Fridge", 2.5f, 0.25f));
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time >= TIME_STEP) {
			time = 0.0f;
			distModel.UpdateModel ();
		}
	}

	public EnergyDistributionModel DistributionModel { get { return distModel; } }
}