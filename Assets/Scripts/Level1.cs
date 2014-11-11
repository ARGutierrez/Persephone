using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		while (ObjectPool.instance.pooledObjects == null) {
		}
		while (ObjectPool.instance.pooledObjects.Length < 1) {
		}
		ObjectPool.instance.GetObjectForType ("Player", true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
