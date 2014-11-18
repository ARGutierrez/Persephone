using UnityEngine;
using System.Collections;

public class Poltergeist : Minion {
	
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
		CurHealth = MaxHealth = BASE_HEALTH;
		moveSpeed = BASE_SPEED; // higher than player base speed
		followDistance = 10f;//gives distance skeleton is from persephone
		attackRange = ATTACK_RANGE;
		seeker = GetComponent<Seeker>();
		
		if (player == null)
			getPlayer();
	}
	
	// Update is called once per frame
	void Update () {
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
		
		if (currentWP >= path.vectorPath.Count)
			currentWP = 0;
		else {
			Vector3 dir = (path.vectorPath[currentWP]-transform.position).normalized;
			dir *= moveSpeed * Time.deltaTime;
			transform.Translate(dir);
		}
		currentWP ++;
	}
	
	protected override void Attack()
	{
		//do Attack animation
		//code for damage dealt and received goes here
	}

	public override void Die()
	{
		state = EntityState.DYING;
		Destroy (this.gameObject);
		//add code to give will back to persephone
	}
}