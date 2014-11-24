using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;


public class MenuActions : MonoBehaviour {

    void Awake()
    {
        /*
         * TODO: Check if savegame exists
         * If exists, add/remove "Load Game" button as necessary
         */
    }
    
    public void ButtonClick(string description)
    {
        menuButtons[description].Invoke();
    }

    #region properties
    public Dictionary<string, Action> menuButtons
    {
        get
        {
            return new Dictionary<string, Action>()
            {   
                //TODO: Implement loading logic. Assume multiple saves available.
                {"LoadGame", () => {} },
                //Better way is to LoadGame() on a savegame's default ctor.
                {"NewGame", () => Application.LoadLevel("Level1")},
                {"Prologue", () => {} },
                //Wait for art/content to decide how Options should appear
                {"Options", () => Application.LoadLevel("Options Menu")},
                {"Credits", () => {} },
                {"Quit", () => Application.Quit() }
            };
        }
    }
    #endregion
}
