using UnityEngine;
using System.Collections;

public class PhantomWarrior : BaseUnit {
	
	// Use this for initialization
	void Start () {
		state = EntityState.IDLE;
		player = GameObject.Find("Player");
		//set health and moveSpeed
		health = 30; //placeholder value
		moveSpeed = 15f; // faster than player base speed

		
	}
	
	// Update is called once per frame
	void Update () {
		
		Move();
		//code for death
		if(health <= 0)
		{
			Die();
		}
		
		//finds all objects with tag Enemy and assigns them to a group
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float aggroRange = 17f;//PhantomWarrior will try to attack enemies at 16 feet
		//iterates through array of enemies
		float closestEnemyDist = 17; //max distance of PhantomWarrior is 16 feet
		float currentEnemyDist = 17;//tracks the distance of target object 
		GameObject closestEnemyObj = null;//tracks closest enemy object
		foreach(GameObject target in enemies) 
		{
			currentEnemyDist = Vector3.Distance(target.transform.position, transform.position);
			if (currentEnemyDist < closestEnemyDist)
			{
				closestEnemyDist = currentEnemyDist;
				closestEnemyObj = target;
			}
			
		}
		//checks if closest enemy is within range, if so attack
		if (closestEnemyDist < aggroRange && state != EntityState.ATTACKING) 
		{
			Attack(closestEnemyObj, closestEnemyDist);
		}
		
		
		
	}
	
	protected override void Move()
	{
		//gives distance skeleton is from persephone
		float distFromPlayer = Vector3.Distance(player.transform.position, transform.position);
		//the distance that persephone can be from skeleton before he moves to follow
		float followDistance = 4f;
		if (distFromPlayer >= followDistance && state == EntityState.IDLE)
		{
			state = EntityState.MOVING;
			//follow player
			
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed *Time.deltaTime );
		}
		else if(distFromPlayer > followDistance && (state != EntityState.ATTACKING || state != EntityState.DYING))
		{
			state = EntityState.IDLE;
		}
	}
	
	protected override void Attack(GameObject enemy, float enemyDist)
	{
		state = EntityState.ATTACKING;
		float attackRange = 16f; //max attack range for PhantomWarrior
		while(enemyDist > attackRange)
		{
			//PhantomWarrior can teleport, so movement sets position rather than moving towards
			//currenty,PhantomWarrior spawns on top of enemy. Will need fixing 
			transform.position = enemy.transform.position;
		}
		//code for damage dealt and received goes here
		
		
		
		
	}
	protected override void Die()
	{
		state = EntityState.DYING;
		//Destroy (PhantomWarrior);
		//add code to give will back to persephone
		
	}
}


