using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolantController : MonoBehaviour
{   
        private CoolantView coolantView;
        private CoolantModel coolant;
        private CoolantTempStorageModel tempStorage;
        private CoolantPumpModel coolantPump;
        //  private CoolantPumpTypes pumps;
        float coolantPackage;
        //To be decide by consumers
        private float neededCoolant = 1.0f;

        void Awake()
        {
            coolantView = new CoolantView();
            coolant = new CoolantModel("Water");
            coolantPump = new CoolantPumpModel("Class1",1.0f,1.0f);
            tempStorage = new CoolantTempStorageModel("", 1000f, 0.0f, 1000f, false, false);
        }

        void Start()
        {
        //  InvokeRepeating("pumpDeliveryTime",1.0f,1.0f);   
        }

        void Update()
        {
        coolantTypeBeingUsed();
        pumpInfo();
        coolantTempStroageInfo();
        retrieveCoolantFromTempStores(neededCoolant);
    //   pumpDeliveryTime();
        coolantView.DisplayCoolantInfo();
        }

        public void coolantTypeBeingUsed()
        {
            string coolantType = coolant.GetCoolantType();
            tempStorage.SetCoolantType(coolantType);
            coolantView.SetCoolantType(coolantType);
        }

        public void coolantTempStroageInfo()
        { 
            //--Get Storage stats 
            float storageMaxCap = tempStorage.GetStorageMaxCapacity();
            bool storageAtMax = tempStorage.GetStorageAtMaxCapacity();
            float availCoolant = tempStorage.GetAvailableCoolant();
        
            if(availCoolant == storageMaxCap)
            {
                storageAtMax = true;
                tempStorage.SetStorageAtMaxCapacity(storageAtMax);
            }else{ storageAtMax = false; }

            //--Set Coolant stats
            coolantView.SetStorageCapacity(storageMaxCap);
            coolantView.SetstorageAtMax(storageAtMax);
        }

    public void pumpInfo()
    {
        string coolPump = coolantPump.GetPumpType();
        coolantView.SetPumpType(coolPump);
    }

    public void retrieveCoolantFromTempStores(float nCoolant)
    {
        // bool storageAtMax = tempStorage.GetStorageAtMaxCapacity();
        
        bool strEmpty = tempStorage.GetStorageEmpty();
        float storageCoolant = tempStorage.GetAvailableCoolant();
        float storageMin = tempStorage.GetMinimumStorage();
        float coolantRemaining = storageCoolant -= nCoolant;
        bool coolReady = coolantView.GetCoolantReady();

        //  float availCoolant = tempStorage.GetAvailableCoolant();
        float counter = 0.0f;
        float newCoolantLevel = 0.0f;
       

        if (coolantRemaining <= 0.0f)
        {
            strEmpty = true;
            //--Set Coolant Back to 0.0 and decalre Empty true
            tempStorage.SetAvailableCoolant(storageMin);
            tempStorage.SetStorageEmpty(strEmpty);
            //--set views
            coolantView.SetCoolantAmount(storageMin);
            coolantView.SetStorageEmpty(strEmpty);

        }else{   //--CoolantReaminig

            tempStorage.SetAvailableCoolant(coolantRemaining);
            counter += Time.deltaTime;
            //------------------------------------------
            if (counter >= 30.0f)
            {
                coolantPackage += 0.01f;
                newCoolantLevel = storageCoolant -= 1.0f;
                tempStorage.SetAvailableCoolant(newCoolantLevel);
               
                counter = 0.0f;

             if (coolantPackage >= 0.1f){
                    coolReady = true;      
                }
                    coolantView.SetCoolantReady(coolReady);
                }
              
                coolantView.SetCoolantAmount(storageCoolant);
             //coolantView.SetCoolantReady(coolReady);


            //--Coolant Empty
            strEmpty = false;
            coolantView.SetStorageEmpty(strEmpty);
            }
        }


    public void pumpDeliveryTime()
    {
        string pumptype = coolantPump.GetPumpType();
        float pumpSpeed = coolantPump.GetDeliverySpeed();
        float pumpMultiplier = coolantPump.GetDeliverySpeedMultiplier();



        bool coolReady = coolantView.GetCoolantReady();
        float availCoolant = tempStorage.GetAvailableCoolant();

        float newCoolantLevel=0.0f;
        float coolantPackage = 0.0f;

        float counter = 0.0f;

        if (availCoolant > 0.0f)
       {
            if (counter >= 0.0f)
            { 
                counter += Time.deltaTime;
                newCoolantLevel = availCoolant -= 10.01f;
                tempStorage.SetAvailableCoolant(availCoolant -= 0.01f); 
                coolantPackage += 0.01f;
                counter = 0.0f;
           }
           if (coolantPackage == 0.01f) { coolReady = true; }
        }
        //tempStorage.SetAvailableCoolant(availCoolant -= 0.01f);
        coolantView.SetCoolantAmount(tempStorage.GetAvailableCoolant());
        coolantView.SetPumpType(pumptype);
        coolantView.SetCoolantReady(coolReady);
    }
  }        




       
        


