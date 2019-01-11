using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using System.Runtime.InteropServices;

public class DisplayInventory : MonoBehaviour {
	
	//Mouse Input
	public struct Point {
		public int x;
		public int y;
	}
	
	public Point Pos;
	
	[DllImport("user32.dll")]
	public static extern bool SetCursorPos(int X, int Y);
	
	[DllImport("user32.dll")]
	public static extern bool GetCursorPos(out Point Pos);
	//End Mouse Input
	
	public Inventory Inv;
	
	public GameObject[] Slots;
	
<<<<<<< HEAD
<<<<<<< HEAD
=======
	public Canvas QSC;
	
	public Image[] QSSlot;
	int SelectedSlot;
	
>>>>>>> parent of f5a0b0d... Bugs
=======
	public Canvas QSC;
	
>>>>>>> parent of dc5a648... Better Inventory
	public Camera UICam;
	public GameObject AntiInteract;
	public PostProcessVolume PPV;
	
	public bool Right;
	
	void Update () {
		
		if (SSInput.Strt[0] == "Pressed") {
			GlobVars.PlayerPaused = !GlobVars.PlayerPaused;
		}
		
		if (GlobVars.PlayerPaused && !GlobVars.Reading) {
			Point cursorPos = new Point();
			GetCursorPos(out cursorPos);
			
			if (SSInput.LS[0] == "Down") {
				SetCursorPos(cursorPos.x+(int)(Mathf.Clamp(SSInput.LHor[0]*0.707f*20, -10, 10)), cursorPos.y-(int)(Mathf.Clamp(SSInput.LVert[0]*0.707f*20, -10, 10)));
			} else {
				SetCursorPos(cursorPos.x+(int)(Mathf.Clamp(SSInput.LHor[0]*0.707f*10, -10, 10)), cursorPos.y-(int)(Mathf.Clamp(SSInput.LVert[0]*0.707f*10, -10, 10)));
			}
			
			if (SSInput.RB[0] == "Pressed") {
				Right = true;
			}
			if (SSInput.LB[0] == "Pressed") {
				Right = false;
			}
			
			UICam.enabled = true;
			AntiInteract.SetActive(false);
			PPV.weight = Mathf.Lerp(PPV.weight, 1, 7*Time.deltaTime);
<<<<<<< HEAD
=======
			
			QSC.enabled = false;
>>>>>>> parent of dc5a648... Better Inventory
		} else {
			
			Right = false;
			
			UICam.enabled = false;
			AntiInteract.SetActive(true);
			PPV.weight = Mathf.Lerp(PPV.weight, 0, 7*Time.deltaTime);
<<<<<<< HEAD
=======
			
			bool AnyDPress = false;
			
			if ((SSInput.DUp[0] == "Pressed" || SSInput.DDown[0] == "Pressed" || SSInput.DLeft[0] == "Pressed" || SSInput.DRight[0] == "Pressed")
				||
				(SSInput.DUp[0] == "Down" || SSInput.DDown[0] == "Down" || SSInput.DLeft[0] == "Down" || SSInput.DRight[0] == "Down")) {
				AnyDPress = true;
			}
			
<<<<<<< HEAD
			if (AnyDPress) {
				QSC.enabled = true;
				if (SSInput.DUp[0] == "Pressed") {
					if (SelectedSlot == 1) {
						SelectedSlot = 0;
					} else {
						SelectedSlot = 1;
					}
				}
				if (SSInput.DLeft[0] == "Pressed") {
					SelectedSlot = 2;
				}
				if (SSInput.DRight[0] == "Pressed") {
					SelectedSlot = 3;
=======
			bool AnyDPress = false;
			
			if ((SSInput.DUp[0] == "Pressed" || SSInput.DDown[0] == "Pressed" || SSInput.DLeft[0] == "Pressed" || SSInput.DRight[0] == "Pressed")
				||
				(SSInput.DUp[0] == "Down" || SSInput.DDown[0] == "Down" || SSInput.DLeft[0] == "Down" || SSInput.DRight[0] == "Down")) {
				AnyDPress = true;
			}
			
			if (AnyDPress) {
				QSC.enabled = true;
				if (SSInput.DUp[0] == "Pressed") {

				}
				if (SSInput.DLeft[0] == "Pressed") {
					
				}
				if (SSInput.DRight[0] == "Pressed") {
					
>>>>>>> parent of dc5a648... Better Inventory
				}
			}
			
			if (SSInput.DDown[0] == "Released" && !AnyDPress) {
				QSC.enabled = false;
			}
		}
		
		if (QSC.enabled) {
<<<<<<< HEAD
			foreach (Image I in QSSlot) {
				I.enabled = false;
			}
			QSSlot[SelectedSlot].enabled = true;
		} else {
			foreach (Image I in QSSlot) {
				I.enabled = false;
			}
			SelectedSlot = -1;
>>>>>>> parent of f5a0b0d... Bugs
=======
			
		} else {
			
>>>>>>> parent of dc5a648... Better Inventory
		}
		
		if (Right) {
			GameObject.Find(name + "/InventMove").transform.localPosition = Vector3.Lerp (GameObject.Find(name + "/InventMove").transform.localPosition, new Vector3 (-1920, 0, 0), 25*Time.deltaTime);
		} else {
			GameObject.Find(name + "/InventMove").transform.localPosition = Vector3.Lerp (GameObject.Find(name + "/InventMove").transform.localPosition, new Vector3 (0, 0, 0), 25*Time.deltaTime);
		}
		
		int i = 0;
		foreach (anItem BS in Inv.BackItems) {
			if (BS.item != null) {
				Slots[i].GetComponentInChildren<Image>().color = Color.white;
				Slots[i].GetComponentInChildren<Image>().sprite = BS.item.sprite;
				if (BS.Amount > 1) {
					Slots[i].GetComponentInChildren<Text>().text = ""+BS.Amount;
				} else {
					Slots[i].GetComponentInChildren<Text>().text = "";
				}
<<<<<<< HEAD
			} else {
				Slots[i].GetComponentInChildren<Image>().color = Color.clear;
				Slots[i].GetComponentInChildren<Text>().text = "";
=======
				
				//Quick Select Slot
				Slots[i+17].GetComponentInChildren<Image>().color = Color.white;
				Slots[i+17].GetComponentInChildren<Image>().sprite = BS.item.sprite;
				if (BS.Amount > 1) {
					Slots[i+17].GetComponentInChildren<Text>().text = ""+BS.Amount;
				} else {
					Slots[i+17].GetComponentInChildren<Text>().text = "";
				}
			} else {
				Slots[i].GetComponentInChildren<Image>().color = Color.clear;
				Slots[i].GetComponentInChildren<Text>().text = "";
				
				//Quick Select Slot
				Slots[i+17].GetComponentInChildren<Image>().color = Color.clear;
				Slots[i+17].GetComponentInChildren<Text>().text = "";
>>>>>>> parent of f5a0b0d... Bugs
			}
			++i;
		}
		foreach (anItem SS in Inv.SideItems) {
			if (SS.item != null) {
				Slots[i].GetComponentInChildren<Image>().color = Color.white;
				Slots[i].GetComponentInChildren<Image>().sprite = SS.item.sprite;
				if (SS.Amount > 1) {
					Slots[i].GetComponentInChildren<Text>().text = ""+SS.Amount;
				} else {
					Slots[i].GetComponentInChildren<Text>().text = "";
				}
<<<<<<< HEAD
			} else {
				Slots[i].GetComponentInChildren<Image>().color = Color.clear;
				Slots[i].GetComponentInChildren<Text>().text = "";
=======
				
				//Quick Select Slot
				Slots[i+17].GetComponentInChildren<Image>().color = Color.white;
				Slots[i+17].GetComponentInChildren<Image>().sprite = SS.item.sprite;
				if (SS.Amount > 1) {
					Slots[i+17].GetComponentInChildren<Text>().text = ""+SS.Amount;
				} else {
					Slots[i+17].GetComponentInChildren<Text>().text = "";
				}
			} else {
				Slots[i].GetComponentInChildren<Image>().color = Color.clear;
				Slots[i].GetComponentInChildren<Text>().text = "";
				
				//Quick Select Slot
				Slots[i+17].GetComponentInChildren<Image>().color = Color.clear;
				Slots[i+17].GetComponentInChildren<Text>().text = "";
>>>>>>> parent of f5a0b0d... Bugs
			}
			++i;
		}
		foreach (anItem BPS in Inv.BackpackItems) {
			if (BPS.item != null) {
				Slots[i].GetComponentInChildren<Image>().color = Color.white;
				Slots[i].GetComponentInChildren<Image>().sprite = BPS.item.sprite;
				if (BPS.Amount > 1) {
					Slots[i].GetComponentInChildren<Text>().text = ""+BPS.Amount;
				} else {
					Slots[i].GetComponentInChildren<Text>().text = "";
				}
			} else {
				Slots[i].GetComponentInChildren<Image>().color = Color.clear;
				Slots[i].GetComponentInChildren<Text>().text = "";
			}
			++i;
		}
		if (Inv.ArmorL != null) {
			Slots[i].GetComponentInChildren<Image>().color = Color.white;
			Slots[i].GetComponentInChildren<Image>().sprite = Inv.ArmorL.sprite;
			Slots[i].GetComponentInChildren<Text>().text = "";
		} else {
			Slots[i].GetComponentInChildren<Image>().color = Color.clear;
			Slots[i].GetComponentInChildren<Text>().text = "";
		}
		++i;
		if (Inv.ArmorC != null) {
			Slots[i].GetComponentInChildren<Image>().color = Color.white;
			Slots[i].GetComponentInChildren<Image>().sprite = Inv.ArmorC.sprite;
			Slots[i].GetComponentInChildren<Text>().text = "";
		} else {
			Slots[i].GetComponentInChildren<Image>().color = Color.clear;
			Slots[i].GetComponentInChildren<Text>().text = "";
		}
		++i;
		if (Inv.ArmorM != null) {
			Slots[i].GetComponentInChildren<Image>().color = Color.white;
			Slots[i].GetComponentInChildren<Image>().sprite = Inv.ArmorM.sprite;
			Slots[i].GetComponentInChildren<Text>().text = "";
		} else {
			Slots[i].GetComponentInChildren<Image>().color = Color.clear;
			Slots[i].GetComponentInChildren<Text>().text = "";
		}
	}
}
