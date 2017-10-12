using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnrgyConverter : MonoBehaviour {
	
	public int darkMatter; // Resources from inventory
	public int gemStone;  // resource
	public int plasma;
	public string requestDarkMatter = "We need more plasma";
	public string requestGemStone = "We need more Gems";
	public Text gem;//

	//public Inventory inventory; // Referencing the Inventory script from Mapping team 


	void Start () {
		
		// Calling the inventory script
		//inventory = GetComponent<Inventory> (); 
		// Plasma to initial because none present
		darkMatter = 1; 
		gemStone = 1;
		plasma = 0;


	}

	/*
	 * Update is called once per frame
	 * checks for resources
	 */
	void Update () {
		gem = GetComponent<Text>();
		gem.text = "GemStone : " + gemStone;
	
		CheckDarkMatter (); 
		CheckGemStone ();
		ConvertResource ();

	}

	/*
	 * Check for available dark matter
	 * if available, add 1,  else == 0,  request more.
	 */
	public void CheckDarkMatter(){

		if (darkMatter >= 1) {
			//If there is add 1 to darkMatter
			darkMatter = darkMatter + 1;
		} 
		else if(darkMatter == 0){
			// Notify the other team that we need resources
			// Print message that we need resources
			print(requestDarkMatter);

		}
	}// end CheckDarkMatter

	public void CheckGemStone(){

		if (gemStone >= 1) {
			//If there is add 5 to gemstone
			gemStone = gemStone + 1;
		} 
		else if(gemStone == 0){
			// Notify the other team that we need resources
			// Print message that we need resources
			print(requestGemStone);

		}
	}	

	/*
	 * Convert resource to plasma
	 * 1 dark matter unit is == 10 plasma units
	 */
	public void ConvertResource(){
		// 1 dark matter unit is the equivelant to 10 plasma units
		plasma = darkMatter * 10;
		plasma = gemStone * 5;

	
	}// end ConvertResource


}
