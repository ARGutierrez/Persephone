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
		if(Input.GetButtonDown("Summon")) {
			Reference.player.Summon("Skeleton", Skeleton.WILL_COST);
		}

		/*if(Input.GetButtonDown("Summon2")) {
			Reference.player.Summon("Skeleton", 3);
		}

		if(Input.GetButtonDown("Summon3")) {
			Reference.player.Summon("Skeleton", 3);
		}

		if(Input.GetButtonDown("Summon4")) {
			Reference.player.Summon("Skeleton", 3);
		}

		if(Input.GetButtonDown("Summon5")) {
			Reference.player.Summon("Skeleton", 3);
		}*/

		if(Input.GetButtonDown("Despawn") && Will.count > 0) {
			GameObject[] minions = GameObject.FindGameObjectsWithTag("Minion");
			BaseUnit minion = (BaseUnit) minions[0].GetComponent<BaseUnit>();
			minion.Die();
		}

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
		case "Vertical": return vertical; 
			
		case "Horizontal": return horizontal; 
			
		default: return 0;
		}
	}
}