using UnityEngine;
using System.Collections;

public class MenuUI : MonoBehaviour {
	public int bWidth = 200, bHeight = 40, spacing = 50;

	void OnGUI () {
		//Gives us a button to start the game
		if(GUI.Button(new Rect (Screen.width/2 - bWidth/2, Screen.height/2 - bHeight/2, bWidth, bHeight), new GUIContent ("Start Game", "This is the tooltip"))) {
			Application.LoadLevel("Level1");
		}

		//TODO Put in title sprite and make correct buttons according to menu.
	}
}