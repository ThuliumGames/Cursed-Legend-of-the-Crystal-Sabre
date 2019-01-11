using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtPlayer : MonoBehaviour {
	
	public bool isCanvas;
	public GameObject GOTLA;
	
	void Update () {
		transform.LookAt(GOTLA.transform);
		if (isCanvas) {
			float Dist = 1000;
			bool CanPickUp = true;
			foreach (Dialogue D in GameObject.FindObjectsOfType<Dialogue>()) {
				if (D.WithinRange) {
					if (Vector3.Distance (D.transform.position, GameObject.Find("Player").transform.position) < Dist) {
						Dist = Vector3.Distance (D.transform.position, GameObject.Find("Player").transform.position);
						transform.position = D.transform.position + new Vector3 (0, D.GetComponent<Dialogue>().HeightUp, 0);
						GetComponentInChildren<Text>().text = D.name;
					}
					CanPickUp = false;
				}
			}
			if (CanPickUp) {
				foreach (Items I in GameObject.FindObjectsOfType<Items>()) {
					if (I.ItemName != "Destroy") {
						if (I.gameObject.GetComponent<Rigidbody>() != null) {
							if (Vector3.Distance(I.transform.position, GameObject.Find("Player").transform.position) < 2f &&
								Vector3.Distance(I.transform.position, GameObject.Find("Player").transform.position) <= Dist) {
								Dist = Vector3.Distance(I.transform.position, GameObject.Find("Player").transform.position);
								transform.position = I.transform.position + Vector3.up;
								GetComponentInChildren<Text>().text = I.ItemName;
							}
						}
					}
				}
			}
			if (Dist == 1000) {
				transform.position = Vector3.down*1000;
			}
		}
	}
}
