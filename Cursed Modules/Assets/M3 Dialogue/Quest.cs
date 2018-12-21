using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour {
	
	public Animator Anim;
	public AudioSource AS;
	
	public void GiveQuest (string QuestName) {
		bool CanGive = true;
		foreach (string S in GameObject.Find("MustHaveToWork").GetComponent<GlobVars>().Quests) {
			if (QuestName == S) {
				CanGive = false;
			}
		}
		if (CanGive) {
			AS.Play();
			Array.Resize (ref GameObject.Find("MustHaveToWork").GetComponent<GlobVars>().Quests, GameObject.Find("MustHaveToWork").GetComponent<GlobVars>().Quests.Length + 1);
			GameObject.Find("MustHaveToWork").GetComponent<GlobVars>().Quests[GameObject.Find("MustHaveToWork").GetComponent<GlobVars>().Quests.Length - 1] = QuestName;
			GameObject.Find(Anim.gameObject.name+"/AnimImage/GetOrNot").GetComponent<Text>().text = "New Quest\n";
			GameObject.Find(Anim.gameObject.name+"/AnimImage/QName").GetComponent<Text>().text = QuestName;
			Anim.Play("Show");
		}
	}
	
	public void CompleteQuest (string QuestName) {
		bool CanGive = true;
		foreach (string S in GameObject.Find("MustHaveToWork").GetComponent<GlobVars>().DoneQuests) {
			if (QuestName == S) {
				CanGive = false;
			}
		}
		if (CanGive) {
			AS.Play();
			Array.Resize (ref GameObject.Find("MustHaveToWork").GetComponent<GlobVars>().DoneQuests, GameObject.Find("MustHaveToWork").GetComponent<GlobVars>().DoneQuests.Length + 1);
			GameObject.Find("MustHaveToWork").GetComponent<GlobVars>().DoneQuests[GameObject.Find("MustHaveToWork").GetComponent<GlobVars>().DoneQuests.Length - 1] = QuestName;
			GameObject.Find(Anim.gameObject.name+"/AnimImage/GetOrNot").GetComponent<Text>().text = "Quest Complete\n";
			GameObject.Find(Anim.gameObject.name+"/AnimImage/QName").GetComponent<Text>().text = QuestName;
			Anim.Play("Show");
		}
	}
}
