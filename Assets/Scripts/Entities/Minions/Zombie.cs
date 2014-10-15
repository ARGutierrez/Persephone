using UnityEngine;
using System.Collections;

public class Zombie : BaseUnit {
	
	// Use this for initialization
	void Start () {
		state = EntityState.IDLE;
		player = GameObject.Find("Player");
		//set health and moveSpeed
		health = 100; //placeholder value
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
		float aggroRange = 21f;//Zombie will try to attack enemies at 20 feet
		//iterates through array of enemies
		float closestEnemyDist = 21; //max distance of zombie is 20 feet
		float currentEnemyDist = 21;//tracks the distance of target object 
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
		//gives distance zombie is from persephone
		float distFromPlayer = Vector3.Distance(player.transform.position, transform.position);
		//the distance that persephone can be from skeleton before he moves to follow
		float followDistance = 4f;
		if (distFromPlayer >= followDistance && state == EntityState.IDLE)
		{
			state = EntityState.MOVING;
			//follow player
			
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed*Time.deltaTime );
		}
		else if(distFromPlayer > followDistance && (state != EntityState.ATTACKING || state != EntityState.DYING))
		{
			state = EntityState.IDLE;
		}
	}
	
	protected override void Attack(GameObject enemy, float enemyDist)
	{
		state = EntityState.ATTACKING;
		float attackRange = 6f;///attack range of zombie 
		while(enemyDist > attackRange)
		{
			transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, moveSpeed*Time.deltaTime);
		}
		//code for damage dealt and received goes here
		
		
		
		
	}
	protected override void Die()
	{
		state = EntityState.DYING;
		//Destroy (Zombie);
		//add code to give will back to persephone
		
	}
}

