using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour {
	
	public GameObject Inventory;
	
	void Update () {
		//Make the Menu Visible or Invisible
		if (GlobVars.PlayerPause && !GlobVars.Reading) {
			Inventory.SetActive(true);
		} else {
			Inventory.SetActive(false);
		}
		
		if (SSInput.Strt[0] == "Pressed") {
			if (GlobVars.PlayerPause) {
				GlobVars.PlayerPause = false;
			} else {
				GlobVars.PlayerPause = true;
			}
		}
	}
}
