using UnityEngine;
using System.Collections;

public class MyInput : MonoBehaviour {
	
	float vertical = 0;
	float horizontal = 0;
	int MouseX = 0, MouseY = 0;
	const int NUM_POWERS = 6;
	bool[] powers = new bool[NUM_POWERS];
	
	void Awake() {
		Reference.input = this;
	}
	
	void Update () {
		if (Application.platform == RuntimePlatform.Android) {
			MobileInput();
		} else {
			PCInput(); 	
		}
	}
	
	//This function will handl any PC input we need such as keyboard input
	private void PCInput() {
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");
	}
	
	//This function will handl any Mobile input we need such as touch actions
	private void MobileInput() {
		
	}
	
	
	//This function allows us to access the axis in a similiar fasion to the Unity Input Manager.
	public float GetAxis(string axis) {
		switch (axis)
		{
		case "Vertical": return vertical; break;
			
		case "Horizontal": return horizontal; break;
			
		default: return 0;
		}
	}
}