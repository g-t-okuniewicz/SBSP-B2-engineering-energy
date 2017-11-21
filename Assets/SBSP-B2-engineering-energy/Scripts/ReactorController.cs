using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactorController : MonoBehaviour {

	public Image red;
	public Image green;

	//private EnergyStorage energyStorage;

	public GameObject reactor;
	private List<GameObject> reactorArray = new List<GameObject>();
	private int sizeOfReactorArray;

	private ReactorModel rm;
	public ReactorView rv;

	public EnergyStorageVIew escV;
	public EnergyStorageController esc;

	void Awake(){
		

		//Talk to Matt about replacing these 2 lines(ReactorView is not MonoBehaviour)
		Text energy = GameObject.Find ("energyLevel").GetComponent<Text>();
		Text storage = GameObject.Find ("energyStorageLevel").GetComponent<Text>();

		rm = new ReactorModel ();
		esc = new EnergyStorageController ();
		escV = new EnergyStorageVIew (storage);
		rv = new ReactorView (energy);

		esc.GetEnergyStorage ();
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

			esc.GetEnergyStorage ().SetCurrentCapacity (esc.GetEnergyStorage ().GetCurrentCapacity() + rm.GetMaxcapacity());

			escV.SetStorageLevel(esc.GetEnergyStorage ().GetCurrentCapacity()) ;

			rm.SetEnergy(rm.GetEnergy() - rm.GetMaxcapacity());
		}

		if (esc.GetEnergyStorage ().GetCurrentCapacity () >= rm.GetMaxcapacity ()) {

			esc.GetEnergyStorage ().SetOkToDistribute (true);
			esc.GetEnergyStorage ().SetMaxCapacityReached (false);

			green.enabled = true;

			red.enabled = false;
		} 

		else {

			esc.GetEnergyStorage ().SetOkToDistribute (false);

			red.enabled = true;

			green.enabled = false;
		}
	}

	// Energy Storage getter so other modules
	// can get reference to it
	public EnergyStorage GetEnergyStorage() {
		return esc.GetEnergyStorage ();
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
