using UnityEngine;
using UnityEngine.UI;
using System;

[ExecuteInEditMode]
public class TextToggleButton : MonoBehaviour {
	public string highText;
	public string lowText;
	public bool state;
	private string[] toggle;
	private Text text;

	public bool State {
		get{ return state; }
		set{
			state = value;
			text.text = toggle[Convert.ToInt16(state)];
		}
	}

	public string LowText{ 
		get{ return lowText; }
		set{
			lowText = value;
			toggle[0] = lowText;
		}
	}
	
	public string HighText {
		get{ return highText; }
		set{
			highText = value;
			toggle[1] = highText;
		}
	}

	void Awake() {
		toggle = new string[]{LowText, HighText};
		text = gameObject.GetComponentInChildren<Text>();

	}

	public void changeState() {
		state = !state;
		text.text = toggle[Convert.ToInt16(state)];
	}



}
