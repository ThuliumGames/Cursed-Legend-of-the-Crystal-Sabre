using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour {
	
	public bool holdingSw;
	public bool holdingSh;
	public bool holdingSp;
	
	public Transform Back1;
	public Transform Back2;
	public Transform Back3;
	public Transform Back4;
	public Transform Side1;
	public Transform Side2;
	public Transform Side3;
	public Transform Side4;
	
	public Transform SwordPos;
	public Transform ShieldPos;
	
	void Update () {
		if (GlobVars.Sword != null && holdingSw) {
			
		}
	}
}
