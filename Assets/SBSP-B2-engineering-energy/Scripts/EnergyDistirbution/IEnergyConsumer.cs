interface IEnergyConsumer {

	// Display name.
	string Name { get; }

	// Units of energy consumed per second
	// when working normally.
	// Should be constant.
	// This will be multiplied by MaxEnergyOverride
	// to calculate total energy consumption
	float BaseEnergyConsumption { get; }

	// Max multiplier.
	// Should be constant.
	// Maximum power overdrive that can be set
	// with PowerSlider.
	float MaxEnergyOverdrive { get; }

	// This determines how fast
	// the consumer builds up heat.
	// e.g. 1.0f - normal, 2.0f - twice as fast
	float HeatFactor { get; }

	// Reference to UI sliders.

	// Power Slider sets the energy
	UnityEngine.UI.Slider PowerSlider { get; set; }
	UnityEngine.UI.Slider CoolantSlider { get; set; }
	UnityEngine.UI.Slider HeatSlider { get; set; }
}