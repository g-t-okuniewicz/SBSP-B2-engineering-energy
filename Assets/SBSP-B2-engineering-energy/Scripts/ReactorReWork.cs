using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactorReWork : MonoBehaviour {

	public ArrayList rectorList;

	public GameObject reactor;
	public GameObject[] reactorArr = new GameObject[3];

	public ReactorModel rm;
	public ReactorView rv;



	// Use this for initialization
	void Start () {
		rm = new ReactorModel ();
		reactor = GameObject.Find ("reactor").GetComponent<GameObject>();
	}

	// Update is called once per frame
	void Update () {


	}

	public void AddReactor(){
		for (int i = 0; i < reactorArr.Length; i++) {
			GameObject go = Instantiate(reactor, new Vector3((float)i, 1, 0), Quaternion.identity) as GameObject;
			go.transform.localScale = Vector3.one;
			reactorArr[i] = go;
		}
	}
		
}
