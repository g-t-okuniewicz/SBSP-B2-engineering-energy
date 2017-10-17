using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDistributionController : MonoBehaviour {



	private EnergyDistributionModel distModel;


	void Awake () {
		distModel = new EnergyDistributionModel ();
		//consumers = distModel.Consumers;

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public EnergyDistributionModel DistributionModel { get { return distModel; } }
}
