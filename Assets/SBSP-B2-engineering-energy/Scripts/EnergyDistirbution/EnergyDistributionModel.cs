//using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

public class EnergyDistributionModel {

	//

	//list of energy consumers
	private List<EnergyConsumer> consumers;

	public EnergyDistributionModel() {
		consumers = new List<EnergyConsumer> ();
	}
		
	public List<EnergyConsumer> Consumers { get { return consumers; } }

	public bool AddEnergyConsumer(EnergyConsumer consumer) {
		consumers.Add (consumer);
		return true;
	}
}
