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
	bool isSlow;
	public bool CanTurn;
	public int ComboNum;
	public bool CanAttack;
	public int XPresses;
	float TurnSpeed;
	public bool ClimbMove;
	Vector3 Pos;
	Vector3 PrevPos;
	
	void Update () {
		if (!GlobVars.PlayerPause) {
			Pos = transform.position;
			GetComponent<Rigidbody>().isKinematic = false;
			
			if (SSInput.X[0] == "Pressed") {
				++XPresses;
			}
			if (CanAttack && XPresses > ComboNum) {
				if (GetComponentInChildren<WeaponAnimation>() != null) {
					Anim.Play(GetComponentInChildren<WeaponAnimation>().AnimName + "" + (ComboNum+1));
				}
			}
			if (SSInput.LS[0] == "Pressed") {
				if (isSlow) {
					isSlow = false;
				} else {
					isSlow = true;
				}
			}
			
			if (!Anim.GetBool("Falling")) {
				Anim.applyRootMotion = true;
				if ((Mathf.Abs (SSInput.LHor[0]) > 0.05f || Mathf.Abs (SSInput.LVert[0]) > 0.05f) && CanTurn) {
					Angle = (Mathf.Atan2(SSInput.LHor[0], SSInput.LVert[0])*Mathf.Rad2Deg)+Cam.eulerAngles.y;
					if (SSInput.A[0] == "Down") {
						isSlow = false;
						Anim.SetFloat("Speed", Mathf.Lerp (Anim.GetFloat("Speed"), Mathf.Clamp01(new Vector2(SSInput.LHor[0], SSInput.LVert[0]).magnitude), 20*Time.deltaTime));
					} else {
						if (isSlow) {
							Anim.SetFloat("Speed", Mathf.Lerp (Anim.GetFloat("Speed"), Mathf.Clamp01(new Vector2(SSInput.LHor[0], SSInput.LVert[0]).magnitude)/8, 20*Time.deltaTime));
						} else {
							Anim.SetFloat("Speed", Mathf.Lerp (Anim.GetFloat("Speed"), Mathf.Clamp01(new Vector2(SSInput.LHor[0], SSInput.LVert[0]).magnitude)/2, 20*Time.deltaTime));
						}
					}
				} else {
					Anim.SetFloat("Speed", Mathf.Lerp (Anim.GetFloat("Speed"), 0, 10*Time.deltaTime));
				}
			} else {
				Anim.applyRootMotion = false;
			}
			
			if (CanTurn) {
				transform.rotation = Quaternion.Lerp(transform.rotation, HeadLookRot.rotation, TurnSpeed/(((Anim.GetFloat("Speed")*10)+1)/10)*Time.deltaTime);
			}
		} else {
			GetComponent<Rigidbody>().isKinematic = true;
			transform.position = Pos;
			if (!Anim.GetBool("Falling")) {
				Anim.SetFloat("Speed", Mathf.Lerp (Anim.GetFloat("Speed"), 0, 20*Time.deltaTime));
			}
		}
		if (ClimbMove) {
			ClimbMove = false;
			transform.Translate (0, 1.625f, 0.35f);
		}
		HeadLookRot.eulerAngles = new Vector3 (0, Angle, 0);
		if (Anim.GetFloat("Speed") < 0.1f) {
			TurnSpeed = 15;
		} else if (HeadLookRot.localEulerAngles.y < 5f || HeadLookRot.localEulerAngles.y > 355f) {
			TurnSpeed = 5;
		}
		RaycastHit Hit;
		Physics.Raycast(transform.position+Vector3.up, Vector3.down, out Hit, Mathf.Infinity, LayerMask.NameToLayer ("Everything"));
		RaycastHit SlopeHit;
		Physics.Raycast(transform.position+Vector3.up+(transform.forward/10), Vector3.down, out SlopeHit, Mathf.Infinity, LayerMask.NameToLayer ("Everything"));
		Anim.SetFloat("Slope", Mathf.Clamp(Hit.distance-SlopeHit.distance, -0.1f, 0.1f)*10);
		if (Hit.distance < 1.25f) {
			Anim.SetBool("Falling", false);
			transform.position = new Vector3 (transform.position.x, Hit.point.y, transform.position.z);
			if (!GlobVars.PlayerPause) {
				if (SSInput.Y[0] == "Pressed") {
					if (Anim.GetFloat("Slope") < 0.5f) {
						transform.Translate(0, 0.3f, 0);
						GetComponent<Rigidbody>().velocity = new Vector3 (10, 5, 10);
					}
				}
			}
		} else {
			Anim.SetBool("Falling", true);
		}
		Anim.SetFloat("YVelocity", GetComponent<Rigidbody>().velocity.y);
		PrevPos = transform.position;
	}
	
	void OnAnimatorIK (int LayerIndex) {
		Anim.SetLookAtWeight(0.5f);
		Anim.SetLookAtPosition(HeadLook.position);
	}
}
