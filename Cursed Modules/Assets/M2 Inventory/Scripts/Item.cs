using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Item", order = 0)]

public class Item : ScriptableObject {
	
	public string Type;
	
	public bool[] CanBeEquipedIn = {false, false, true};
	
	public GameObject Model;
	public Sprite sprite;
	
	public int StackSize = 1;
	
	public string[] MenuOptions;
}
