interface IEnergyConsumer {

	// Display name.
	string Name { get; }

	// ENERGY
	// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	/* 
	 * Units of energy consumed per time step (1s)
	 * during normal operation - when CurrentEnergyMultiplier = 1.0f.
	 * This will be multiplied by CurrentEnergyMultiplier
	 * to calculate CurrentEnergyDemand.
	 */
	float BaseEnergyDemand { get; }

	/*
	 * Adjusted with a slider during gameplay.
	 * Multiplied by BaseEnergyDemand
	 * to calcuate CurrentEnergyDemand.
	 * < 1.0f - underperforming
	 * = 1.0f - normal operation
	 * > 1.0f - overdrive
	 */
	float BaseDemandMultiplier { get; set; }

	/*
	 * Maximum value of BaseDemandMultiplier
	 * that can be set with a slider.
	 */
	float MaxEnergyDemand { get; }

	/*
	 * Current energy demand
	 * in units per time-step (1s)
	 */
	float CurrentEnergyDemand { get; }

	// TEMPERATURE
	// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	/*
	 * Current temperature
	 * 0.0f = normal temperature
	 */
	float Temperature { get; set; }

	/*
	 * Maximum temperature
	 */
	float MaxTemperature { get; }

	/*
	 * This determines how fast
	 * the consumer builds up heat,
	 * (e.g. 1.0f - normal, 2.0f - twice as fast),
	 * and determines cooling efficiency.
	 */
	float HeatFactor { get; }

	/*
	 * Overheating flag.
	 * When overheated the consumer
	 * cannot operate before
	 * completely cooling down.
	 */
	bool Overheated { get; set; }

	// COOLING
	// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	/* 
	 * Units of coolant consumed per time step (1s)
	 */
	float CurrentCoolantDemand { get; set; }

	/*
	 * Maximum value of CurrentCoolantDemand
	 * that can be set with a slider.
	 */
	float MaxCoolantDemand { get; }

	// UI
	// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	/*
	 * Reference to the PowerSlider.
	 * PowerSlider sets the BaseDemandMultiplier.
	 */
	UnityEngine.UI.Slider PowerSlider { get; set; }

	/*
	 * Reference to the CoolantSlider.
	 * CoolantSlider sets the CurrentCoolantDemand.
	 */
	UnityEngine.UI.Slider CoolantSlider { get; set; }

	/*
	 * Reference to the HeatSlider.
	 * HeatSlider displays the Temperature.
	 */
	UnityEngine.UI.Slider HeatSlider { get; set; }
}