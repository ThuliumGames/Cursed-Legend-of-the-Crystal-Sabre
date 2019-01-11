using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCommand : MonoBehaviour {
	
	public string Type;
	public bool isDraging;
	public static MenuCommand OrigPar;
	
	void Start () {
		OrigPar = null;
	}

	void StartGame () {
		
	}
	
	void EndGame () {
		
	}
	
	public void PutBack () {
		GameObject.Find ("Par").GetComponentInChildren<Image>().gameObject.name = name+"Image";
		GameObject.Find (name+"Image").transform.SetParent(transform);
		GameObject.Find (name+"Image").transform.localPosition = new Vector3 (0,0,0);
		OrigPar.isDraging = false;
	}
	
	void MoveItem () {
		if (GameObject.Find (name+"Image").GetComponent<Image>().sprite != GameObject.Find("Visuals").GetComponent<Menu>().EmptySprite && GameObject.Find ("Par").GetComponentInChildren<Image>() == null) {
			if (!isDraging) {
				OrigPar = this;
				GameObject.Find (name+"Image").transform.SetParent(GameObject.Find ("Par").transform);
				GameObject.Find (name+"Image").transform.localPosition = new Vector3 (0,0,0);
				isDraging = true;
			} else {
				GameObject.Find ("Par").GetComponentInChildren<Image>().gameObject.name = name+"Image";
				GameObject.Find (name+"Image").transform.SetParent(transform);
				GameObject.Find (name+"Image").transform.localPosition = new Vector3 (0,0,0);
				
				OrigPar.isDraging = false;
			}
		} else {
			if (GameObject.Find ("Par").GetComponentInChildren<Image>() != null && Type == OrigPar.Type) {
				GameObject.Find ("Par").GetComponentInChildren<Image>().gameObject.transform.SetParent(transform);
				GameObject.Find (name+"Image").transform.SetParent(OrigPar.gameObject.transform);
				GameObject.Find (name+"Image").transform.localPosition = new Vector3 (0,0,0);
				GameObject.Find (name+"Image").name = OrigPar.gameObject.name + "Image";
				foreach (Image I in GetComponentsInChildren<Image>()) {
					if (I.gameObject != this.gameObject) {
						I.gameObject.name = name+"Image";
					}
				}
				GameObject.Find (name+"Image").transform.localPosition = new Vector3 (0,0,0);
				
				OrigPar.isDraging = false;
			}
		}
	}
	
	void Drop () {
		if (GameObject.Find ("Par").GetComponentInChildren<Image>() != null) {
			GameObject.Find ("Par").GetComponentInChildren<Image>().gameObject.name = OrigPar.gameObject.name+"Image";
			GameObject.Find (OrigPar.gameObject.name+"Image").transform.SetParent(OrigPar.gameObject.transform);
			GameObject.Find (OrigPar.gameObject.name+"Image").transform.localPosition = new Vector3 (0,0,0);
			GameObject.Find (OrigPar.gameObject.name+"Image").GetComponent<Image>().sprite = GameObject.Find("Visuals").GetComponent<Menu>().EmptySprite;
			if (GameObject.FindObjectOfType<EquipedWeapon>().GetComponentInChildren<Items>() != null) {
				if (GameObject.Find (OrigPar.gameObject.name+"Image").GetComponent<Items>().ItemObject.GetComponent<Items>().ItemName == GameObject.FindObjectOfType<EquipedWeapon>().GetComponentInChildren<Items>().ItemName) {
					GameObject.FindObjectOfType<EquipedWeapon>().DesWep();
				}
			}
			GameObject G = Instantiate (GameObject.Find (OrigPar.gameObject.name+"Image").GetComponent<Items>().ItemObject, GameObject.FindObjectOfType<Movement>().gameObject.transform.position+GameObject.FindObjectOfType<Movement>().gameObject.transform.forward + new Vector3 (0, 1, 0), Quaternion.Euler (Vector3.zero));
			G.AddComponent<Rigidbody>();
			G.layer = LayerMask.NameToLayer ("Default");
			foreach (MeshRenderer GO in G.GetComponentsInChildren<MeshRenderer>()) {
				GO.gameObject.layer = LayerMask.NameToLayer ("Default");
			}
			G.GetComponent<Items>().ItemObject = GameObject.Find (OrigPar.gameObject.name+"Image").GetComponent<Items>().ItemObject;
			GameObject.Find (OrigPar.gameObject.name+"Image").GetComponent<Items>().ItemName = "";
			GameObject.Find (OrigPar.gameObject.name+"Image").GetComponent<Items>().ItemImage = null;
			GameObject.Find (OrigPar.gameObject.name+"Image").GetComponent<Items>().ItemObject = null;
			OrigPar.isDraging = false;
		}
	}
}
