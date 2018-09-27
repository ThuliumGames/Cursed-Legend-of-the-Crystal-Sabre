using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobVars : MonoBehaviour {
	
	//Pause Game
	public static bool Paused;
	//Pause The Movement of the player but NOT the Game
	public static bool PlayerPause;
	public static bool Reading;
	//Quests
	public string[] Quests;
	public string[] DoneQuests;
	
	void Update () {
		int i = 0;
		foreach (string S in Quests) {
			int a = 0;
			foreach (string C in DoneQuests) {
				if (S == C) {
					Quests[i] = Quests[Quests.Length - 1];
					Array.Resize(ref Quests, Quests.Length - 1);
				}
				++a;
			}
			++i;
		}
	}
}
