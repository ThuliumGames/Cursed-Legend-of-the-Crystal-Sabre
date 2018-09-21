using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {
	
	public Transform ObjToFollow;
	public float Back;
	public float Up;
	
	void Update () {
		if (!GlobVars.PlayerPause || GlobVars.Reading) {
			transform.position = ObjToFollow.position;
			transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
			transform.Rotate (0, SSInput.RHor[0]*100*Time.deltaTime, 0);
			transform.Translate (0, Up, -Back);
			transform.eulerAngles = new Vector3 (10, transform.eulerAngles.y, 0);
		}
	}
}
