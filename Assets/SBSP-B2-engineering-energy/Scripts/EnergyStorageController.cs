using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyStorageController : MonoBehaviour {

	public EnergyStorage es;
	public GameObject storageSprite;
	public Image esSprite;

	private List<GameObject> storageArray = new List<GameObject>();
	private int sizeOfEnergyArray;


	void Awake(){
		es = new EnergyStorage();
	}


	// Use this for initialization
	void Start () {
		
	}

	public void AddStorage(){
		
		GameObject energyStorageList = Instantiate (storageSprite, new Vector3 ( 300, -69, 0), Quaternion.identity) as GameObject;

		Image[] storageImage = energyStorageList.GetComponentsInChildren<Image> () as Image[];

		energyStorageList.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);

		storageArray.Add (energyStorageList);
	}

	public void MaxCap(){

		if (es.GetMaxCapacityReached()) {
			
		}
	}
}
