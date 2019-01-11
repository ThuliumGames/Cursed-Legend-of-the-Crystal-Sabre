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
		} else {
			
			Right = false;
			
			UICam.enabled = false;
			AntiInteract.SetActive(true);
			PPV.weight = Mathf.Lerp(PPV.weight, 0, 7*Time.deltaTime);
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
			} else {
				Slots[i].GetComponentInChildren<Image>().color = Color.clear;
				Slots[i].GetComponentInChildren<Text>().text = "";
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
			} else {
				Slots[i].GetComponentInChildren<Image>().color = Color.clear;
				Slots[i].GetComponentInChildren<Text>().text = "";
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
