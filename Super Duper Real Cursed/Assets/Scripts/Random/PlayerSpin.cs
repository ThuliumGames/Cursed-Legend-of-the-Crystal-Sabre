using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpin : MonoBehaviour {
	
	void OnEnable () {
		transform.Rotate (0, -transform.localEulerAngles.y+225, 0);
	}
	
	void Update () {
		transform.Rotate (0, -SSInput.RHor[0]*250*Time.deltaTime, 0);
	}
}