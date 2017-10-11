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
	public CreateEnergy createEnergy;

	void Awake(){
		energy = new Energy ();
		energyStorage = new EnergyStorage ();
		energy_conversion = new Energy_conversion ();
		createEnergy = new CreateEnergy ();
	}



	void Start(){	// On start check all the initial values


		energy.GetEnergyUnit(); // Get current energy levels


		energy.GetEnergyQuantity (); // Set the current energy storage value

	}


	void Update(){ // Keep checking these parameters
		
		CheckEnergy (); // Checking energy levels
	}



	public void CheckEnergy(){ // Checking the energy levels


		if (energy.GetEnergyQuantity == 0) { // The if we need to create more energy

			FusionAction (); // Call a class that creates fusion within a reactor to create heat for the energy production

		} 



		else if (energy.GetEnergyQuantity <= 0) { // If the energy level is negative
			/*
			 * 
			 * STOPPING THE PROCESS AND REQUESTING FOR MORE RAW MATERIALS
			 * 
			 * 
			 */
		} 



		else if (energy.GetEnergyQuantity >= 500) { // If we create too much energy that could only be stored the reactor

			energyStorage.SetCurrentCapacity (energyStorage.GetCurrentCapacity + 500); // Call a method to store the energy
			energy.SetEnergyQuantity(energy.GetEnergyQuantity - 500);
		}
	}



	public void FusionAction() { // Fusion reactor power creation
		
		if (energy.GetEnergyType() == "bmatter") { // Fusion reactor power creation

			CreateEnergyReactor(bmatter); // Call a method to create energy		
		
		} 

		else if (energy.GetEnergyType() == "plasma") { // Fusion reactor power creation

			CreateEnergyReactor(plasma); // Call a method to create energy		

		}
			
		else if (energy.GetEnergyType() == "sun") { // Fusion reactor power creation

			CreateEnergyReactor(sun); // Call a method to create energy		

		}
			
		else {
			// Incorrect energy type		
		}
	}
		


	public void CreateEnergyReactor(int bmatter){ // Create energy where 1x energy unit will be equivalent to 1x black matter unit
		
		energy = bmatter * 1; // Energy will be quivalent to 1 black matter unit
		createEnergy.CheckType(energy.GetEnergyType()); // The time it will take to produce 1 unit of energy 
	}


	public void CreateEnergyReactor(int plasma){ // Create energy where 1x energy unit will be equivalent to 10x plasma units

		energy = plasma * 10; // Energy will be quivalent to 10 plasma units at least
		createEnergy.CheckType(energy.GetEnergyType()); // The time it will take to produce 1 unit of energy 
	}

	public void CreateEnergyReactor(int sun){ // Create energy where 1x energy unit will be equivalent to 100x sun energy units

		energy = sun * 100; // Energy will be quivalent to 100 sun energy units 
		createEnergy.CheckType(energy.GetEnergyType()); // The time it will take to produce 1 unit of energy 
	}


	/*
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
	*/


}// End of Class
