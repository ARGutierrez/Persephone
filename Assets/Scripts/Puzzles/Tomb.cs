using UnityEngine;
using System.Collections;

public class Tomb : BasicPuzzleTrigger {

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void Interact()
    {
        int numTriggers = triggers.Length;
        if (numTriggers > 0)
        {
            foreach (GameObject go in triggers)
            {
                go.SetActive(false);
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }
}
