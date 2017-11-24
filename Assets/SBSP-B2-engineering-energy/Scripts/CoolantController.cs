using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolantController
{
    public CoolantModel coolant = new CoolantModel("Water");
    public CoolantTempStorageModel tempStorage = new CoolantTempStorageModel("", 1000.0f, 0.0f, 1000f, false, false, false, false, 0.0f);
    public CoolantPumpModel coolantPump = new CoolantPumpModel("Class1", 1.0f, 1.0f);
    public CoolantPumpTypes pumps;
    float coolantPackage;
    bool coolantReady;
    float counter = 0f;
    float[] coolantPackageArray;
    public bool coolantPackageFlag = false;
    float coolantRemaining;

    //To be decide by consumers
    public bool coolantFlag = false;
    public float neededCoolant;
 
    public void pumpInfo()//Basic Pump info
    {
        string coolPump = coolantPump.GetPumpType();
    }

    public void coolantTypeBeingUsed()//Basic Coolant info
    {
        string coolantType = coolant.GetCoolantType();
        tempStorage.SetCoolantType(coolantType);
    }

    public void coolantTempStroageInfo()//Storage MaxCapacity set too 1000f. Available coolant info. Max capacity bool depending on coolant level.
    {
        float storageMaxCap = tempStorage.GetStorageMaxCapacity();
        bool storageAtMax = tempStorage.GetStorageAtMaxCapacity();
        float availCoolant = tempStorage.GetAvailableCoolant();

        if (availCoolant == storageMaxCap)
        {
            storageAtMax = true;
            tempStorage.SetStorageAtMaxCapacity(storageAtMax);
        }
        else { storageAtMax = false; }
    }

    public void exampleOutsideConsumerMethod()
    {
        coolantFlag = true;// Set too true if coolant is needed from consumer,
        //needed coolant from consumer will be taken away from available coolant(set too 1000f, change as you want)
        //This will allow the consumer coolant to be taken away once from available coolant in Update
        tempStorage.SetCoolantNeeded(coolantFlag);
        neededCoolant = 50f;//Example number, representing the consumer coolant needed
        coolantPackageFlag = true;//This will allow to run once in update *1
    }

    public void coolantNeededCalc()
    {//coolantNeededFlag will allow the method to run once in update,this will stop a constant minus of stored coolant
       // tempStorage.SetCoolantNeeded(coolantFlag);
        bool coolantNeededFlag = tempStorage.GetCoolantNeeded();
   
        if (coolantNeededFlag == true)
        {
            float storageCoolant = tempStorage.GetAvailableCoolant();
            float coolantRemaining = storageCoolant - neededCoolant;
            tempStorage.SetAvailableCoolant(coolantRemaining);
            coolantNeededFlag = false;
            tempStorage.SetCoolantNeeded(coolantNeededFlag);
        }
    }

    public void retrieveCoolantFromTempStores()
    {
        bool storageAtMax = tempStorage.GetStorageAtMaxCapacity();
        bool strEmpty = tempStorage.GetStorageEmpty();
        float storageMin = tempStorage.GetMinimumStorage();
        float availableCoolant = tempStorage.GetAvailableCoolant();
        bool coolantReady = tempStorage.GetCoolantReady();
        float coolantPackage = tempStorage.GetCoolantPackage();

        if (availableCoolant <= 0.0f)
        {
            strEmpty = true;
            tempStorage.SetAvailableCoolant(storageMin);
            tempStorage.SetStorageEmpty(strEmpty);
        }else{

            if (!(neededCoolant <= 0) && coolantPackageFlag == true)
            {   //coolantPackageFlag will allow this part of the method to run once at a time in update, 
              
                neededCoolant -= 1.0f;
                float newPackage = coolantPackage += 1.0f;
                tempStorage.SetCoolantPackage(newPackage);
              

                if (coolantPackage >= 50.0f)
                {
                    float packageReset = 0.0f;
                    coolantReady = true;
                    tempStorage.SetCoolantReady(coolantReady);
                    //Package Reset to set package back to 0 if needed.
                    //tempStorage.SetCoolantPackage(packageReset);
                    coolantPackageFlag = false;
                    //Call GetCoolantPackage to retrieve 50f or coolant for consumers- Change to suit yourself
                }//Change method as you want if you dont want to use packages, just a slow stream is optional.
            }//Also can add Delta time, for a cooldown
            strEmpty = false;
        }
    }
}

    
          




       
        


