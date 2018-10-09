using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {
	
	public Transform ObjToFollow;
	float UpDown;
	public float Max;
	public float Min;
	public float Back;
	public float Up;
	public LayerMask LM;
	
	void Update () {
		if (!GlobVars.PlayerPause || GlobVars.Reading) {
			transform.position = ObjToFollow.position;
			transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
			transform.Rotate (0, SSInput.RHor[0]*100*Time.deltaTime, 0);
			GetComponentInChildren<Camera>().transform.localPosition = new Vector3 (0, 0, -Back);
			transform.Translate (0, Up, 0);
			UpDown += -SSInput.RVert[0]*100*Time.deltaTime;
			UpDown = Mathf.Clamp (UpDown, Min, Max);
			transform.eulerAngles = new Vector3 (UpDown, transform.eulerAngles.y, 0);
			RaycastHit Hit;
			Physics.Raycast (transform.position, -transform.forward, out Hit, Back, LM);
			if (Hit.collider != null) {
				GetComponentInChildren<Camera>().transform.Translate (0, 0, Back-(Hit.distance-0.1f));
			}
		}
	}
}
