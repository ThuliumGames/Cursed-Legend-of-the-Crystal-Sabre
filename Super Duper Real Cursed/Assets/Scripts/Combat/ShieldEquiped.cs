using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEquiped : MonoBehaviour {
	
	void Update () {
		if (!GlobVars.PlayerPause) {
			GetComponentInParent<OpenInventory>().Inventory.SetActive(true);
			if (GameObject.Find("Shield1Image").GetComponent<Items>().ItemName != "") {
				if (GetComponentInChildren<Items>() == null) {
					GameObject G = Instantiate(GameObject.Find("Shield1Image").GetComponent<Items>().ItemObject, Vector3.zero, Quaternion.Euler (Vector3.zero));
					G.transform.SetParent (transform);
					G.transform.localPosition = G.GetComponent<Items>().SpawnPos;
					G.transform.localEulerAngles = G.GetComponent<Items>().SpawnRot;
					G.name = G.GetComponent<Items>().ItemName;
				}
			} else {
				if (GetComponentInChildren<Items>() != null) {
					Destroy (GetComponentInChildren<Items>().gameObject);
				}
			}
			GetComponentInParent<OpenInventory>().Inventory.SetActive(false);
		}
	}
}
