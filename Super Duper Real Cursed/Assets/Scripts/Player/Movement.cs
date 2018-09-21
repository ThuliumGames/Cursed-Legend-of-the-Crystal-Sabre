using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public Transform Cam;
	public Animator Anim;
	public Transform HeadLook;
	public Transform HeadLookRot;
	public Transform Head;
	float Angle;
	float AccAngle;
	float Ang;
	float CamRotPrev;
	float CamRotWhileMove;
	public bool CanTurn;
	public int ComboNum;
	public bool CanAttack;
	public int XPresses;
	float TurnSpeed;
	void Update () {
		if (!GlobVars.PlayerPause) {
			
			if (SSInput.X[0] == "Pressed") {
				++XPresses;
			}
			if (CanAttack && XPresses > ComboNum) {
				if (GetComponentInChildren<WeaponAnimation>() != null) {
					Anim.Play(GetComponentInChildren<WeaponAnimation>().AnimName + "" + (ComboNum+1));
				}
			}
			
			if ((Mathf.Abs (SSInput.LHor[0]) > 0.05f || Mathf.Abs (SSInput.LVert[0]) > 0.05f) && CanTurn) {
				Angle = (Mathf.Atan2(SSInput.LHor[0], SSInput.LVert[0])*Mathf.Rad2Deg)+Cam.eulerAngles.y;
				if (SSInput.A[0] == "Down") {
					Anim.SetFloat("Speed", Mathf.Lerp (Anim.GetFloat("Speed"), Mathf.Clamp01(new Vector2(SSInput.LHor[0], SSInput.LVert[0]).magnitude), 20*Time.deltaTime));
				} else {
					Anim.SetFloat("Speed", Mathf.Lerp (Anim.GetFloat("Speed"), Mathf.Clamp01(new Vector2(SSInput.LHor[0], SSInput.LVert[0]).magnitude)/2, 20*Time.deltaTime));
				}
			} else {
				Anim.SetFloat("Speed", Mathf.Lerp (Anim.GetFloat("Speed"), 0, 10*Time.deltaTime));
			}
			
			if (CanTurn) {
				transform.rotation = Quaternion.Lerp(transform.rotation, HeadLookRot.rotation, TurnSpeed/(Anim.GetFloat("Speed")+1)*Time.deltaTime);
			}
		} else {
			Anim.SetFloat("Speed", Mathf.Lerp (Anim.GetFloat("Speed"), 0, 20*Time.deltaTime));
		}
		HeadLookRot.eulerAngles = new Vector3 (0, Angle, 0);
		if (Anim.GetFloat("Speed") < 0.1f) {
			TurnSpeed = 15;
		} else if (HeadLookRot.localEulerAngles.y < 5f || HeadLookRot.localEulerAngles.y > 355f) {
			TurnSpeed = 5;
		}
	}
	
	void OnAnimatorIK (int LayerIndex) {
		Anim.SetLookAtWeight(0.5f);
		Anim.SetLookAtPosition(HeadLook.position);
	}
}
