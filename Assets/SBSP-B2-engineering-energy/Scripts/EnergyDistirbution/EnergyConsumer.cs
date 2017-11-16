//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
using UnityEngine.UI;

public class EnergyConsumer : IEnergyConsumer {

	// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
	// implementation of IEnergyConsumer

	// protected -- visible to this class and subclasses
	protected string name;
	public string Name { get { return name; } }

	protected Slider powerSlider, coolantSlider, heatSlider;
	public Slider PowerSlider { 
		get { return powerSlider; }
		set { powerSlider = value; }
	}
	public Slider CoolantSlider { 
		get { return coolantSlider; }
		set { coolantSlider = value; }
	}
    public Slider HeatSlider { 
		get { return heatSlider; }
		set { heatSlider = value; }
	}

	protected float heat = 0.0f;
	public float Heat {
		get {
			return heat;
		}
		set {
			heat = value;
		}
	}

	// no. of units of energy consumed per time unit
	// during normal operation - when currEnergyMultiplier = 1.0f
	protected float baseEnergyConsumption;
    public float BaseEnergyConsumption { get { return baseEnergyConsumption; } }

	protected float heatFactor;
	public float HeatFactor { get { return heatFactor; } }

	protected const float MAX_ENERGY_OVERDRIVE = 2.0f;
	public float MaxEnergyOverdrive { get { return MAX_ENERGY_OVERDRIVE; } }

	// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	public EnergyConsumer(string name, float baseEnergyConsumption, float heatFactor) {
		this.name = name;
		this.baseEnergyConsumption = baseEnergyConsumption;
		this.heatFactor = heatFactor;
	}
		
	//----
	// < 1.0f - underperforming
	// = 1.0f - normal operation
	// > 1.0f - overdrive
	protected float currentEnergyMultiplier = 1.0f;
	public float CurrentEnergyMultiplier { 
		get { return currentEnergyMultiplier; }
		set { currentEnergyMultiplier = value; }
	}

	public float EnergyConsumption { get { return currentEnergyMultiplier * baseEnergyConsumption; } }

	public void SetSliders(Slider[] sliders) {
		// Power Slider
		powerSlider = sliders [0];
		powerSlider.minValue = 0;
		powerSlider.maxValue = MAX_ENERGY_OVERDRIVE;
		powerSlider.onValueChanged.AddListener (delegate {
			UpdateEnergyMultiplier ();
		});

		// Coolant Slider
		coolantSlider = sliders [1];

		// Heat Slider
		heatSlider = sliders [2];
		heatSlider.interactable = false;
		heatSlider.minValue = 0.0f;
		heatSlider.maxValue = 10.0f;
	}

	public void UpdateEnergyMultiplier () {
		currentEnergyMultiplier = powerSlider.value;
	}

    public override bool Equals(object obj)
    {
        if(obj is EnergyConsumer)
        {
            EnergyConsumer other = obj as EnergyConsumer;
            return other.Name.Equals(name) && other.baseEnergyConsumption == baseEnergyConsumption;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return string.Format("{0}_{1}", name, baseEnergyConsumption).GetHashCode();
    }
}