using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {
	public GameObject target;
	public float damping = 1;
	Vector3 offset;
	
	void Start() {
		offset = target.transform.position - transform.position;
	}
	
	void LateUpdate() {
		//float currentAngle = transform.eulerAngles.z;
		//float desiredAngle = target.transform.eulerAngles.z;
		//float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
		
		//Quaternion rotation = Quaternion.Euler(0, angle, 0);
		transform.position = target.transform.position - (offset);
		
		transform.LookAt(target.transform);
	}
}