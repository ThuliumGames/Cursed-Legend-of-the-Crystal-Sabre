using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CostomCode {
	public MonoBehaviour component;
	public string Command;
	public string QuestName;
}

[System.Serializable]
 public class SubArray {
    public Color TextColor;
	public int TextSize;
	public string Text;
	public int NextText;
	public string AnsText;
	public int[] NextAnsText;
	public Dialogue ModOther;
	public int OtherNextText;
	public string DiffName;
	[Header("")]
	[Header("For Costom Code Execution")]
	public CostomCode[] CodeToExecute;
 }

public class Dialogue : MonoBehaviour {
	
	public float Range;
	public float HeightUp;
	public bool WithinRange;
	[Header("")]
	public Canvas DialogueCanvas;
	public Image BackgroundImage;
	public Sprite BackgroundToUse;
	public Text RegWrite;
	public Text AnsWrite;
	public Text NameWrite;
	public GameObject GoToNext;
	[Header("")]
	public bool isSign;
	public TextAnchor TextAlign;
	public float WT = 0.05f;
	[Header("")]
	[Header("Commands: > = Line : * = Blue : ¡ = Large")]
	[Header("[ = Auto : $ = Question : _ = End : ~ = Command")]
	[Header("")]
	public SubArray[] DialogueVariables;
	
	int TextToRead = 0;
	int AmOfAns = -1;
	
	bool DoneReading = false;
	bool DoneTalking = false;
	
	bool Writing = false;
	bool isQuest = false;
	bool WaitForInput;
	
	string Words;
	
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
						RegWrite.alignment = TextAlign;
						RegWrite.text = "";
						if (!Writing) {
							DoneReading = false;
							DoneTalking = false;
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
									if (WaitForInput) {
										Exe (DialogueVariables[TextToRead].CodeToExecute.Length-1);
										WaitForInput = false;
									}
									TextToRead = DialogueVariables[TextToRead].NextText;
									DialogueCanvas.gameObject.SetActive(false);
									Writing = false;
									GlobVars.PlayerPause = false;
									GlobVars.Reading = false;
									GoToNext.SetActive(false);
								} else {
									DoneReading = false;
									DoneTalking = false;
									TextToRead = DialogueVariables[TextToRead].NextText;
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
								TextToRead = DialogueVariables[TextToRead].NextAnsText[0];
								StartCoroutine(Write ());
								Writing = true;
							}
						}
						if (SSInput.B[0] == "Pressed") {
							if (DoneReading && AmOfAns > 1) {
								DoneReading = false;
								DoneTalking = false;
								TextToRead = DialogueVariables[TextToRead].NextAnsText[1];
								StartCoroutine(Write ());
								Writing = true;
							}
						}
						if (SSInput.X[0] == "Pressed") {
							if (DoneReading && AmOfAns > 2) {
								DoneReading = false;
								DoneTalking = false;
								TextToRead = DialogueVariables[TextToRead].NextAnsText[2];
								StartCoroutine(Write ());
								Writing = true;
							}
						}
						if (SSInput.Y[0] == "Pressed") {
							if (DoneReading && AmOfAns > 3) {
								DoneReading = false;
								DoneTalking = false;
								TextToRead = DialogueVariables[TextToRead].NextAnsText[3];
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
		string ColorText = "";
		string ColorLetters = "";
		string SizeText = "";
		string SizeLetters = "";
		int Code = 0;
		RegWrite.color = DialogueVariables[TextToRead].TextColor;
		RegWrite.fontSize = DialogueVariables[TextToRead].TextSize;
		bool DontFin = false;
		if (DialogueVariables[TextToRead].ModOther != null) {
			DialogueVariables[TextToRead].ModOther.TextToRead = DialogueVariables[TextToRead].OtherNextText;
		}
		GoToNext.SetActive(false);
		if (DialogueVariables[TextToRead].DiffName == "") {
			NameWrite.text = name;
		} else {
			NameWrite.text = DialogueVariables[TextToRead].DiffName;
		}
		RegWrite.text = "";
		AnsWrite.text = "";
		AmOfAns = -1;
		isQuest = false;
		int Skip = 0;
		bool isColor = false;
		bool isSize = false;
		foreach (char C in DialogueVariables[TextToRead].Text) {
			++Skip;
			if (C == '[') {
				DontFin = true;
				if ((SSInput.B[0] != "Down" || Skip < 3) && (!isSign || Skip < 2)) {
					yield return new WaitForSeconds (WT*4);
				} else {
					yield return new WaitForSeconds (WT*16);
				}
				DoneReading = false;
				DoneTalking = false;
				TextToRead = DialogueVariables[TextToRead].NextText;
				StartCoroutine(Write ());
				Writing = true;
			} else {
				if (C == '_') {
					DoneReading = true;
					DoneTalking = true;
				} else if (C == '$') {
					isQuest = true;
				} else if (C == '~') {
					char L = DialogueVariables[TextToRead].Text[Skip];
					if (L == '_') {
						WaitForInput = true;
					} else {
						Exe (Code);
						++Code;
					}
				} else if (C == '*') {
					if (isColor) {
						isColor = false;
					} else {
						ColorLetters = "";
						ColorText = RegWrite.text;
						isColor = true;
					}
				} else if (C == '¡') {
					if (isSize) {
						isSize = false;
					} else {
						SizeLetters = "";
						SizeText = RegWrite.text;
						isSize = true;
					}
				} else {
					if (C == '>') {
						RegWrite.text += "\n";
					} else {
						if (!isSign || Skip > 2) {
							if (isSign && Skip < 4) {
								char F = DialogueVariables[TextToRead].Text[0];
								char S = DialogueVariables[TextToRead].Text[1];
								RegWrite.text += F;
								RegWrite.text += S;
							}
							if (isColor) {
								ColorLetters += C;
								RegWrite.text = ColorText + "<color=#0088ff>" + ColorLetters + "</color>";
							} else if (isSize) {
								SizeLetters += C;
								RegWrite.text = SizeText + "<size="+ DialogueVariables[TextToRead].TextSize*2 + ">" + SizeLetters + "</size>";
							} else {
								RegWrite.text += C;
							}
						}
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
			foreach (char C in DialogueVariables[TextToRead].AnsText) {
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
	void Exe (int Num) {
		if (DialogueVariables[TextToRead].CodeToExecute[Num].Command == "GiveQuest") {
			GameObject.FindObjectOfType<Quest>().GiveQuest(DialogueVariables[TextToRead].CodeToExecute[Num].QuestName);
		} else if (DialogueVariables[TextToRead].CodeToExecute[Num].Command == "CompleteQuest") {
			GameObject.FindObjectOfType<Quest>().CompleteQuest(DialogueVariables[TextToRead].CodeToExecute[Num].QuestName);
		} else {
			DialogueVariables[TextToRead].CodeToExecute[Num].component.StartCoroutine(DialogueVariables[TextToRead].CodeToExecute[Num].Command);
		}
	}
}
