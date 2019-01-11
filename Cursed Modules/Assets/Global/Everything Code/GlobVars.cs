using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobVars : MonoBehaviour {
	
	//Pause Game
	public static bool Paused;
	//Pause The Movement of the player but NOT the Game
	public static bool PlayerPaused;
	public static bool Reading;
	//Quests
	public static string[] Quests;
	public static string[] DoneQuests;
	//Interact
	public static bool NearInteractable;
	public static string InteractText;
<<<<<<< HEAD
	//Time
	public static int Days;
	public static int Hour;
	public static int Mins;
	public static int[] SunChangeTime = {6, 8, 18, 20};
=======
	//Vars for Player
	public static ItemObject Sword;
	public static ItemObject Shield;
	public static ItemObject Special;
>>>>>>> parent of d2b774e... Better Anim
}
