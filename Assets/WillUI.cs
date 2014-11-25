using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WillUI : MonoBehaviour {

	private Image[] renderers;
	public Sprite blue, gray, black;
	private int lastWill = 0;

	void Start () {
		renderers = GetComponentsInChildren<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if(lastWill != Will.will) {
			lastWill = Will.will;
			foreach (Image render in renderers) {
				render.sprite = black;
			}

			for( int i = 0; i <= Will.maxWill; i++) {
				renderers[i].sprite = gray;
			}

			for(int i = 0; i <= Will.will; i++) {
				renderers[i].sprite = blue;
			}
		}
	}
}