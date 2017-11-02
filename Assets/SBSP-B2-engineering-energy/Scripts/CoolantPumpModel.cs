using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolantPumpModel
{

    private string pumpType;
    private float deliverySpeedMultiplier;
    private float deliverySpeed;
    //private bool coolantReady;

    public CoolantPumpModel()
    {
        pumpType = "";
        deliverySpeed = 0.0f;
        deliverySpeedMultiplier = 0.0f;
        //coolantReady = false;
    }

    public CoolantPumpModel(string pumpType, float deliverySpeed, float deliverySpeedMultiplier)
    {
        this.pumpType = pumpType;
        this.deliverySpeed = deliverySpeed;
        // this.coolantReady = coolantReady;
        this.deliverySpeedMultiplier = deliverySpeedMultiplier;
    }

    public string GetPumpType()
    { return pumpType; }

    public void SetPumpType(string pumpType)
    { this.pumpType = pumpType; }

    public float GetDeliverySpeed()
    { return deliverySpeed; }

    public void SetDeliverySpeed(float deliverySpeed)
    { this.deliverySpeed = deliverySpeed; }

    public float GetDeliverySpeedMultiplier()
    { return deliverySpeedMultiplier; }

    public void SetDeliverySpeedMultiplier(float deliverySpeedMultiplier)
    { this.deliverySpeedMultiplier = deliverySpeedMultiplier; }

    //  public bool GetCoolantReady()
    //  { return coolantReady; }

    //  public void SetCoolantReady(bool coolantReady)
    //  { this.coolantReady = coolantReady; }
}
