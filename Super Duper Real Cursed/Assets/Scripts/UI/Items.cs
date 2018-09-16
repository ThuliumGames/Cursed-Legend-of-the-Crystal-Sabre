using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour {
	
	public string ItemName;
	public Sprite ItemImage;
	public GameObject ItemObject;
	public Vector3 SpawnPos;
	public Vector3 SpawnRot;
	
	public string ItemType;
	
	void Update () {
		if (!GlobVars.PlayerPause) {
			if (GetComponent<Rigidbody>() != null) {
				if (Mathf.Abs (GameObject.Find("Select").transform.position.x - transform.position.x) < 0.1f && Mathf.Abs (GameObject.Find("Select").transform.position.z - transform.position.z) < 0.1f) {
					if (SSInput.A[0] == "Pressed") {
						GameObject.Find("Player").GetComponent<OpenInventory>().Inventory.SetActive(true);
						if (ItemType == "Weapon") {
							if (GameObject.Find ("SW1Image").GetComponent<Items>().ItemName == "") {
								GameObject.Find ("SW1Image").GetComponent<Items>().ItemName = ItemName;
								GameObject.Find ("SW1Image").GetComponent<Items>().ItemImage = ItemImage;
								GameObject.Find ("SW1Image").GetComponent<Items>().ItemObject = ItemObject;
								GameObject.Find ("SW1Image").GetComponent<Items>().SpawnPos = SpawnPos;
								GameObject.Find ("SW1Image").GetComponent<Items>().SpawnRot = SpawnRot;
								GameObject.Find ("SW1Image").GetComponent<Image>().sprite = ItemImage;
								Destroy (this.gameObject);
							} else if (GameObject.Find ("SW2Image").GetComponent<Items>().ItemName == "") {
								GameObject.Find ("SW2Image").GetComponent<Items>().ItemName = ItemName;
								GameObject.Find ("SW2Image").GetComponent<Items>().ItemImage = ItemImage;
								GameObject.Find ("SW2Image").GetComponent<Items>().ItemObject = ItemObject;
								GameObject.Find ("SW2Image").GetComponent<Items>().SpawnPos = SpawnPos;
								GameObject.Find ("SW2Image").GetComponent<Items>().SpawnRot = SpawnRot;
								GameObject.Find ("SW2Image").GetComponent<Image>().sprite = ItemImage;
								Destroy (this.gameObject);
							} else if (GameObject.Find ("SW3Image").GetComponent<Items>().ItemName == "") {
								GameObject.Find ("SW3Image").GetComponent<Items>().ItemName = ItemName;
								GameObject.Find ("SW3Image").GetComponent<Items>().ItemImage = ItemImage;
								GameObject.Find ("SW3Image").GetComponent<Items>().ItemObject = ItemObject;
								GameObject.Find ("SW3Image").GetComponent<Items>().SpawnPos = SpawnPos;
								GameObject.Find ("SW3Image").GetComponent<Items>().SpawnRot = SpawnRot;
								GameObject.Find ("SW3Image").GetComponent<Image>().sprite = ItemImage;
								Destroy (this.gameObject);
							} else if (GameObject.Find ("SW4Image").GetComponent<Items>().ItemName == "") {
								GameObject.Find ("SW4Image").GetComponent<Items>().ItemName = ItemName;
								GameObject.Find ("SW4Image").GetComponent<Items>().ItemImage = ItemImage;
								GameObject.Find ("SW4Image").GetComponent<Items>().ItemObject = ItemObject;
								GameObject.Find ("SW4Image").GetComponent<Items>().SpawnPos = SpawnPos;
								GameObject.Find ("SW4Image").GetComponent<Items>().SpawnRot = SpawnRot;
								GameObject.Find ("SW4Image").GetComponent<Image>().sprite = ItemImage;
								Destroy (this.gameObject);
							} else {
								print ("Can't Pick This Up");
							}
						}
						GameObject.Find("Player").GetComponent<OpenInventory>().Inventory.SetActive(false);
					}
				}
			}
		}
	}
}
