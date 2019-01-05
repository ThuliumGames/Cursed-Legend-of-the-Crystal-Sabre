﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour {
	
	public Item AssociatedItem;
	
	void PickUpObject () {
		GameObject.FindObjectOfType<Inventory>().Items.Add(AssociatedItem);
		Destroy(this.gameObject);
	}
}
