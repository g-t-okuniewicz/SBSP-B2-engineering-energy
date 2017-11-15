using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class PersistanStorage : MonoBehaviour
{


    //Static reference to itself...Call this for reference to Persistant storage
    // tempStorage.Save();---Save Data
    // tempStorage.Load();---Load Data
    public static PersistanStorage persistantStorage;

    //Example's permanent data
    public float coolant;
    public float energy;
   
    
    void Start() { DontDestroyOnLoad(gameObject); }

    void Update()
    {   //Displaying the example persistant storage
     //   Text persistantStorageCoolant = GameObject.FindWithTag("persistantStorageCoolant").GetComponent<Text>();
     //   Text persistantStorageEnergy = GameObject.FindWithTag("persistantStorageEnergy").GetComponent<Text>();
    //    persistantStorageCoolant.text = "Coolant: " + coolant;
    //    persistantStorageEnergy.text = "Energy: " + energy;
    }

    //dont destroy on awake, the static reference on awake
    void Awake()

    {
        this.InstantiateErsistantStorage();
     //   if (persistantStorage == null)
     //  {
     //      DontDestroyOnLoad(gameObject);
     //      persistantStorage = this;

        //  }else if (persistantStorage != this)
        //     { Destroy(gameObject); }
    }

    private void InstantiateErsistantStorage()
    {
           if (persistantStorage == null)
        {
            persistantStorage = this;
            DontDestroyOnLoad(gameObject);
            

          }else if (this != persistantStorage )
             { Destroy(this.gameObject); }
    }


    void OnGUI()
    {
        GUI.Label(new Rect(700, 15, 100, 30), "Coolant:" + coolant);
        GUI.Label(new Rect(700, 30, 100, 30), "Energy:" + energy);
    }
/*
    //Save data to file call this method...Input variables to save throught methods save , load and class at bottom of script
    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //Unitys persistant data path---Place to save data 
        FileStream file = File.Open(Application.persistentDataPath + "/energyNetworkPersistantData.dat", FileMode.Open );



        //Add variables of data to be saved here
        //--------------------------------------------------------------------------------------------------------------

        //Instance of class, check end of script for class
        EnergyNetworkData energyData = new EnergyNetworkData();

        energyData.coolant = coolant;
        energyData.energy = energy;



        //--------------------------------------------------------------------------------------------------------------


        formatter.Serialize(file, energyData);
        file.Close();
    }
    //Load previous saved data, call this method
    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/energyNetworkPersistantData.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/energyNetworkPersistantData.dat", FileMode.Open);
            EnergyNetworkData energyData = (EnergyNetworkData)formatter.Deserialize(file);
            file.Close();

            //Add variables of data to be loaded here
            //-------------------------------------------------------------------------------------------------------------
            coolant = energyData.coolant;
            energy = energyData.energy;





            //-------------------------------------------------------------------------------------------------------------
        }
    }

}

[Serializable]
class EnergyNetworkData
{   
    //Add Variables of data to this class
    //-------------------------------------------------------------------------------------------------------------------------
    public float coolant = 30.0f;
    public float energy = 63f;


    //-------------------------------------------------------------------------------------------------------------------------

    */
}

