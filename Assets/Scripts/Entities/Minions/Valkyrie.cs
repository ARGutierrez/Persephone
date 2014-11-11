using UnityEngine;
using System.Collections;

public class Valkyrie : Minion {
	
	// Use this for initialization
	void Start () {
		state = EntityState.IDLE;
		//set CurHealth and moveSpeed
		CurHealth = 20; //placeholder value
		moveSpeed = 15f; // faster than player base speed
		followDistance = 4f;
		attackRange = 10f; 
	}
	
	// Update is called once per frame
	void Update () {
		//code for death
		if (CurHealth <= 0) {
			Die ();
		}

		target = FindTarget();
		distFromPlayer = Vector3.Distance (player.transform.position, transform.position);

		if (state == EntityState.IDLE) {
			// play idle animation
			
			//checks if target is not null
			if (target) {
				state = EntityState.ATTACKING;
			} else if (distFromPlayer > followDistance) {
				state = EntityState.MOVING;
			}
		}
		if (state == EntityState.MOVING) {
			//move to persephone
			Move (player);	
			//checks if target is not null
			if (target) {
				state = EntityState.ATTACKING;
			} else if (distFromPlayer <= followDistance) {
				state = EntityState.IDLE;
			}
		}
		if (state == EntityState.ATTACKING) {
			float distFromTarget= Vector3.Distance (target.transform.position, transform.position);;
			if (distFromTarget <= attackRange) {
				Attack (target);
			} else {
				Move (target);
			}
			
			if (target.CurHealth <= 0) {
				target = FindTarget ();//finds the closest enemy target
				if (target) {
					state = EntityState.ATTACKING;
				} else {
					state = EntityState.MOVING;
					Move (player);
				}
			}
		}
	}

	protected override void Move(BaseUnit targetUnit)
	{
		transform.position = Vector3.MoveTowards (transform.position, targetUnit.transform.position, moveSpeed * Time.deltaTime);
	}
	
	protected override void Attack(BaseUnit enemy)
	{
		//do Attack animation
		//code for damage dealt and received goes here
	}
	protected override void Die()
	{
		state = EntityState.DYING;
		Destroy (this.gameObject);
		//add code to give will back to persephone
	}
}