using UnityEngine;
using System.Collections;

public class Player8 : MonoBehaviour {
	public float moveSpeed = 32; //Pixels per second
	
	void Start () {
	
	}
	
	// Update is called once per frame but we 
	//convert it to seconds because of Time.deltaTime
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 translate = new Vector3(h, v, 0);
        translate = translate.normalized;

        transform.Translate(translate * moveSpeed * Time.deltaTime);

        /*
		if(Input.GetKey(KeyCode.W) || Input.GetKey (KeyCode.UpArrow))
			transform.Translate(new Vector3(0, moveSpeed, 0) * Time.deltaTime);

		if(Input.GetKey(KeyCode.S)|| Input.GetKey (KeyCode.DownArrow))
			transform.Translate(new Vector3(0, -moveSpeed, 0) * Time.deltaTime);

		if(Input.GetKey(KeyCode.A)|| Input.GetKey (KeyCode.LeftArrow))
			transform.Translate(new Vector3(-moveSpeed, 0, 0) * Time.deltaTime);

		if(Input.GetKey(KeyCode.D)|| Input.GetKey (KeyCode.RightArrow))
			transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);
         */
	}
}