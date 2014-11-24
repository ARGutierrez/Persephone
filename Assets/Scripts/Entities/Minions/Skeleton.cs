using UnityEngine;
using System.Collections;
using Pathfinding;

public class Skeleton : Minion
{
	#region Skeleton Base Stats
	private readonly int BASE_HEALTH = 120;
	private readonly float BASE_SPEED = 15f;//TODO design says 4 ft per second....how does that translate?
	public static readonly int WILL_COST = 3; 
	private readonly int DAMAGE_PER_ATTACK = 10;
	private readonly float ATTACK_RANGE = 4f;
	private readonly float AGGRO_RANGE = 20f;
	#endregion

	private float lastAttack, attackRate = 1;

    // Use this for initialization
    void Start()
    {
        //set CurHealth and moveSpeed
		CurHealth = MaxHealth = BASE_HEALTH;
        moveSpeed = BASE_SPEED; // higher than player base speed
        followDistance = 10f;//gives distance skeleton is from persephone
		attackRange = ATTACK_RANGE;
		aggroRange = AGGRO_RANGE;
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
				if(lastRepath < Time.time) {
					seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
					lastRepath = Time.time + repathRate;
					state = EntityState.MOVING;
				}
			} else {
				state = EntityState.IDLE;
			}
		} else { // If target is not player
			if(distFromTarget > attackRange) {
				if(lastRepath < Time.time) {
					seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
					lastRepath = Time.time + repathRate;
					state = EntityState.MOVING;
				}
			} else {
				state = EntityState.ATTACKING;
			}
		}

		if (CurHealth <= 0) 
        {
			state = EntityState.DYING;
		}

		switch(state) {
		case EntityState.MOVING: Move(); break;
		case EntityState.ATTACKING: Attack(); break;
		case EntityState.DYING: Die(); break;
		}
	}

	protected override void Attack()
	{
		if(lastAttack + attackRate <= Time.time) {
			target.CurHealth -= DAMAGE_PER_ATTACK;
			lastAttack = Time.time;
		}
	}
	
	//return used will and add back to the pool
	public override void Die()
	{
		Will.returnWill(WILL_COST);
		ObjectPool.instance.PoolObject(this.gameObject);
	}
}