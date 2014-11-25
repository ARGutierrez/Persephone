using UnityEngine;
using System.Collections;
public class MinionMark : MonoBehaviour {
	public float mheight=225,mwidth=225,fheight=717,fwidth=717;
	private Transform marker;
	public GameObject minion;

	void Start(){
		marker = gameObject.transform;
	}
	void Update(){
		//transform.position = Vector3.MoveTowards(transform.position, targetUnit.transform.position, moveSpeed * Time.deltaTime);
		float xpos=minion.transform.position.x/3.1866f;
		float ypos=minion.transform.position.y/3.1866f;
		transform.localPosition = new Vector3(xpos,ypos,0);
	}
}
