using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;


public class MenuActions : MonoBehaviour {
	public AudioSource buttonClick;

    void Awake()
    {
        /*
         * TODO: Check if savegame exists
         * If exists, add/remove "Load Game" button as necessary
         */
    }
    
    public void ButtonClick(string description)
    {
		String levelToLoad = "";
		buttonClick.Play();

		switch(description)
		{
		case "LoadGame":  break;
		case "NewGame": levelToLoad = "Level1"; break;
		case "Prlouge": break;
		case "Options": levelToLoad = "Options Menu"; break;
		case "Crdits": break;
		case "Quit": break;
		}

		StartCoroutine(Delay(buttonClick.time + .4f, levelToLoad));
    }

	IEnumerator Delay(float delaySec, String level)
	{
		yield return new WaitForSeconds(delaySec); 
		if (!level.Equals(""))
			Application.LoadLevel(level);
	}
}
