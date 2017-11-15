/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    private CoolantView coolantView;
    private CoolantModel coolant;
    private CoolantTempStorageModel tempStorage;
    private CoolantPumpModel coolantPump;
    //  private CoolantPumpTypes pumps;

    //To be decide by consumers
    private float neededCoolant = 0f;

    void Awake()
    {
        coolantView = new CoolantView();
        coolant = new CoolantModel("Water");
        coolantPump = new CoolantPumpModel("Class1", 1.0f, 1.0f);
        tempStorage = new CoolantTempStorageModel("", 1000f, 0.0f, 1000f, false, false);
    }

    void Start()
    {
        //  InvokeRepeating("pumpDeliveryTime",1.0f,1.0f);   

    }

    void Update()
    {
        coolantTempStroageStats();
        coolantTypeBeingUsed();
        //retrieveCoolantFromTempStores(neededCoolant);
        pumpDeliveryTime();

        coolantView.DisplayCoolantInfo();


    }

    public void coolantTypeBeingUsed()
    {
        string coolantType = coolant.GetCoolantType();
        tempStorage.SetCoolantType(coolantType);
        coolantView.SetCoolantType(coolantType);
    }

    public void coolantTempStroageStats()
    {
        //--Get Storage stats 
        float storageMaxCap = tempStorage.GetStorageMaxCapacity();
        bool storageAtMax = tempStorage.GetStorageAtMaxCapacity();
        float availCoolant = tempStorage.GetAvailableCoolant();

        if (availCoolant == storageMaxCap)
        {
            storageAtMax = true;
            tempStorage.SetStorageAtMaxCapacity(storageAtMax);
        }

        //--Set Coolant stats
        coolantView.SetStorageCapacity(storageMaxCap -= 1);
        coolantView.SetstorageAtMax(storageAtMax);
    }

    public void retrieveCoolantFromTempStores(float nCoolant)
    {
        bool strEmpty = tempStorage.GetStorageEmpty();
        float storageCoolant = tempStorage.GetAvailableCoolant();
        float storageMin = tempStorage.GetMinimumStorage();
        float coolantRemaining = storageCoolant -= nCoolant;

        if (coolantRemaining <= 0.0f)
        {
            strEmpty = true;
            //--Set Coolant Back to 0.0 and decalre Empty true
            tempStorage.SetAvailableCoolant(storageMin);
            tempStorage.SetStorageEmpty(strEmpty);
            //--set views
            coolantView.SetCoolantAmount(storageMin);
            coolantView.SetStorageEmpty(strEmpty);
        }
        else
        {   //--CoolantReaminig
            tempStorage.SetAvailableCoolant(coolantRemaining);




            coolantView.SetCoolantAmount(storageCoolant);


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

        float newCoolantLevel = 0.0f;
        float coolantPackage = 0.0f;

        float counter = 0.0f;

        if (availCoolant > 0.0f)
        {
            if (counter >= 0.0f)
            {
                counter += Time.deltaTime;
                Debug.Log("TEST!!!");
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
*/
