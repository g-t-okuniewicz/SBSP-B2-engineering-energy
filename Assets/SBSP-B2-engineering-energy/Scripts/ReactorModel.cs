using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactorModel{

	public int fuel;
	public int energy;
	public int maxCapacity;
	private List<GameObject> reactorArray;


	public ReactorModel(){
		fuel = 10;
		energy = 0;
		maxCapacity = 500;
		reactorArray = new List<GameObject>();
	}



	public int GetFuel(){
		return fuel;
	}

	public void SetFuel(int fuel){
		this.fuel = fuel;
	}



	public int GetEnergy(){
		return energy;
	}

	public void SetEnergy(int energy){
		this.energy = energy;
	}



	public int GetMaxcapacity(){
		return maxCapacity;
	}

	public void SetMaxcapacity(int maxCapacity){
		this.maxCapacity = maxCapacity;
	}



	public List<GameObject> GetReactorArray(){
		return reactorArray;
	}

	public void SetReactorArray(List<GameObject> reactorArray){
		this.reactorArray = reactorArray;
	}

}
