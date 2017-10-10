using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reactor_work : MonoBehaviour {

	public Slider energyLevel; //Will be sliders later on
	public GameObject reactor; // Reactor prefab

	public int bmatter;// Resources from inventory
	public int plasma; // Resources from inventory
	public int sun;    // Resources from inventory

	public EnergyStorage energyStorage; // External energy storage
	public Energy energy; // Energy script
	public Energy_conversion energy_conversion;


	void Awake(){
		energy = new Energy ();
		energyStorage = new EnergyStorage ();
		energy_conversion = new Energy_conversion ();
	}



	void Start(){	// On start check all the initial values


		energy.GetEnergyUnit(); // Get current energy levels


		energyStorage = energyStorage.GetQuantity(); // Set the current energy storage value

	}


	void Update(){ // Keep checking these parameters
		
		CheckEnergy (); // Checking energy levels
	}



	public void CheckEnergy(){ // Checking the energy levels


		if (energyStorage.GetQuantity() == 0) { // The if we need to create more energy

			FusionAction (); // Call a class that creates fusion within a reactor to create heat for the energy production

		} 



		else if (energy.GetEnergyUnit <= 0) { // If the energy level is negative
			/*
			 * 
			 * STOPPING THE PROCESS AND REQUESTING FOR MORE RAW MATERIALS
			 * 
			 * 
			 */
		} 



		else if (energy.GetEnergyUnit >= 500) { // If we create too much energy that could only be stored the reactor

			energyStorage.SetCurrentCapacity (energyStorage.GetCurrentCapacity + 500); // Call a method to store the energy

		}
	}



	public void FusionAction() { // Fusion reactor power creation
		
		if (energy.GetEnergyType() == "bmatter") { // Fusion reactor power creation

			CreateEnergy(bmatter); // Call a method to create energy		
		
		} else {
			// Otherwise return plasma
			//return plasma;
		}
	}// end of fusion action

	// Create energy where 100x energy units will be equivalent to 10x plasma 
	public void CreateEnergy(int plasma){
		// Energy will be quivalent to 10 plasma units at least
		energy = plasma * 10;
	}// end of CreateEnergy method


	// If we reach over - production of energy 
	public void StoreEnergy(){

		// Check if it's the right value
		if (energy >= 500) {
			// Add all the energy to the reactor energy storage
			energyStorage = energyStorage + 500;
			// Take away the energy that has been deposited
			energy = energy - 500;
		}
	}// end of StoreEnergy method

}// End of Class
