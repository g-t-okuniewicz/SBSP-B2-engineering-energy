using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {
	
	string distributionScene = "eng-test-scene";
	string reactorChamberScene = "reactor-test-system";

	public void GoToEnergyDistributions(){
		//Application.LoadLevel (distributionScene);
	}

	public void GoToEnergyReactorChamber(){
		Application.LoadLevel (reactorChamberScene);
	}

}
