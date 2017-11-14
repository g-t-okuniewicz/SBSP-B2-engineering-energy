using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactorReWork : MonoBehaviour {

	public Object reactor;
	public 

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		CheckEnergy ();
		CheckingStorage ();

	}

	public void Producing(){ // Create energy where 1x energy unit will be equivalent to 100x sun energy units

		energy = energy + fuel; // Energy will be quivalent to 100 sun energy units 
		//createEnergy.ShowTransfer();
	}

	public void CheckEnergy(){

		nrgLEVEL.text = "Energy level: " + energy;
	}

	public void CheckingStorage(){

		if (energy >= 500) {
//			energyStorage.GetOkToDistribute (true);

			energyStorage.SetCurrentCapacity (energyStorage.GetCurrentCapacity() + 500);
			storageLevel.text = "Energy storage: " + energyStorage.GetCurrentCapacity();

			energy -= 500;
		}

		if (energyStorage.GetCurrentCapacity() >= 500) {
			energyStorage.SetOkToDistribute(true) ;
		}
	}





}
