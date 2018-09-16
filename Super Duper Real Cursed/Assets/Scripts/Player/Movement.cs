using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public Transform Cam;
	public Animator Anim;
	float Angle;
	float AccAngle;
	float Ang;
	float CamRotPrev;
	float CamRotWhileMove;
	public bool CanTurn;
	void Update () {
		if (!GlobVars.PlayerPause) {
			
			if (SSInput.X[0] == "Pressed") {
				if (GetComponentInChildren<WeaponAnimation>() != null) {
					Anim.Play(GetComponentInChildren<WeaponAnimation>().AnimName);
				}
			}
			if (SSInput.Y[0] == "Pressed") {
				Anim.Play("Jump");
			}
			
			bool CanUpdateRot = false;
			if (Mathf.Abs (Angle) > 5) {
				CanUpdateRot = true;
			}
			bool GTZ1 = true;
			if (Angle < 0) {
				GTZ1 = false;
			}
			if ((Mathf.Abs (SSInput.LHor[0]) > 0.05f || Mathf.Abs (SSInput.LVert[0]) > 0.05f) && CanTurn) {
				Angle = (Mathf.Atan2(SSInput.LHor[0], SSInput.LVert[0])*Mathf.Rad2Deg);
				Anim.SetFloat("Speed", Mathf.Lerp (Anim.GetFloat("Speed"), Mathf.Clamp01(new Vector2(SSInput.LHor[0], SSInput.LVert[0]).magnitude), 10*Time.deltaTime));
				print (Mathf.Clamp01(new Vector2(SSInput.LHor[0], SSInput.LVert[0]).magnitude));
			} else {
				Anim.SetFloat("Speed", Mathf.Lerp (Anim.GetFloat("Speed"), 0, 10*Time.deltaTime));
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
			
			if (Cam.eulerAngles.y < 90 || Cam.eulerAngles.y > 270) {
				if (Cam.eulerAngles.y > 180 && CamRotPrev < 180) {
					AccAngle += 360;
				}
				
				if (Cam.eulerAngles.y < 180 && CamRotPrev > 180) {
					AccAngle -= 360;
				}
			}
			
			if ((Mathf.Abs (SSInput.LHor[0]) > 0.05f || Mathf.Abs (SSInput.LVert[0]) > 0.05f) && CanTurn) {
				AccAngle = Mathf.Lerp (AccAngle, Angle+Cam.eulerAngles.y, 10*Time.deltaTime);
			}
			
			transform.eulerAngles = new Vector3 (0, AccAngle, 0);
			CamRotPrev = Cam.eulerAngles.y;
			Anim.SetFloat("Turn", Mathf.Lerp (Anim.GetFloat("Turn"), ((Angle+Cam.eulerAngles.y)-AccAngle)/90, 20*Time.deltaTime));
		} else {
			Anim.SetFloat("Speed", Mathf.Lerp (Anim.GetFloat("Speed"), 0, 10*Time.deltaTime));
		}
	}
}
