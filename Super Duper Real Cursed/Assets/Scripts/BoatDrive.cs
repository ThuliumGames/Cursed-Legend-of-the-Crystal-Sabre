using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatDrive : MonoBehaviour {
	
	bool InWater;
	
	void Update () {
		if (GlobVars.RidingName == name) {
			if (InWater) {
				GetComponent<Animator>().SetFloat ("Vertical", Mathf.Lerp (GetComponent<Animator>().GetFloat ("Vertical"), SSInput.LVert[0], 0.5f * Time.deltaTime));
				GetComponent<Animator>().SetFloat ("Horizontal", Mathf.Lerp (GetComponent<Animator>().GetFloat ("Horizontal"), SSInput.LHor[0], 0.5f * Time.deltaTime));
			} else {
				GetComponent<Animator>().SetFloat ("Vertical", Mathf.Lerp (GetComponent<Animator>().GetFloat ("Vertical"), 0, 0.5f * Time.deltaTime));
				GetComponent<Animator>().SetFloat ("Horizontal", Mathf.Lerp (GetComponent<Animator>().GetFloat ("Horizontal"), 0, 0.5f * Time.deltaTime));
			}
		} else {
			GetComponent<Animator>().SetFloat ("Vertical", Mathf.Lerp (GetComponent<Animator>().GetFloat ("Vertical"), 0, 0.5f * Time.deltaTime));
			GetComponent<Animator>().SetFloat ("Horizontal", Mathf.Lerp (GetComponent<Animator>().GetFloat ("Horizontal"), 0, 0.5f * Time.deltaTime));
		}
	}
	
	void OnCollisionStay (Collision Hit) {
		if (Hit.collider.gameObject.layer == LayerMask.NameToLayer("Water")) {
			InWater = true;
		} else {
			InWater = false;
		}
	}
}
