using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TabManager : MonoBehaviour {
	List<Tab> tabs = new List<Tab>();
	List<TabContent> tabContent = new List<TabContent>();

	//Enumerate all child tabs upon initialization
	void Awake() { 
		Transform[] descendents = GetComponentsInChildren<Transform>();
		foreach(Transform child in descendents){
			Tab temp = child.gameObject.GetComponent<Tab>();
			if (temp != null)
				tabs.Add(temp);
		}

		//Find each Tab's corresponding TabContent
		foreach(Tab tab in tabs){
			foreach (Transform child in descendents) {
				TabContent temp;
				//Each Tab has a corresponding TabContent with equivalent description
				if (temp = child.gameObject.GetComponent<TabContent>()){
					if (tab.description.Equals(temp.description)){
						tabContent.Add(temp);
						break;
					}
				}
			}
		}
	}
	
	public void changeTab(Tab tab){
		int tabIndex = tabs.IndexOf(tab);
		for (int i = 0; i < tabs.Count; ++i) {
			//Switch the states of the tab button and corresponding content panel
			tabs[i].gameObject.GetComponent<Button>().interactable = !(i == tabIndex);
			tabContent[i].gameObject.SetActive(i == tabIndex);
		}
	}
}
