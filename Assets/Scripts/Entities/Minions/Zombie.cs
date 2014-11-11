using UnityEngine;
using System.Collections;

public class Zombie : Minion {
	
	// Use this for initialization
	void Start () {
		state = EntityState.IDLE;
		//set health and moveSpeed
		health = 100; //placeholder value
		moveSpeed = 15f; // faster than player base speed
		followDistance = 4f;//gives distance skeleton is from persephone
		attackRange = 4f;
		seeker = GetComponent<Seeker>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//code for death
		if (health <= 0) {
			Die ();
		}
		BaseUnit target = FindTarget ();//finds the closest enemy target
		//gives distance Zombie is from persephone
		float distFromPlayer = Vector3.Distance (getPlayer().transform.position, transform.position);
		//the distance that persephone can be from Zombie before he moves to follow
		float followDistance = 4f;
		float attackRange = 6f; 
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
			Move (getPlayer());	
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
			
			if (target.health <= 0) {
				target = FindTarget ();//finds the closest enemy target
				if (target) {
					state = EntityState.ATTACKING;
				} else {
					state = EntityState.MOVING;
					Move (getPlayer());
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
		//code for damage dealt and received goes here
	}

	protected override void Die()
	{
		state = EntityState.DYING;
		Destroy (this.gameObject);
		//add code to give will back to persephone
		
	}
}

