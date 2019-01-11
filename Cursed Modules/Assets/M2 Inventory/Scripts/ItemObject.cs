using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour {
	
	public Item AssociatedItem;
	
<<<<<<< HEAD
	public float Range;
	
	void Update () {
		
		float Dist = 10000;
		
		float DFP = Vector3.Distance (transform.position, GameObject.Find("Player").transform.position);
		
		foreach (ItemObject I in GameObject.FindObjectsOfType<ItemObject>()) {
			
			DFP = Vector3.Distance (I.transform.position, GameObject.Find("Player").transform.position);
			
<<<<<<< HEAD
			if (DFP < Dist) {
=======
			if (DFP < Dist && DFP <= Range) {
>>>>>>> parent of a0d4f02... Bugs and Optimizing
				Dist = DFP;
			}
		}
		
		DFP = Vector3.Distance (transform.position, GameObject.Find("Player").transform.position);
		
		if (Dist == DFP && DFP <= Range) {
<<<<<<< HEAD
			GameObject.Find ("PickUpDisplay").transform.position = transform.position;
			GameObject.Find ("PickUpDisplay").GetComponentInChildren<Text>().text = AssociatedItem.name;
=======
			
			GlobVars.NearInteractable = true;
			GlobVars.InteractText = "Pick Up";
			
			if (SSInput.A[0] == "Pressed" && !GlobVars.PlayerPaused && !GlobVars.Reading) {
				GameObject.FindObjectOfType<Inventory>().Items.Add(AssociatedItem);
				Destroy(this.gameObject);
			}
>>>>>>> parent of a0d4f02... Bugs and Optimizing
		}
=======
	void PickUpObject () {
		GameObject.FindObjectOfType<Inventory>().Items.Add(AssociatedItem);
		Destroy(this.gameObject);
>>>>>>> parent of 7e462bc... New Character
	}
}
