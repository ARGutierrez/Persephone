using UnityEngine;
using System.Collections;

public class EndOfScene : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter () {
		Application.LoadLevel("level2"); 

	}
	

}
