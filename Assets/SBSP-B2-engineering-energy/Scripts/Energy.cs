using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy{

	public int energyUnit;
	public string energyType;
	public int energyQuantity;




	public string GetEnergyType(){
		return energyType;
	}

	public void SetEnergyType(string energyType){
		this.energyType = energyType;
	}




	public int GetEnergyUnit(){
		return energyUnit;
	}

	public void SetEnergyUnit(int energyUnit){
		this.energyUnit = energyUnit;
	}





	public int GetEnergyQuantity(){
		return energyQuantity;
	}

	public void SetEnergyQuantity(int energyQuantity){
		this.energyQuantity = energyQuantity;
	}

}
