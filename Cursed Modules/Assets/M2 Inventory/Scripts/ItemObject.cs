using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour {
	
	public Item AssociatedItem;
	
	public int Place;
	public int Slot;
	
	void PickUpObject () {
		GameObject.FindObjectOfType<Inventory>().Items.Add(AssociatedItem);
		Destroy(this.gameObject);
	}
}
