using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ridable : MonoBehaviour {
	
	public float Range;
	public Transform Point;
	public float SignUp;
	public string AnimVarName;
	
	void Update () {
		if (!GlobVars.RidingObject) {
			if (SSInput.A[0] == "Pressed" && GameObject.Find("Select").transform.position == transform.position + new Vector3 (0, SignUp, 0)) {
				GlobVars.RidingObject = true;
				GlobVars.RidingName = name;
			} else {
				GlobVars.RidingName = null;
				GameObject.Find("Player").GetComponent<Animator>().SetBool(AnimVarName, false);
				GlobVars.RidingObject = false;
			}
		} else {
			GlobVars.RidingObject = true;
			GameObject.Find("Player").transform.position = Point.position;
			GameObject.Find("Player").transform.eulerAngles = Point.eulerAngles;
			GameObject.Find("Player").GetComponent<Animator>().SetBool(AnimVarName, true);
			if (SSInput.B[0] == "Pressed") {
				GlobVars.RidingObject = false;
			}
		}
	}
}
