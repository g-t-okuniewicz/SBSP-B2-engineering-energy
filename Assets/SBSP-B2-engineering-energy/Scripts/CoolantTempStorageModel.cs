using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolantTempStorageModel 
{
       // public static CoolantTempStorage tempStorage;//Static reference to itself

    string coolantType;
    float availableCoolant;
    float storageMaxCapacity;
    float minimumStorage;
    float coolantPackage;
    bool storageEmpty;
    bool storageAtMaxCapacity;
    bool coolantReady;
    bool coolantNeeded;


    public CoolantTempStorageModel()
    {
        coolantType = "";
        availableCoolant =0.0f;
        minimumStorage = 0.0f;
        storageMaxCapacity = 0.0f;
        storageAtMaxCapacity = false;
        storageEmpty = false;
        coolantReady = false;
        coolantPackage = 0.0f;

    }

    public CoolantTempStorageModel(string coolantType, float availableCoolant, float minimumStorage,
            float storageMaxCapacity, bool storageAtMaxCapacity, bool storageEmpty, bool coolantReady, bool coolantNeeded, float coolantPackage)
        {
            this.coolantType = coolantType;
            this.availableCoolant = availableCoolant;
            this.minimumStorage = minimumStorage;
            this.storageMaxCapacity = storageMaxCapacity;
            this.storageAtMaxCapacity = storageAtMaxCapacity;
            this.storageEmpty = storageEmpty;
            this.coolantReady = coolantReady;
            this.coolantNeeded = coolantNeeded;
            this.coolantPackage = coolantPackage;
    }


        public string GetCoolantType()
        { return coolantType; }
        public void SetCoolantType(string coolantType)
        {this.coolantType = coolantType;}

        public float GetAvailableCoolant()
        {return availableCoolant;}
        public void SetAvailableCoolant(float availableCoolant)
        {this.availableCoolant = availableCoolant;}

        public float GetStorageMaxCapacity()
        { return storageMaxCapacity;}
        public void SetStorageMaxCapacity(float storageMaxCapacity)
        {this.storageMaxCapacity = storageMaxCapacity;}

        public bool GetStorageAtMaxCapacity()
        { return storageAtMaxCapacity;}
        public void SetStorageAtMaxCapacity(bool storageAtMaxCapacity)
        {this.storageAtMaxCapacity = storageAtMaxCapacity;}

        public bool GetStorageEmpty()
        { return storageEmpty; }
        public void SetStorageEmpty(bool storageEmpty)
        { this.storageEmpty = storageEmpty; }

        public float GetMinimumStorage()
        { return minimumStorage; }
        public void SetMinimumStorage(float minimumStorage)
        { this.minimumStorage = minimumStorage; }

        public bool GetCoolantReady()
        { return coolantReady; }
        public void SetCoolantReady(bool coolantReady)
        { this.coolantReady = coolantReady; }

        public bool GetCoolantNeeded()
        { return coolantNeeded; }
        public void SetCoolantNeeded(bool coolantNeeded)
        { this.coolantNeeded = coolantNeeded; }

        public float GetCoolantPackage()
        { return coolantPackage; }
        public void SetCoolantPackage(float coolantPackage)
        { this.coolantPackage = coolantPackage; }

}

