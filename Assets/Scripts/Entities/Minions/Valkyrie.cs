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
		distFromTarget = Vector3.Distance (player.transform.position, transform.position);

		if (state == EntityState.IDLE) {
			// play idle animation
			
			//checks if target is not null
			if (target) {
				state = EntityState.ATTACKING;
			} else if (distFromTarget > followDistance) {
				state = EntityState.MOVING;
			}
		}
		if (state == EntityState.MOVING) {
			//move to persephone
			Move ();	
			//checks if target is not null
			if (target) {
				state = EntityState.ATTACKING;
			} else if (distFromTarget <= followDistance) {
				state = EntityState.IDLE;
			}
		}
		if (state == EntityState.ATTACKING) {
			distFromTarget= Vector3.Distance (target.transform.position, transform.position);;
			if (distFromTarget <= attackRange) {
				Attack ();
			} else {
				Move ();
			}
			
			if (target.CurHealth <= 0) {
				target = FindTarget ();//finds the closest enemy target
				if (target) {
					state = EntityState.ATTACKING;
				} else {
					state = EntityState.MOVING;
					Move ();
				}
			}
		}
	}

	protected override void Move()
	{
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, moveSpeed * Time.deltaTime);
	}
	
	protected override void Attack()
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