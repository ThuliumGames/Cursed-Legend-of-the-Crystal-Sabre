using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public Animator Anim;
	float Angle;
	float AccAngle;
	
	void Update () {
		if (!GlobVars.PlayerPause) {
			bool CanUpdateRot = false;
			if (Mathf.Abs (Angle) > 5) {
				CanUpdateRot = true;
			}
			bool GTZ1 = true;
			if (Angle < 0) {
				GTZ1 = false;
			}
			if (Mathf.Abs (SSInput.LHor[0]) > 0.05f || Mathf.Abs (SSInput.LVert[0]) > 0.05f) {
				Angle = Mathf.Atan2(SSInput.LHor[0], SSInput.LVert[0])*Mathf.Rad2Deg;
				Anim.Play("Walk_Forward");
			} else {
				Anim.Play("Idle_Default");
			}
			
			bool GTZ2 = true;
			if (Angle < 0) {
				GTZ2 = false;
			}
			
			if (Mathf.Abs (Angle) > 5 && CanUpdateRot) {
				if (GTZ1 && !GTZ2) {
					AccAngle -= 360;
				}
				
				if (!GTZ1 && GTZ2) {
					AccAngle += 360;
				}
			}
			
			print (Angle);
			AccAngle = Mathf.Lerp (AccAngle, Angle, 10*Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, AccAngle, 0);
		} else {
			Anim.Play("Idle_Default");
		}
	}
}
