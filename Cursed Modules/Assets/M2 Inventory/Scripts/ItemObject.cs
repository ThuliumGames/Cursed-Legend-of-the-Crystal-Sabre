using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour {
	
	public Item AssociatedItem;
	
	public float Range;
	
	void Update () {
		
		float Dist = 10000;
		
		float DFP = Vector3.Distance (transform.position, GameObject.Find("Player").transform.position);
		
		foreach (ItemObject I in GameObject.FindObjectsOfType<ItemObject>()) {
			
			DFP = Vector3.Distance (I.transform.position, GameObject.Find("Player").transform.position);
			
			if (DFP < Dist) {
				Dist = DFP;
			}
		}
		
		DFP = Vector3.Distance (transform.position, GameObject.Find("Player").transform.position);
		
		if (Dist == DFP && DFP <= Range) {
			GameObject.Find ("PickUpDisplay").transform.position = transform.position;
			GameObject.Find ("PickUpDisplay").GetComponentInChildren<Text>().text = AssociatedItem.name;
		}
	}
}
