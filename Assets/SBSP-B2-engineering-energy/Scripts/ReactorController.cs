using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactorController : MonoBehaviour {


	public Image red;
	public Image green;

	public EnergyStorage energyStorage;

	public GameObject reactor;
//	public Image[] imageList;

	private ReactorModel rm;
	public ReactorView rv;

	private List<GameObject> reactorArray = new List<GameObject>();
	private int sizeOfReactorArray;

	void Awake(){

		//Talk to Matt about replacing these 2 lines(ReactorView is not MonoBehaviour)
		Text energy = GameObject.Find ("energyLevel").GetComponent<Text>();
		Text storage = GameObject.Find ("energyStorageLevel").GetComponent<Text>();

		rm = new ReactorModel ();
		rv = new ReactorView (energy, storage);
	}

	void Start () {
		rm.SetFuel (10);
		rm.SetEnergy (0);

		red.enabled = true;
		green.enabled = true;

		energyStorage = new EnergyStorage ();

		sizeOfReactorArray = reactorArray.Count;

		InvokeRepeating("Producing", 1.0f, 1.0f);
	}
		


	public void Producing(){ 
		rm.SetEnergy(rm.GetEnergy() + rm.GetFuel());

		ShowEnergyLevel ();
		CheckingStorage ();
	}

	public void ShowEnergyLevel(){

		rv.SetEnergyLevel(rm.GetEnergy());
	}

	public void CheckingStorage(){

		if (rm.GetEnergy() >= rm.GetMaxcapacity()) {
			energyStorage.GetOkToDistribute ();

			energyStorage.SetCurrentCapacity (energyStorage.GetCurrentCapacity() +rm.GetMaxcapacity());
			rv.SetStorageLevel(energyStorage.GetCurrentCapacity()) ;

			rm.SetEnergy(rm.GetEnergy() - rm.GetMaxcapacity());
		}

		if (energyStorage.GetCurrentCapacity () >= rm.GetMaxcapacity ()) {
			energyStorage.SetOkToDistribute (true);
			green.enabled = true;
			red.enabled = false;
		} else {
			energyStorage.SetOkToDistribute (false);
			red.enabled = true;
			green.enabled = false;
		}
	}


	public void AddingReactor(){



		for (int i = 0; i < sizeOfReactorArray; i++) {

			GameObject reactorList = Instantiate (reactor, new Vector3 (180 + i + 100, 210, 0), Quaternion.identity) as GameObject;

			Image[] reactorImage = reactorList.GetComponentsInChildren<Image> () as Image[];

			reactorList.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
			reactorArray.Add (reactorList);

			print ("Reactor added!!");
		}
	}
}
