using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
	public Transform start; // starting position

	void OnTriggerEnter2D(Collider2D hit){

		if(hit.CompareTag("plasma")){

//			Debug.Log ("success"); // logs that the collider is successfull
			hit.transform.position = start.position; // transforms from postion x to start position
		}
	}

}