using UnityEngine;
using System.Collections;

public class GameUI : MonoBehaviour {
	public int bWidth = 200, bHeight = 40, spacing = 50;
	//TODO change these to percentages of screen size.
	
	void OnGUI () {
		//Gives us a button to start the game

		#region minion buttons
		int stackMult = 2;
		if(GUI.Button(new Rect (spacing, Screen.height - spacing - bHeight, bWidth, bHeight), new GUIContent ("Minion 1", "This is the tooltip"))) {
			Reference.player.Summon("Skeleton", 3);
		}

		if(GUI.Button(new Rect (spacing * stackMult + bWidth *(stackMult - 1), Screen.height - spacing - bHeight, bWidth, bHeight), new GUIContent ("Minion 2", "This is the tooltip"))) {
			//Spawn minion 2
		}
		stackMult ++;

		if(GUI.Button(new Rect (spacing * stackMult + bWidth * (stackMult - 1), Screen.height - spacing - bHeight, bWidth, bHeight), new GUIContent ("Minion 3", "This is the tooltip"))) {
			//Spawn minion 3
		}
		stackMult ++;

		if(GUI.Button(new Rect (spacing * stackMult + bWidth * (stackMult - 1), Screen.height - spacing - bHeight, bWidth, bHeight), new GUIContent ("Minion 4", "This is the tooltip"))) {
			//Spawn minion 4
		}
		stackMult ++;

		if(GUI.Button(new Rect (spacing * stackMult + bWidth * (stackMult - 1), Screen.height - spacing - bHeight, bWidth, bHeight), new GUIContent ("Minion 5", "This is the tooltip"))) {
			//Spawn minion 5
		}
		#endregion
	}
}