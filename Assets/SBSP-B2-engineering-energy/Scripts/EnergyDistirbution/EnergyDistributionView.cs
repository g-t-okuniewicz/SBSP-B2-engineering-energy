using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDistributionView : MonoBehaviour {

	public Text connectedConsumers, mockStorage;
	public GameObject sliderGroupPrefab;

	private EnergyDistributionModel distModel;
	private List<EnergyConsumer> consumers;
	private List<GameObject> sliderGroups;

	private int slidersOffsetX = -400;
	private int slidersOffsetY = -250;

	void Awake() {
		EnergyDistributionController distController = GetComponent<EnergyDistributionController> ();
		distModel = distController.DistributionModel;
		consumers = distModel.Consumers;

		//-------------------
		sliderGroups = new List<GameObject> ();

		foreach (EnergyConsumer consumer in consumers) {
			InstantiateSliders (consumer);
		}
	}

	void FixedUpdate () {
		UpdateConnectedConsumersUI ();
		UpdateStorageText ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateConnectedConsumersUI () {
		string message = "Connected consumers:\n";
		foreach (EnergyConsumer consumer in consumers) {
			message += "" 
				+ consumer.Name.ToUpper() 
				+ " Power level (1.0 - 100%): " 
				+ consumer.CurrentEnergyMultiplier 
				+ " Power consumption: "
				+ consumer.CurrentEnergyDemand
				+ " Heat Factor: "
				+ consumer.HeatFactor
				+ " Heat: "
				+ consumer.Heat
				+ " Coolant Demand: "
				+ consumer.CurrentCoolantDemand
				+ "\n";
			consumer.HeatSlider.value = consumer.Heat;
		}
		connectedConsumers.text = message;
	}

	// -=-=-=-=-=-=-=-=-=-=-=-=-
	public void UpdateStorageText () {
		string message = "Energy in storage: " + distModel.GetEnergyStorageCurrentCapacity() + "\n";
		message += "Total energy demand: " + distModel.TotalEnergyDemand + "\n";
		message += "Total coolant demand: " + distModel.TotalCoolantDemand;
		mockStorage.text = message;
	}

	public void InstantiateSliders (EnergyConsumer consumer) {
		GameObject sliderGroup = Instantiate (sliderGroupPrefab, new Vector3 (slidersOffsetX, slidersOffsetY, 0), Quaternion.identity) as GameObject;

		Text label = sliderGroup.GetComponentInChildren<Text>();
		label.text = consumer.Name;

		Slider[] sliders = sliderGroup.GetComponentsInChildren<Slider> () as Slider[];
		consumer.SetSliders (sliders);
		slidersOffsetX += 100;
		sliderGroup.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
		sliderGroups.Add(sliderGroup);
	}
}
