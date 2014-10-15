using UnityEngine;
using System.Collections;

public class Player : BaseUnit
{
    #region Persephone Base Stats
    private readonly float BASE_HEALTH = 10f;
    private readonly float BASE_SPEED = 10f;
    #endregion

    void Start () {
        moveSpeed = BASE_SPEED;
		health = BASE_HEALTH;
	}
	
	// Update is called once per frame but we 
	//convert it to seconds because of Time.deltaTime
	void Update () 
    {
        Move();
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

    protected override void Move()
    {
		state = EntityState.MOVING;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 translate = new Vector3(h, v, 0);
        translate = translate.normalized;

        transform.Translate(translate * moveSpeed * Time.deltaTime);
    }

    protected override void Attack(GameObject target, float distanceToTarget)
    {
		state = EntityState.ATTACKING;
    }
    protected override void Die()
    {
		state = EntityState.DYING;
    }
}