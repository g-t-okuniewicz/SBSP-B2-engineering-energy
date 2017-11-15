using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlasma : MonoBehaviour {
	public float speed = 5f; // speed that the plasma is moving 

	void Update () {
		
		transform.Translate (speed * Time.deltaTime, 0, 0); // plasma travelling rate
	}
}
