using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactorReWork : MonoBehaviour {

	
	public Image reactor;
	public Image reactor1;
	public Image reactor2;


	public ReactorModel rm;
	public ReactorView rv;



	// Use this for initialization
	void Start () {
		rm = new ReactorModel ();
		reactor.enabled = true;
		reactor1.enabled = false;
		reactor2.enabled = false;

	}

	// Update is called once per frame
	void Update () {


	}

	public void AddReactor(){
		

//		for (int i = 0; i < images.Capacity; i++) {
		if(!reactor1.enabled){
			reactor1.enabled = true;
		}

		else {
			reactor2.enabled = true;
		}

//			images.Add (imageSprite);
//			Image iI = Instantiate (reactor);
//			iI.transform.SetParent (this.transform, true);
//			iI.sprite = images [i];
//			reactor.enabled = true;
			print ("Reactor added");

//			GameObject go = Instantiate(reactor, new Vector3((float)i, 1, 0), Quaternion.identity) as GameObject;
//			go.transform.localScale = Vector3.one;
//			reactorArr[i] = go;
//		}
	}
		
}
