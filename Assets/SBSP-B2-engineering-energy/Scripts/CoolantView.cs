using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolantView : MonoBehaviour
{
    public CoolantController coolController;

    void Awake()
    {
        coolController = new CoolantController();

    }

    void FixedUpdate() {}
    void Start() {
        //This is just an example of how you could call use for consumers. 
        coolController.exampleOutsideConsumerMethod();
    }

    void Update()
    {
        coolController.pumpInfo();
        coolController.coolantTypeBeingUsed();
        coolController.coolantNeededCalc();
        coolController.retrieveCoolantFromTempStores();
        coolController.coolantTempStroageInfo();
    }
  
    void OnGUI()
    {
        // All text outputs are actual outputs, if needed, use the code to collect the outputs.
        GUI.Label(new Rect(100, 15, 200, 40), "CoolantAvailable: " + coolController.tempStorage.GetAvailableCoolant());
        GUI.Label(new Rect(100, 35, 200, 40), "CoolantType: " + coolController.coolant.GetCoolantType());
        GUI.Label(new Rect(100, 55, 200, 40), "Storage Capacity: " + coolController.tempStorage.GetStorageMaxCapacity());
        GUI.Label(new Rect(100, 75, 200, 40), "Storage At Max: " + coolController.tempStorage.GetStorageAtMaxCapacity());
        GUI.Label(new Rect(100, 95, 200, 40), "Storage Empty: " + coolController.tempStorage.GetStorageEmpty());
        GUI.Label(new Rect(100, 115, 200, 40), "Pump Type: " + coolController.coolantPump.GetPumpType());
        GUI.Label(new Rect(100, 135, 200, 40), "Coolant Ready: " + coolController.tempStorage.GetCoolantReady());
        GUI.Label(new Rect(100, 155, 200, 40), "Coolant Needed Flag: " + coolController.tempStorage.GetCoolantNeeded());
        GUI.Label(new Rect(100, 175, 200, 40), "Coolant Package: " + coolController.tempStorage.GetCoolantPackage());
    }
}
