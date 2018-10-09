using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchJumpLeg : MonoBehaviour {
	
	public bool isMirror;
	
	void OnTriggerEnter (Collider Hit) {
		if (Hit.gameObject.layer != LayerMask.NameToLayer ("Player")) {
			if (isMirror) {
				GetComponentInParent<Animator>().SetBool("Mirror", true);
			} else {
				GetComponentInParent<Animator>().SetBool("Mirror", false);
			}
		}
	}
}
