using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public Animator Anim;
	
	public float Acceleration;
	
	Vector3 Pos;
	Vector3 PrevPos;
	public LayerMask LM;
	
	void Update () {
		if (!GlobVars.PlayerPaused && !GlobVars.Paused) {
			Pos = transform.position;
			GetComponent<Rigidbody>().isKinematic = false;
			Anim.SetFloat("VSpeed", Mathf.Lerp (Anim.GetFloat("VSpeed"), SSInput.LVert[0], Acceleration * Time.deltaTime));
			Anim.SetFloat("HSpeed", Mathf.Lerp (Anim.GetFloat("HSpeed"), SSInput.LHor[0], Acceleration * Time.deltaTime));
		} else {
			transform.position = Pos;
			GetComponent<Rigidbody>().isKinematic = true;
		}
	}
}
