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
	
	void Update () {
		if (!GlobVars.PlayerPaused || GlobVars.Reading) {
			transform.position = ObjToFollow.position;
			transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
<<<<<<< HEAD
=======
			ObjToFollow.eulerAngles = transform.eulerAngles;
>>>>>>> parent of 7e462bc... New Character
			transform.Rotate (0, SSInput.RHor[0]*100*Time.deltaTime, 0);
			transform.Translate (0, Up, -Back);
			transform.eulerAngles = new Vector3 (10, transform.eulerAngles.y, 0);
			UpDown += -SSInput.RVert[0]*100*Time.deltaTime;
			UpDown = Mathf.Clamp (UpDown, Min, Max);
			transform.RotateAround (ObjToFollow.position+new Vector3 (0,1,0), transform.right, UpDown);
<<<<<<< HEAD
=======
			
			RaycastHit Hit;
			Physics.Raycast (ObjToFollow.position+new Vector3 (0, Up, 0), -transform.forward, out Hit, Back+5, LM);
			if (Hit.distance != 0) {
				transform.Translate (0, 0, Back - Hit.distance+(5*(Hit.distance/10)));
			}
>>>>>>> parent of 686a447... Readded Dialogue
		}
			
	}
}
