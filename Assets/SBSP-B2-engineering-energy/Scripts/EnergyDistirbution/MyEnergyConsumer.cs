
public class MyEnergyConsumer : EnergyConsumer {

	public MyEnergyConsumer(string name, float baseEnergyDemand, float heatFactor) : base(name, baseEnergyDemand, heatFactor) {
	}

	public MyEnergyConsumer(
		string name,
		float baseEnergyDemand,
		float maxEnergyDemand,
		float maxTemperature,
		float heatFactor,
		float maxCoolantDemand) 
	: base (
			name,
			baseEnergyDemand,
			maxEnergyDemand,
			maxTemperature,
			heatFactor,
			maxCoolantDemand) {
	}
}
