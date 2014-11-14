using UnityEngine;
using System.Collections;
using Pathfinding;

public class Skeleton : Minion
{
	#region Skeleton Base Stats
	private readonly int BASE_HEALTH = 60;
	private readonly float BASE_SPEED = 15f;//TODO design says 4 ft per second....how does that translate?
	private readonly int WILL_COST = 3; 
	private readonly int DAMAGE_PER_ATTACK = 10;
	private readonly float ATTACK_RANGE = 4f;
	#endregion
	
    public float nextWaypointDistance = 3;

    // Use this for initialization
    void Start()
    {
        //set CurHealth and moveSpeed
		MaxHealth = BASE_HEALTH;
        CurHealth = BASE_HEALTH; //placeholder value
        moveSpeed = BASE_SPEED; // higher than player base speed
        followDistance = 10f;//gives distance skeleton is from persephone
        seeker = GetComponent<Seeker>();

		if (player == null)
			getPlayer();

    }

	/// <summary>
	/// 1. Move skeleton
	/// 2. If skeleton is within attack range it will switch target to that enemy.
	/// 3. If Skeleton has no enemy target it will follow persephone.
	/// 4. If within follow range of Persephone and no target set state to IDLE.
	/// </summary>

	void Update() {
		//test for target
		target = FindTarget();
		if(target == null) {
			target = player;
		}

		distFromTarget = Vector3.Distance(target.transform.position, transform.position);

		if(target == player) { //If the target is the player
			if(distFromTarget > followDistance) {
				seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
				state = EntityState.MOVING;
			} else {
				state = EntityState.IDLE;
			}
		} else { // If target is not player
			if(distFromTarget > ATTACK_RANGE) {
				seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
				state = EntityState.MOVING;
			} else {
				state = EntityState.ATTACKING;
			}
		}

		if (CurHealth <= 0) {
			state = EntityState.DYING;
		}

		switch(state) {
		case EntityState.MOVING: Move(); break;
		case EntityState.ATTACKING: Attack(); break;
		case EntityState.DYING: Die(); break;
		}
	}

    protected override void Move()
    {
		if (path == null) {
			return;
		}

		//Advance to the next waypoint.
		transform.position = Vector3.MoveTowards(transform.position, path.vectorPath[1], moveSpeed * Time.deltaTime);
    }

    protected override void Attack()
    {
		target.CurHealth = target.CurHealth - DAMAGE_PER_ATTACK;
    }

    protected override void Die()
    {
		//Need code to delay death for legnth of animation.
        //state = EntityState.DYING;
        Destroy(this.gameObject);
        //add code to give will back to persephone
		(player).CurWill += WILL_COST;
    }
}