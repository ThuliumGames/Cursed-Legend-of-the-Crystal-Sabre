using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class anItem {
	public Item item;
	public int Amount;
}

public class Inventory : MonoBehaviour {
	
	public List<Item> Items;
	public List<anItem> BackItems;
	public List<anItem> SideItems;
	public List<anItem> BackpackItems;
	public Item ArmorL;
	public Item ArmorC;
	public Item ArmorM;
	
	bool Placed = false;
	
	void Update () {
		
		for (int i = 0; i < BackItems.Count; ++i) {
			BackItems[i].item = null;
			BackItems[i].Amount = 0;
		}
		for (int i = 0; i < SideItems.Count; ++i) {
			SideItems[i].item = null;
			SideItems[i].Amount = 0;
		}
		for (int i = 0; i < BackpackItems.Count; ++i) {
			BackpackItems[i].item = null;
			BackpackItems[i].Amount = 0;
		}
		
		ArmorL = null;
		ArmorC = null;
		ArmorM = null;
		
		int b = 0;
		int d = 0;
		
		foreach (Item I in Items) {
			bool Placed = false;
			if (I != null) {
				if (I.CanBeEquipedIn[0]) {
					if (I.Type != "Armor") {
						foreach (anItem BI in BackItems) {
							if (!Placed) {
								if (BI.item == null || (I == BI.item && BI.Amount < I.StackSize)) {
									Placed = true;
									BI.item = I;
									++BI.Amount;
								}
							}
						}
					} else {
						if (ArmorL == null) {
							Placed = true;
							ArmorL = I;
						}
					}
				}
				if (!Placed) {
					if (I.CanBeEquipedIn[1]) {
						if (I.Type != "Armor") {
							foreach (anItem SI in SideItems) {
								if (!Placed) {
									if (SI.item == null || (I == SI.item && SI.Amount < I.StackSize)) {
										Placed = true;
										SI.item = I;
										++SI.Amount;
									}
								}
							}
						} else {
							if (ArmorC == null) {
								Placed = true;
								ArmorC = I;
							}
						}
					}
				}
				if (!Placed) {
					if (I.CanBeEquipedIn[2]) {
						if (I.Type != "Armor") {
							foreach (anItem BPI in BackpackItems) {
								if (!Placed) {
									if (BPI.item == null || (I == BPI.item && BPI.Amount < I.StackSize)) {
										Placed = true;
										BPI.item = I;
										++BPI.Amount;
									}
								}
							}
						} else {
							if (ArmorM == null) {
								Placed = true;
								ArmorM = I;
							}
						}
					}
				}
			}
			++b;
		}
		
		Items.Clear();
		int z = 0;
		foreach (anItem It1 in BackItems) {
			if (It1.item != null) {
				for (int i = 0; i < It1.Amount; ++i) {
					Items.Insert(z, It1.item);
					++z;
				}
			}
		}
		foreach (anItem It2 in SideItems) {
			if (It2.item != null) {
				for (int i = 0; i < It2.Amount; ++i) {	
					Items.Insert(z, It2.item);
					++z;
				}
			}
		}
		foreach (anItem It3 in BackpackItems) {
			if (It3.item != null) {
				for (int i = 0; i < It3.Amount; ++i) {
					Items.Insert(z, It3.item);
					++z;
				}
			}
		}
		if (ArmorL != null) {
			Items.Insert(z, ArmorL);
			++z;
		}
		if (ArmorC != null) {
			Items.Insert(z, ArmorC);
			++z;
		}
		if (ArmorM != null) {
			Items.Insert(z, ArmorM);
			++z;
		}
	}
}
