using UnityEngine;
using System.Collections;

public class Hieracosphinx : Enemy {
	#region Skeleton Base Stats
	private readonly int BASE_HEALTH = 50;
	private readonly float BASE_SPEED = 15f;
	private readonly int DAMAGE_PER_ATTACK = 10;
	private readonly float ATTACK_RANGE = 4f;
	private readonly float AGGRO_RANGE = 20f;
	#endregion

	private BaseUnit temp;
	private float lastAttack, attackRate = 1;

	// Use this for initialization
	void Start() {
		//set stats;
		curHealth = maxHealth = BASE_HEALTH;
		moveSpeed = BASE_SPEED;
		aggroRange = AGGRO_RANGE;
		attackRange = ATTACK_RANGE;
		seeker = GetComponent<Seeker>();
		//map marker
		minimap = GameObject.FindGameObjectWithTag("MiniMap").transform;
		marker = Instantiate(Resources.Load("EnemyMark")) as GameObject;
		marker.transform.parent = minimap.transform;
		marker.GetComponent<EnemyMark>().enemy = gameObject;

	}
	
	/// <summary>
	/// 1. Move toward targets in aggro range
	/// 2. Attack target if in range.
	/// 3. Else idle or dying;
	/// </summary>
	void Update () {
		temp = FindTarget ();
		if(temp != null)
			target = temp;
		if(target != null) { //If we have a target.
			distFromTarget = Vector3.Distance(target.transform.position, transform.position);
			
			if(distFromTarget <= attackRange) //Attack or move
				state = EntityState.ATTACKING;
			else if(distFromTarget <= aggroRange) {
				if(lastRepath < Time.time) {
					seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
					lastRepath = Time.time + repathRate;
					state = EntityState.MOVING;
				}
			}
		} else {
			state = EntityState.IDLE;
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
	
	protected override void Attack(){
		if(lastAttack + attackRate <= Time.time) {
			target.CurHealth -= DAMAGE_PER_ATTACK;
			lastAttack = Time.time;
		}
	}
}
