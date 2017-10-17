using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDistributionView : MonoBehaviour {

	public Text connectedConsumers;
	public GameObject sliderGroupPrefab;

	private EnergyDistributionModel distModel;
	private List<EnergyConsumer> consumers;
	private List<GameObject> sliderGroups;

	void Awake() {
		//string message = "Connected consumers:\n";
		EnergyDistributionController distController = GetComponent<EnergyDistributionController> ();
		distModel = distController.DistributionModel;
		consumers = distModel.Consumers;

		UpdateConnectedConsumersText ();

		//-------------------
		sliderGroups = new List<GameObject> ();
		int x = 0;
		foreach (EnergyConsumer consumer in consumers) {
			GameObject sliderGroup = Instantiate (sliderGroupPrefab, new Vector3 (x, 0, 0), Quaternion.identity) as GameObject;
			Slider[] sliders = sliderGroup.GetComponentsInChildren<Slider> () as Slider[];
			consumer.SetSliders (sliders);
			x += 100;
			sliderGroup.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
			sliderGroups.Add(sliderGroup);
		}



	}

	void FixedUpdate () {
		UpdateConnectedConsumersText ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateConnectedConsumersText () {
		string message = "Connected consumers:\n";
		foreach (EnergyConsumer consumer in consumers) {
			message += "" 
				+ consumer.Name.ToUpper() 
				+ " pwr setting: " 
				+ consumer.CurrentEnergyMultiplier 
				+ " pwr cons.: "
				+ consumer.EnergyConsumption
				+ "\n";
		}
		connectedConsumers.text = message;
	}
}
