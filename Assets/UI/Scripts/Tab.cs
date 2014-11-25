using UnityEngine;

public class Tab : MonoBehaviour {
	public TabManager tabManager;
	public string description;
	void Awake () {
		Transform[] ancestors = GetComponentsInParent<Transform>();
		foreach(Transform child in ancestors){
			TabManager temp = child.gameObject.GetComponent<TabManager>();
			if (temp != null){
				tabManager = temp;
				break;
			}
		}
	}
	public void OnClick() {
		tabManager.changeTab(this);
	}
}
