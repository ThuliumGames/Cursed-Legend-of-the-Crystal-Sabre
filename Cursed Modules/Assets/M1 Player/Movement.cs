using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public Animator Anim;
	
	public float Acceleration;
	
	Vector3 Pos;
	Vector3 PrevPos;
	public LayerMask LM;
	
	bool WasPaused;
	Vector3 PrevVel;
	
	void Update () {
		if (!GlobVars.PlayerPaused && !GlobVars.Paused && !GlobVars.Reading) {
			Pos = transform.position;
			GetComponent<Rigidbody>().isKinematic = false;
			if (WasPaused) {
				GetComponent<Rigidbody>().velocity = PrevVel;
				WasPaused = false;
			}
			Anim.SetFloat("VSpeed", Mathf.Lerp (Anim.GetFloat("VSpeed"), SSInput.LVert[0], Acceleration * Time.deltaTime));
			Anim.SetFloat("HSpeed", Mathf.Lerp (Anim.GetFloat("HSpeed"), SSInput.LHor[0], Acceleration * Time.deltaTime));
			
			RaycastHit Hit;
			if (Physics.Raycast (transform.position+Vector3.up, Vector3.down, out Hit, 1.5f)) {
				transform.position = new Vector3 (transform.position.x, Hit.point.y, transform.position.z);
			}
		} else {
			if (GlobVars.Paused) {
				if (!WasPaused) {
					PrevVel = GetComponent<Rigidbody>().velocity;
					WasPaused = true;
				}
				transform.position = Pos;
				GetComponent<Rigidbody>().isKinematic = true;
			}
			Anim.SetFloat("VSpeed", Mathf.Lerp (Anim.GetFloat("VSpeed"), 0, Acceleration * Time.deltaTime));
			Anim.SetFloat("HSpeed", Mathf.Lerp (Anim.GetFloat("HSpeed"), 0, Acceleration * Time.deltaTime));
		}
	}
}
