using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class SummonActions : MonoBehaviour {
    void Start()
    {
        /*
         * Check if summon is available
         * Set summon button enabled/disabled as necessary
         */ 
    }
    public void ButtonClick(string description)
    {
        SummonMinion[description].Invoke();
    }

    #region properties
    public Dictionary<string, Action> SummonMinion
    {
        get
        {
            return new Dictionary<string, Action>()
            {   
                {"Skeleton", () => Reference.player.Summon("Skeleton", 3) },
                {"Second", () => {} },
                {"Third", () => {} },
                {"Fourth", () => {} },
                {"Fifth", () => {} }
            };
        }
    }
    #endregion
}
