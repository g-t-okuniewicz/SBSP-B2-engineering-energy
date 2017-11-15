using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolantView 
{
    public string coolantType;
    public float coolantAvailabe;

    public float storageCapacity;
    public bool storageEmpty;
    public bool storageAtMax;

    private string pumpType;
    private bool coolantReady;

    //GET OTHER........

    //coolant stores

    public CoolantView()
    {
        coolantType = "";
        coolantAvailabe = 0.0f;
        storageCapacity = 0.0f;
        storageEmpty = false;
        storageAtMax = false;
        pumpType = "";
        coolantReady = false;
    }

    public CoolantView(string coolantTyp, float coolantAmt, float storageCapacity, bool storageAtMax,
       string pumpType, bool coolantReady, bool storageEmpty)
    {   
        this.coolantType = coolantTyp;    
        this.coolantAvailabe = coolantAmt;
        this.storageCapacity = storageCapacity;
        this.storageEmpty = storageEmpty;
        this.storageAtMax = storageAtMax;
        this.pumpType = pumpType;
        this.coolantReady = coolantReady;


    }

    public string GetCoolantType() { return coolantType; }
    public void SetCoolantType(string coolantTyp) { this.coolantType = coolantTyp; }
   
    public float GetCoolantAmount() { return coolantAvailabe; }
    public void SetCoolantAmount(float coolantAmt) { this.coolantAvailabe = coolantAmt; }

    public float GetStorageCapacity() { return storageCapacity; }
    public void SetStorageCapacity(float storageCapacity) { this.storageCapacity = storageCapacity; }

    public bool GetStorageAtMax() { return storageAtMax; }
    public void SetstorageAtMax(bool storageAtMax) { this.storageAtMax = storageAtMax; }

    public string GetPumpType() { return pumpType; }
    public void SetPumpType(string pumpType) { this.pumpType = pumpType; }

    public bool GetCoolantReady() { return coolantReady; }
    public void SetCoolantReady(bool coolantReady) { this.coolantReady = coolantReady; }

    public bool GetStorageEmpty() { return storageEmpty; }
    public void SetStorageEmpty(bool storageEmpty) { this.storageEmpty = storageEmpty; }

    void FixedUpdate(){}
    void Awake(){}
    void Start(){ }
    void Update(){}

    public void DisplayCoolantInfo()
    {
        // float CoolantAmount = float.Parse(coolantAmtText.text);
        Text coolantTypText = GameObject.FindWithTag("CoolantType").GetComponent<Text>();
        Text coolantAmtText = GameObject.FindWithTag("CoolantAmount").GetComponent<Text>();

        Text storageCapacityText = GameObject.FindWithTag("StorageCapacity").GetComponent<Text>();
        Text storageAtMaxText = GameObject.FindWithTag("StorageAtMax").GetComponent<Text>();
        Text storageEmpty = GameObject.FindWithTag("StorageEmpty").GetComponent<Text>();

        Text pumpTypeText = GameObject.FindWithTag("PumpType").GetComponent<Text>();
        Text coolantReadyText = GameObject.FindWithTag("CoolantReady").GetComponent<Text>();

        coolantAmtText.text = "CoolantAvailable: " + GetCoolantAmount();
        coolantTypText.text = "CoolantType: " + GetCoolantType();
        storageCapacityText.text = "Storage Capacity: "+ GetStorageCapacity();
        storageAtMaxText.text = "Storage At Max: " + GetStorageAtMax();
        storageEmpty.text = "Storage Empty: " + GetStorageEmpty();
        pumpTypeText.text = "Pump Type: " + GetPumpType();
        coolantReadyText.text = "Coolant Ready: " + GetCoolantReady();

    }

}
