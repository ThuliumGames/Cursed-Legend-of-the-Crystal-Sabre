using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {
	
	public float Range;
	public float HeightUp;
	public bool WithinRange;
	
	public Canvas DialogueCanvas;
	public Image BackgroundImage;
	public Sprite BackgroundToUse;
	public Text RegWrite;
	public Text AnsWrite;
	public Text NameWrite;
	public GameObject GoToNext;
	
	public bool isSign;
	public TextAnchor TextAlign;
	public Color TextColor;
	public string[] Texts;
	public int[] NextText;
	public string[] AnsTexts;
	public int[] NextAnsText;
	public Dialogue[] ModOther;
	public int[] OtherNextText;
	public string[] DiffName;
	
	public int TextToRead = 0;
	public int AmOfAns = -1;
	
	bool DoneReading = false;
	bool DoneTalking = false;
	
	public float WT = 0.05f;
	
	bool Writing = false;
	bool isQuest = false;
	
	public string Words;
	
	void Update () {
		if (!GlobVars.PlayerPause || GlobVars.Reading) {
			if (Vector3.Distance (transform.position, GameObject.Find("Player").transform.position) <= Range) {
				WithinRange = true;
				if (GameObject.Find ("Select").transform.position == transform.position + new Vector3 (0, HeightUp, 0)) {
					if (SSInput.A[0] == "Pressed" && !GlobVars.Reading) {
						GlobVars.PlayerPause = true;
						GlobVars.Reading = true;
						DialogueCanvas.gameObject.SetActive(true);
						BackgroundImage.sprite = BackgroundToUse;
						RegWrite.color = TextColor;
						RegWrite.alignment = TextAlign;
						RegWrite.text = "";
						if (!Writing) {
							DoneReading = false;
							DoneTalking = false;
							if (TextToRead == 0) {
								TextToRead = 0;
							} else {
								TextToRead = NextText[TextToRead];
							}
							StartCoroutine(Write ());
							Writing = true;
						}
					}
					
					if (!isQuest) {
						if (SSInput.A[0] == "Pressed" || SSInput.B[0] == "Pressed") {
							if (DoneReading) {
								if (DoneTalking) {
									DoneReading = false;
									DoneTalking = false;
									DialogueCanvas.gameObject.SetActive(false);
									Writing = false;
									GlobVars.PlayerPause = false;
									GlobVars.Reading = false;
									GoToNext.SetActive(false);
								} else {
									DoneReading = false;
									DoneTalking = false;
									TextToRead = NextText[TextToRead];
									StartCoroutine(Write ());
									Writing = true;
								}
							}
						}
					} else {
						if (SSInput.A[0] == "Pressed") {
							if (DoneReading) {
								DoneReading = false;
								DoneTalking = false;
								TextToRead = NextAnsText[(TextToRead*4)+0];
								StartCoroutine(Write ());
								Writing = true;
							}
						}
						if (SSInput.B[0] == "Pressed") {
							if (DoneReading && AmOfAns > 1) {
								DoneReading = false;
								DoneTalking = false;
								TextToRead = NextAnsText[(TextToRead*4)+1];
								StartCoroutine(Write ());
								Writing = true;
							}
						}
						if (SSInput.X[0] == "Pressed") {
							if (DoneReading && AmOfAns > 2) {
								DoneReading = false;
								DoneTalking = false;
								TextToRead = NextAnsText[(TextToRead*4)+2];
								StartCoroutine(Write ());
								Writing = true;
							}
						}
						if (SSInput.Y[0] == "Pressed") {
							if (DoneReading && AmOfAns > 3) {
								DoneReading = false;
								DoneTalking = false;
								TextToRead = NextAnsText[(TextToRead*4)+3];
								StartCoroutine(Write ());
								Writing = true;
							}
						}
					}
				}
			} else {
				WithinRange = false;
			}
		}
	}
	IEnumerator Write () {
		bool DontFin = false;
		if (ModOther[TextToRead] != null) {
			ModOther[TextToRead].TextToRead = OtherNextText[TextToRead];
		}
		GoToNext.SetActive(false);
		if (DiffName[TextToRead] == "") {
			NameWrite.text = name;
		} else {
			NameWrite.text = DiffName[TextToRead];
		}
		RegWrite.text = "";
		AnsWrite.text = "";
		AmOfAns = -1;
		isQuest = false;
		int Skip = 0;
		foreach (char C in Texts[TextToRead]) {
			++Skip;
			if (C == '[') {
				DontFin = true;
				if ((SSInput.B[0] != "Down" || Skip < 3) && (!isSign || Skip < 2)) {
					yield return new WaitForSeconds (WT*4);
				}
				DoneReading = false;
				DoneTalking = false;
				TextToRead = NextText[TextToRead];
				StartCoroutine(Write ());
				Writing = true;
			} else {
				if (C == '_') {
					DoneReading = true;
					DoneTalking = true;
				} else if (C == '$') {
					isQuest = true;
				} else {
					if (C == '>') {
						RegWrite.text += "\n";
					} else {
						RegWrite.text += C;
					}
					if ((SSInput.B[0] != "Down" || Skip < 3) && (!isSign || Skip < 2)) {
						if (C == '.') {
							yield return new WaitForSeconds (WT*8);
						} else if (C == '?') {
							yield return new WaitForSeconds (WT*8);
						} else if (C == '!') {
							yield return new WaitForSeconds (WT*8);
						} else if (C == ',') {
							yield return new WaitForSeconds (WT*4);
						} else {
							yield return new WaitForSeconds (WT);
						}
					}
				}
			}
		}
		
		if (isQuest) {
			foreach (char C in AnsTexts[TextToRead]) {
				if (AmOfAns == -1) {
					AmOfAns = (int)(C)-48;
				} else {
					if (C == '>') {
						AnsWrite.text += "\n";
					} else {
						AnsWrite.text += C;
					}
					if ((SSInput.B[0] != "Down" || Skip < 3) && (!isSign || Skip < 2)) {
						yield return new WaitForSeconds (WT/10);
					}
				}
			}
		}
		
		if (!DontFin) {
			GoToNext.SetActive(true);
			DoneReading = true;
		}
	}
}
