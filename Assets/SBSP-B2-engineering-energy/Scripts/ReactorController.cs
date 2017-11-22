using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactorController : MonoBehaviour {

	public Image red;
	public Image green;

	public GameObject reactor;
	private List<GameObject> reactorArray = new List<GameObject>();
	private int sizeOfReactorArray;

	private ReactorModel rm;
	public ReactorView rv;
	public EnergyStorage energyStorage;

	void Awake(){

		//Talk to Matt about replacing these 2 lines(ReactorView is not MonoBehaviour)
		Text energy = GameObject.Find ("energyLevel").GetComponent<Text>();
		Text storage = GameObject.Find ("energyStorageLevel").GetComponent<Text>();

		rm = new ReactorModel ();
		energyStorage = new EnergyStorage ();
		rv = new ReactorView (energy, storage);
	}

	void Start () {
		red.enabled = true;
		green.enabled = true;
	
		reactorArray.Add (reactor);

		if (rm.GetEnergy () < rm.GetMaxcapacity ()) {
			InvokeRepeating ("Producing", 1.0f, 1.0f);
		}
	}

	public void Producing(){ 

		if (reactorArray.Count == 1) {
			rm.SetEnergy (rm.GetEnergy () + rm.GetFuel ());		
		} 

		else if (reactorArray.Count == 2) {
			rm.SetEnergy (rm.GetEnergy () + rm.GetFuel () * 2);		
		} 

		else if (reactorArray.Count == 3) {
			rm.SetEnergy (rm.GetEnergy () + rm.GetFuel () * 3);		
		} 

		else {
			rm.SetEnergy (rm.GetEnergy () + rm.GetFuel () * 4);		
		}

		ShowEnergyLevel ();

		CheckingStorage ();
	}

	public void ShowEnergyLevel(){

		rv.SetEnergyLevel(rm.GetEnergy(), rm.GetMaxcapacity());
	}

	public void CheckingStorage(){

		if (rm.GetEnergy() >= rm.GetMaxcapacity()) {

			energyStorage.SetCurrentCapacity (energyStorage.GetCurrentCapacity() + rm.GetMaxcapacity());

			rv.SetStorageLevel(energyStorage.GetCurrentCapacity()) ;

			rm.SetEnergy(rm.GetEnergy() - rm.GetMaxcapacity());
		}

		if (energyStorage.GetCurrentCapacity () >= rm.GetMaxcapacity ()) {

			energyStorage.SetOkToDistribute (true);
			energyStorage.SetMaxCapacityReached (false);

			green.enabled = true;

			red.enabled = false;
		} 

		else {

			energyStorage.SetOkToDistribute (false);

			red.enabled = true;

			green.enabled = false;
		}
	}



	public void AddingReactor(){

		// Currently makes up to 4 reactors. The UI needs work
		// UI fix will be implemented in Sprint III - Week 1
		if (reactorArray.Count >= 0 && reactorArray.Count <= 3) {
			
			GameObject reactorList = Instantiate (reactor, new Vector3 ( 280, 210, 0), Quaternion.identity) as GameObject;

			Image[] reactorImage = reactorList.GetComponentsInChildren<Image> () as Image[];

			reactorList.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);

			reactorArray.Add (reactorList);
		}
	}
}
