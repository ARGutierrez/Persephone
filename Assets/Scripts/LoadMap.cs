using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadMap : MonoBehaviour {
	void Start(){
		GetComponent<Image>().overrideSprite = (Sprite)Resources.Load("UI/MAP",typeof(Sprite));
		Debug.Log ("loaded");
	}
}