using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipedWeapon : MonoBehaviour {
	
	public GameObject YourWeapon;
	public static Items TheWeapon;
	public GameObject WeapSelect;
	public Image Im1;
	public Image Im2;
	public Image Im3;
	public Image Im4;
	public Image Im11;
	public Image Im12;
	public Image Im13;
	public Image Im14;
	
	void Update () {
		if (!GlobVars.PlayerPause) {
			GetComponentInParent<OpenInventory>().Inventory.SetActive(true);
			print (GameObject.Find("SW1Image").name);
			WeapSelect.SetActive(true);
			Im1.sprite = GameObject.Find("SW1Image").GetComponent<Items>().ItemImage;
			Im2.sprite = GameObject.Find("SW2Image").GetComponent<Items>().ItemImage;
			Im3.sprite = GameObject.Find("SW3Image").GetComponent<Items>().ItemImage;
			Im4.sprite = GameObject.Find("SW4Image").GetComponent<Items>().ItemImage;
			WeapSelect.SetActive(false);
			
			if (SSInput.DUp[0] == "Down") {
				WeapSelect.SetActive(true);
				Im11.color = new Color32 (0,0,0,128);
			} else {
				Im11.color = new Color32 (0,0,0,0);
			}
			if (SSInput.DRight[0] == "Down") {
				WeapSelect.SetActive(true);
				Im12.color = new Color32 (0,0,0,128);
			} else {
				Im12.color = new Color32 (0,0,0,0);
			}
			if (SSInput.DDown[0] == "Down") {
				WeapSelect.SetActive(true);
				Im13.color = new Color32 (0,0,0,128);
			} else {
				Im13.color = new Color32 (0,0,0,0);
			}
			if (SSInput.DLeft[0] == "Down") {
				WeapSelect.SetActive(true);
				Im14.color = new Color32 (0,0,0,128);
			} else {
				Im14.color = new Color32 (0,0,0,0);
			}
			
			if (SSInput.DUp[0] == "Released" && SSInput.DRight[0] == "Up" && SSInput.DDown[0] == "Up" && SSInput.DLeft[0] == "Up") {
				if (GameObject.Find("SW1Image").GetComponent<Items>().ItemName != null) {
					TheWeapon = GameObject.Find("SW1Image").GetComponent<Items>();
				}
			}
			
			if (SSInput.DRight[0] == "Released" && SSInput.DUp[0] == "Up" && SSInput.DDown[0] == "Up" && SSInput.DLeft[0] == "Up") {
				if (GameObject.Find("SW2Image").GetComponent<Items>().ItemName != null) {
					TheWeapon = GameObject.Find("SW2Image").GetComponent<Items>();
				}
			}
			
			if (SSInput.DDown[0] == "Released" && SSInput.DRight[0] == "Up" && SSInput.DUp[0] == "Up" && SSInput.DLeft[0] == "Up") {
				if (GameObject.Find("SW3Image").GetComponent<Items>().ItemName != null) {
					TheWeapon = GameObject.Find("SW3Image").GetComponent<Items>();
				}
			}
			
			if (SSInput.DLeft[0] == "Released" && SSInput.DRight[0] == "Up" && SSInput.DDown[0] == "Up" && SSInput.DUp[0] == "Up") {
				if (GameObject.Find("SW4Image").GetComponent<Items>().ItemName != null) {
					TheWeapon = GameObject.Find("SW4Image").GetComponent<Items>();
				}
			}
			
			if (TheWeapon != null) {
				if (TheWeapon.ItemName != "") {
					if (YourWeapon != null) {
						Destroy (YourWeapon);
					}
					GameObject G = Instantiate (TheWeapon.ItemObject, Vector3.zero, Quaternion.Euler (Vector3.zero));
					G.transform.SetParent (transform);
					G.transform.localPosition = G.GetComponent<Items>().SpawnPos;
					G.transform.localEulerAngles = G.GetComponent<Items>().SpawnRot;
					G.name = G.GetComponent<Items>().ItemName;
					YourWeapon = G;
				}
			}
			GetComponentInParent<OpenInventory>().Inventory.SetActive(false);
		}
	}
}
