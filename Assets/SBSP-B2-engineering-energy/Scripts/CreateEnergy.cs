using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnergy : MonoBehaviour {

	public int time;
	public Energy energy;

	public CreateEnergy(){
		energy = new Energy ();
	}

	public void CheckType(string type){
		if (type == "bMatter") {
			time += 60;
		} else if (type == "plasma") {
			time += 30;
		} else if (type == "sun") {
			time += 120; 
		}
	}

}
