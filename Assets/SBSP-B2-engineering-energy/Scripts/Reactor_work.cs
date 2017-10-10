using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reactor_work : MonoBehaviour {

	public Slider energyLevel; //Will be sliders later on
	public bool energyOK; // Energy good / no
	public int plasma; // Resources from inventory
	public int energy; // Usable energy item
	public GameObject reactor; // Reactor prefab
	//public Inventory inventory; // Referencing the Inventory script from Mapping team 
	//public GameObject energyStorage; // Energy storage
	public float energyStorage; // For storing energy


	// On start check all the initial values
	void Start(){	
		// Calling the inventory script
		//inventory = GetComponent<Inventory> (); 
		// Plasma to initial because none present
		plasma = 0; 
		// No energy because no resources
		energy = 0; 
		// Energy level will be negative since no power
		energyOK = false;
		// Show the energy level
		//energyLevel = "Current energy level is: 0";
		// Set the current energy storage value
		energyStorage = 0;
	}// end start


	// Keep checking these parameters
	void Update(){ 
		// Checking resources 
		CheckResource (); 
		// Checking energy levels
		CheckEnergy (); 
	}// end of Update


	// Check the levels for resources
	public void CheckResource(){
		
		// Chech if there are more than 10 plasma units
		if (energyStorage >= 10) {
			//If there is add 10 to plasma 
			plasma = plasma + 10;
		} 
		else {
			// Notify the other team that we need resources
			// Print message that we need resources
		}
	}// end of getting resources


	// Checking the energy levels
	public void CheckEnergy(){
		// The if we need to create more energy
		if (energy == 0) {
			// Call a method that creates fusion within a reactor to create heat for the energy production
			FusionAction ();
		} 
		// If the energy level is negative
		else if (energy <= 0) {
			// Print out a message to the main controller or within a control room
			//Debug.Log ("<color=red>Fatal Error:</color> The system has ", energy);
		} 
		// Stop the system
		else if (energy == 100) {
			// If energy actaully reaches a 100 units, notify the user and the command centre
			//Debug.Log ("<color=green>Target Reached:</color> Energy levels have reached " + energy);
			energyOK = true;
			// Notifying the user with the current level of energy
			//energyLevel = (energy);
			// Double check the resources just in case
			CheckResource ();
		} 
		// If we create too much energy that could only be stored the reactor
		else if (energy >= 500) {
			// Notidfy the user and the control centre
			//Debug.Log ("<color=orange>Max Capacity reached! </color> All excess energy will now be stored" + energy);
			// Call a method to store the energy
			StoreEnergy ();
		}
	}// end of CheckEnergy method


	// Fusion reactor power creation
	public void FusionAction() {
		// If we get 10 plasma units, create a fusion
		if (plasma >= 10) {
			// Call a method to create energy
			CreateEnergy(plasma);
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
