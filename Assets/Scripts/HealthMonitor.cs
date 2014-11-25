using UnityEngine;

public class HealthMonitor : MonoBehaviour {

	public GameObject monitoredObject;
	private Transform healthbar;
	private int? maxHealth, curHealth;

	void Start () {
		healthbar = gameObject.transform;
	}
	
	//When the target is destroyed, update shouldn't be called
	//Better done using events.
	void Update() {
		if (monitoredObject)
		{
            //Debug.Log("Max: " + monitoredObject.GetComponentInChildren<BaseUnit>().MaxHealth);
            //Debug.Log("Cur: " + monitoredObject.GetComponentInChildren<BaseUnit>().CurHealth);
			maxHealth = monitoredObject.GetComponentInChildren<BaseUnit>().MaxHealth;
			curHealth = monitoredObject.GetComponentInChildren<BaseUnit>().CurHealth;
			float width = (float) (curHealth ?? 0 / maxHealth);
			healthbar.localScale = new Vector3(healthbar.localScale.x,
											   width,
											   healthbar.localScale.z);
		}
	}
}
