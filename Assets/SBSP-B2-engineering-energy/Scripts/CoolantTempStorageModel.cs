using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CoolantTempStorageModel 
    {
       // public static CoolantTempStorage tempStorage;//Static reference to itself

        private string coolantType;
        private float availableCoolant;
        private float storageMaxCapacity;
        private float minimumStorage;
        private bool storageEmpty;
        private bool storageAtMaxCapacity;


        public CoolantTempStorageModel()
        {
            coolantType = "";
            availableCoolant =0.0f;
            minimumStorage = 0.0f;
            storageMaxCapacity = 0.0f;
            storageAtMaxCapacity = false;
            storageEmpty = false;
        }

        public CoolantTempStorageModel(string coolantType, float availableCoolant, float minimumStorage,
            float storageMaxCapacity, bool storageAtMaxCapacity, bool storageEmpty)
        {
            this.coolantType = coolantType;
            this.availableCoolant = availableCoolant;
            this.minimumStorage = minimumStorage;
            this.storageMaxCapacity = storageMaxCapacity;
            this.storageAtMaxCapacity = storageAtMaxCapacity;
            this.storageEmpty = storageEmpty;
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

    //dont destroy on awake the static reference on awake
    //    void Awake()
    //    {
    //     if (tempStorage == null)
    //       {
    //           DontDestroyOnLoad(gameObject);
    //          tempStorage = this;
    //       }
    //     else if (tempStorage != this)
    //      {
    //          Destroy(gameObject);
    //       }

}

