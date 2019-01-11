using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Item", order = 0)]

public class Item : ScriptableObject {
	
	public string Type;
	
<<<<<<< HEAD
=======
	[Header("If Food: Health   If Weapon: Damage")]
	
	public int ProgNum = 10;
	
>>>>>>> parent of f5a0b0d... Bugs
	public bool[] CanBeEquipedIn = {false, false, true};
	
	public GameObject Model;
	public Sprite sprite;
	
	public int StackSize = 1;
	
	public string[] MenuOptions;
}
