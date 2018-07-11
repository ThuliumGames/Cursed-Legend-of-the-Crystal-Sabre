using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	
	public RectTransform Cursor;
	public RectTransform[] Buttons;
	bool[] Selected = {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false};
	public string[] CodeToExecute;
	
	void Start () {
		Cursor.localPosition = Vector3.zero;
	}
	
	void Update () {
		
		int i = 0;
		
		//Cursor
		if (SSInput.LS[0] == "Down") {
			Cursor.localPosition += new Vector3 (SSInput.LHor[0]*750*Time.deltaTime, SSInput.LVert[0]*750*Time.deltaTime, 0);
		} else {
			Cursor.localPosition += new Vector3 (SSInput.LHor[0]*250*Time.deltaTime, SSInput.LVert[0]*250*Time.deltaTime, 0);
		}
		Cursor.localPosition = new Vector3 (Mathf.Clamp (Cursor.localPosition.x, -960, 960), Mathf.Clamp (Cursor.localPosition.y, -540, 540), 0);
		
		//Buttons
		foreach (RectTransform I in Buttons) {
			if ((Cursor.localPosition.x > I.localPosition.x - (I.rect.width/2) && Cursor.localPosition.x < I.localPosition.x + (I.rect.width/2)) &&
			(Cursor.localPosition.y > I.localPosition.y - (I.rect.height/2) && Cursor.localPosition.y < I.localPosition.y + (I.rect.height/2))) {
				I.GetComponent<Image>().color = Color.grey;
				Selected[i] = true;
			} else {
				I.GetComponent<Image>().color = Color.white;
				Selected[i] = false;
			}
			++i;
		}
		
		i = 0;
		
		//Do the thing when player presses A
		if (SSInput.A[0] == "Pressed") {
			foreach (bool S in Selected) {
				if (S) {
					Buttons[i].GetComponent<MenuCommand>().StartCoroutine(CodeToExecute[i]);
				}
				++i;
			}
		}
	}
}
