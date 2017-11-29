//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
using UnityEngine.UI;

public class EnergyConsumer : IEnergyConsumer {

	// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
	// implementation of IEnergyConsumer
	// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	/*
	 * Display name.
	 */
	protected string name;
	public string Name { get { return name; } }

	// ENERGY
	// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	/* 
	 * Units of energy consumed per time unit
	 * during normal operation - when currentEnergyMultiplier = 1.0f.
	 * This will be multiplied by currentEnergyMultiplier
	 * to calculate total energy consumption.
	 */
	protected float baseEnergyDemand;
	public float BaseEnergyDemand { get { return baseEnergyDemand; } }

	/*
	 * Adjusted with a slider during gameplay.
	 * Multiplied by BaseEnergyDemand
	 * to calcuate CurrentEnergyDemand.
	 * < 1.0f - underperforming
	 * = 1.0f - normal operation
	 * > 1.0f - overdrive
	 */
	protected float baseDemandMultiplier;
	public float BaseDemandMultiplier { 
		get { return baseDemandMultiplier; }
		set { baseDemandMultiplier = value; }
	}

	/*
	 * Maximum value of BaseDemandMultiplier
	 * that can be set with a slider.
	 */
	protected float maxEnergyDemand;
	public float MaxEnergyDemand { get { return maxEnergyDemand; } }

	/*
	 * Current energy demand
	 * in units per time-step (1s)
	 */
	public float CurrentEnergyDemand { get { return baseDemandMultiplier * baseEnergyDemand; } }

	protected float temperature;
	public float Temperature {
		get { return temperature; }
		set { temperature = value; }
	}

	// TEMPERATURE
	// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	/*
	 * Maximum temperature
	 * at which the consumer stops
	 * working and must wait
	 * until cooled down
	 * back to 0.0f
	 */
	protected float maxTemperature;
	public float MaxTemperature { get { return maxTemperature; } }

	/*
	 * This determines how fast
	 * the consumer builds up heat,
	 * (e.g. 1.0f - normal, 2.0f - twice as fast),
	 * and determines cooling efficiency.
	 */
	protected float heatFactor;
	public float HeatFactor { get { return heatFactor; } }

	/*
	 * Overheating flag.
	 * When overheated the consumer
	 * cannot operate before
	 * completely cooling down.
	 */
	protected bool overheated = false;
	public bool Overheated {
		get { return overheated; }
		set { overheated = value; }
	}

	// COOLING
	// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	/* 
	 * Units of coolant consumed per time step (1s)
	 */
	protected float currentCoolantDemand;
	public float CurrentCoolantDemand {
		get { return currentCoolantDemand; }
		set { currentCoolantDemand = value; }
	}

	/*
	 * Maximum value of CurrentCoolantDemand
	 * that can be set with a slider.
	 */
	protected float maxCoolantDemand;
	public float MaxCoolantDemand { get { return maxCoolantDemand; } }

	// UI
	// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	/*
	 * Reference to the PowerSlider.
	 * PowerSlider sets the BaseDemandMultiplier.
	 */
	protected Slider powerSlider, coolantSlider, heatSlider;
	public Slider PowerSlider { 
		get { return powerSlider; }
		set { powerSlider = value; }
	}

	/*
	 * Reference to the CoolantSlider.
	 * CoolantSlider sets the CurrentCoolantDemand.
	 */
	public Slider CoolantSlider { 
		get { return coolantSlider; }
		set { coolantSlider = value; }
	}

	/*
	 * Reference to the HeatSlider.
	 * HeatSlider displays the Temperature.
	 */
    public Slider HeatSlider { 
		get { return heatSlider; }
		set { heatSlider = value; }
	}
		
	// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
	// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	public EnergyConsumer(string name, float baseEnergyDemand, float heatFactor) {
		this.name = name;
		this.baseEnergyDemand = baseEnergyDemand;
		this.heatFactor = heatFactor;
		baseDemandMultiplier = 1.0f;
		maxEnergyDemand = 2.0f;
		temperature = 0.0f;
		maxTemperature = 10.0f;
		currentCoolantDemand = 0.0f;
		maxCoolantDemand = 3.0f;
	}

	public EnergyConsumer(
		string name,
		float baseEnergyDemand,
		float maxEnergyDemand,
		float maxTemperature,
		float heatFactor,
		float maxCoolantDemand) 
	{
		this.name = name;
		this.baseEnergyDemand = baseEnergyDemand;
		this.maxEnergyDemand = maxEnergyDemand;
		this.maxTemperature = maxTemperature;
		this.heatFactor = heatFactor;
		this.maxCoolantDemand = maxCoolantDemand;
		baseDemandMultiplier = 1.0f;
		temperature = 0.0f;
		currentCoolantDemand = 0.0f;
	}



    public override bool Equals(object obj)
    {
        if(obj is EnergyConsumer)
        {
            EnergyConsumer other = obj as EnergyConsumer;
            return other.Name.Equals(name) && other.baseEnergyDemand == baseEnergyDemand;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return string.Format("{0}_{1}", name, baseEnergyDemand).GetHashCode();
    }
}