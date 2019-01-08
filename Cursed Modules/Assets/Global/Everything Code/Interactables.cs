using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour {
	
	public float Range;
	public string ObjectText;
	public string MessageName;
	public bool AutoInteract;
	public bool shouldPause;
	
	void Update () {
		
		if (!GlobVars.Interacting) {
		
			float Dist = 10000;
			
			float DFP = Vector3.Distance (transform.position, GameObject.Find("Player").transform.position);
			
			foreach (Interactables I in GameObject.FindObjectsOfType<Interactables>()) {
				
				DFP = Vector3.Distance (I.transform.position, GameObject.Find("Player").transform.position);
				
				if (DFP < Dist) {
					Dist = DFP;
				}
			}
			
			DFP = Vector3.Distance (transform.position, GameObject.Find("Player").transform.position);
			
			if (Dist == DFP) {
				GlobVars.ClosestInteractable = this.gameObject;
			}
			
			if (Dist == DFP && DFP <= Range) {
				GlobVars.NearInteractable = true;
				GlobVars.InteractText = ObjectText;
				if ((SSInput.A[0] == "Pressed" || AutoInteract) && !GlobVars.PlayerPaused && !GlobVars.Reading) {
					if (shouldPause) {
						GlobVars.Interacting = true;
					}
					SendMessage(MessageName);
				}
			}
		}
	}
}
