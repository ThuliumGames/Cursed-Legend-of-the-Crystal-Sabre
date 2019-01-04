using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {

	public static int Days;
	public static int Hour;
	public static int Mins;
	public float Count;

	int[] SunChangeTime = {6, 8, 18, 20};

	public float SunDimTime = 0.01f;
	float[] SunIntensity = {0.5f, 1f, 0.25f, 0f};

	public DayPhase _dayPhase;

	public enum DayPhase {Dawn, Day, Dusk, Night}

	Light SunLight;
	

	void Start () {
		StartCoroutine ("TimeOfDay");
		SunLight = GetComponent <Light>();
		_dayPhase = DayPhase.Dawn;
		SunLight.intensity = SunIntensity[0];
		Hour = 6;
		Mins = 0;
		Count = 0;
		Days = 1;
	}
	

	void Update () {
		
	}

	IEnumerator TimeOfDay () {
		while (true) {
			switch(_dayPhase) {
			case DayPhase.Dawn:
				Dawn();
				break;
			case DayPhase.Day:
				Day();
				break;
			case DayPhase.Dusk:
				Dusk();
				break;
			case DayPhase.Night:
				Night();
				break;
			}
			yield return null;
		}
	}

	void Dawn () {
		if (SunLight.intensity < SunIntensity[0]) {
			SunLight.intensity += SunDimTime * Time.deltaTime;
		} else {
			SunLight.intensity = SunIntensity[0];
		}

		if (Hour == SunChangeTime[1]) {
			_dayPhase = DayPhase.Day;
		}
	}

	void Day () {
		
	}

	void Dusk () {
		
	}

	void Night () {
		
	}
}
