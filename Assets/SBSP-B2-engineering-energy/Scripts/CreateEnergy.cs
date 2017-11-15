using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateEnergy : MonoBehaviour {

	public int time;
	public Energy energy;
	public Image inventory;
	public Image plasma;
	public Image reactor;
	public int numAlive;

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
