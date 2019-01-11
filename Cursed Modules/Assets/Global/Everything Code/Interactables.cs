using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour {
	
	public float Range;
	public string ObjectText;
	public string MessageName;
	
	void Update () {
		
		float Dist = 10000;
		
		float DFP = Vector3.Distance (transform.position, GameObject.Find("Player").transform.position);
		
		foreach (Interactables I in GameObject.FindObjectsOfType<Interactables>()) {
			
			DFP = Vector3.Distance (I.transform.position, GameObject.Find("Player").transform.position);
			
<<<<<<< HEAD
			if (DFP < Dist && DFP <= Range) {
=======
			if (DFP < Dist) {
>>>>>>> parent of 686a447... Readded Dialogue
				Dist = DFP;
			}
		}
		
		DFP = Vector3.Distance (transform.position, GameObject.Find("Player").transform.position);
		
<<<<<<< HEAD
=======
		if (Dist == DFP) {
			GlobVars.ClosestInteractable = this.gameObject;
		}
		
>>>>>>> parent of 686a447... Readded Dialogue
		if (Dist == DFP && DFP <= Range) {
			GlobVars.NearInteractable = true;
			GlobVars.InteractText = ObjectText;
			if (SSInput.A[0] == "Pressed" && !GlobVars.PlayerPaused && !GlobVars.Reading) {
				SendMessage(MessageName);
			}
		}
	}
}
