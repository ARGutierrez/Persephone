using UnityEngine;
using System.Collections;

public class Player : BaseUnit
{
    #region Persephone Base Stats
    private readonly float BASE_HEALTH = 100f;
    private readonly float BASE_SPEED = 10f;
    #endregion

	MyInput input;

    void Start () {
		gameObject.GetComponent<SpriteRenderer>().sprite = sprite; 
		input = Reference.input;
		Reference.player = this;
        moveSpeed = BASE_SPEED;
		health = BASE_HEALTH;
	}
	
	// Update is called once per frame but we 
	//convert it to seconds because of Time.deltaTime
	void Update () 
    {
		//passes an empty value for the move function, player does not move towards a unit
        Move(null);
		//code for minion summoning
		//checks if 1 is down on alpha numbers or on numpad
		/*if (Input.GetKeyDown(KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.Keypad7))
		{
			//create skeleton at mouse pointer
			if(Input.GetMouseButtonDown(0))//checks if left mouse button is clicked
			{
				//add code to subtract will from persephone
			
				Instantiate(Skeleton, Input.mousePosition, Quaternion.identity);//need to spawn in proper location
			}
		}*/
	}
	//players move command is passed an empty variable to avoid an error
    protected override void Move(BaseUnit none)
    {
		float h = input.GetAxis("Horizontal");
		float v = input.GetAxis("Vertical");

		if (h == 0 && v == 0) {
			state = EntityState.IDLE;
		} else {
			state = EntityState.MOVING;
			Vector3 translate = new Vector3(h, v, 0);
			translate = translate.normalized;
			transform.Translate(translate * moveSpeed * Time.deltaTime);
		}
    }

    protected override void Attack(BaseUnit target)
    {
		state = EntityState.ATTACKING;
    }
    protected override void Die()
    {
		state = EntityState.DYING;
    }
}