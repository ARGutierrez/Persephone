using UnityEngine;
using System.Collections;

public class BasicPuzzleTrigger : MonoBehaviour {

    // The entity that can activate this trigger
    // Vertical slice only has skeleton
    public string solvingEntity = "Skeleton";

    // Sprite for this puzzle trigger
    public Sprite sprite;

    // Triggers associated 
    public GameObject[] triggers;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    /// <summary>
    /// Function to call to activate trigger
    /// </summary>
    void Interact()
    {

    }
}
