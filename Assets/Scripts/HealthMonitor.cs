using UnityEngine;

public class HealthMonitor : MonoBehaviour {

	public BaseUnit target;
	public RectTransform healthbar;
	private float startingSize;

	void Start () {
		startingSize = healthbar.sizeDelta.x;
	}
	
	//When the target is destroyed, update shouldn't be called
	//Better done using events.
	void Update() {

		if(target != null) {
			healthbar.sizeDelta = new Vector2(startingSize * ((float)target.curHealth/(float)target.MaxHealth), healthbar.sizeDelta.y);
		}

		//if (monitoredObject != null)
		//{
            //Debug.Log("Max: " + monitoredObject.GetComponentInChildren<BaseUnit>().MaxHealth);
            //Debug.Log("Cur: " + monitoredObject.GetComponentInChildren<BaseUnit>().CurHealth);
			//maxHealth = monitoredObject.MaxHealth;
			//curHealth = monitoredObject.CurHealth;

			//float width = (float) (curHealth ?? 0 / maxHealth);
			//healthbar.localScale = new Vector3(healthbar.localScale.x,
			//								   width,
			//								   healthbar.localScale.z);
		//}
	}
}
