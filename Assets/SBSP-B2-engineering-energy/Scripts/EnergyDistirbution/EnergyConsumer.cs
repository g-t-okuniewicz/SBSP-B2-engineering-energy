//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
using UnityEngine.UI;

public class EnergyConsumer : IEnergyConsumer {

	// -------------------------------------
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

	// no. of units of energy consumed per time unit
	// during normal operation - when currEnergyMultiplier = 1.0f
	protected float baseEnergyConsumption;
    public float BaseEnergyConsumption { get { return baseEnergyConsumption; } }

	// < 1.0f - underperforming
	// = 1.0f - normal operation
	// > 1.0f - overdrive
	protected float currentEnergyMultiplier = 1.0f;

	protected float heatFactor;
	public float HeatFactor { get { return heatFactor; } }


	protected const float MAX_ENERGY_OVERDRIVE = 2.0f;
	public float MaxEnergyOverdrive { get { return MAX_ENERGY_OVERDRIVE; } }

	// -------------------------------------

	public EnergyConsumer(string name, float baseEnergyConsumption) {
		this.name = name;
		this.baseEnergyConsumption = baseEnergyConsumption;
	}



	/*public float GetCurrentEnergyConsumption() {
		return currentEnergyMultiplier * baseEnergyConsumption;
	}*/

	//----
	public float CurrentEnergyMultiplier { get { return currentEnergyMultiplier; } }

	public float EnergyConsumption { get { return currentEnergyMultiplier * baseEnergyConsumption; } }

	/*public void SetSliders(Slider powerSlider, Slider coolantSlider, Slider heatSlider) {
		this.powerSlider = powerSlider;
		this.coolantSlider = coolantSlider;
		this.heatSlider = heatSlider;
	}*/

	public void SetSliders(Slider[] sliders) {
		powerSlider = sliders [0];
		powerSlider.minValue = 0;
		powerSlider.maxValue = MAX_ENERGY_OVERDRIVE;
		powerSlider.onValueChanged.AddListener (delegate {
			UpdateEnergyMultiplier ();
		});
		coolantSlider = sliders [1];
		heatSlider = sliders [2];
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
