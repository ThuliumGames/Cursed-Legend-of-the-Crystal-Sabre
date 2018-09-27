using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour {
	
	public string AnimToPlay;
	
	void Pl () {
		GetComponent<Animator>().Play(AnimToPlay);
	}
	
}
