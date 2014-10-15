using UnityEngine;
using System.Collections;

public class GenericEnemy : BaseUnit 
{
	
	// Use this for initialization
	void Start () 
	{
		state = EntityState.IDLE;
		//GameObject player = GameObject.Find("Player");
		player = GameObject.Find("Player");
		//set health and moveSpeed
		health = 30; //placeholder value
		moveSpeed = 15f; // higher than player base speed so you can't run

		
	}
	
	// Update is called once per frame
	void Update () 
	{
        // code for death
        if (health <= 0)
        {
            Die();
        }

		Move();

		float distFromPlayer = Vector3.Distance(player.transform.position, transform.position);
		float aggroRange = 20f;//distance which the player or a minion must be under to trigger an attack
		//finds all objects with tag Minion and assigns them to a group
		GameObject[] minions = GameObject.FindGameObjectsWithTag("Minion");
		//iterates through array of enemies
		float closestMinionDist = 21; //max distance of generic enemy is 20 feet
		float currentMinionDist = 21;//tracks the distance of target object 
		GameObject closestMinionObj = null;//tracks closest minion object
		foreach(GameObject target in minions) 
		{
			currentMinionDist = Vector3.Distance(target.transform.position, transform.position);
			if (currentMinionDist < closestMinionDist)
			{
				closestMinionDist = currentMinionDist;
				closestMinionObj = target;
			}
			
		}
	///////////////////////////////////////////////////this is broken!!!!!
		//checks if closest minion is within range, if so attack
		if (closestMinionDist <= aggroRange && state != EntityState.ATTACKING) 
		{
			Debug.Log (distFromPlayer+"if");
			Attack(closestMinionObj, closestMinionDist);
		}

		else if(distFromPlayer <= aggroRange && state != EntityState.ATTACKING )
		{
			Debug.Log (distFromPlayer+"else");
			Attack (player, distFromPlayer);
		}

	}
	
	protected override void Move()
	{
		if(state != EntityState.ATTACKING)
		{
			state = EntityState.IDLE;
		}
		
	}
	
	protected override void Attack(GameObject target, float distanceToTarget)
	{
		Debug.Log(distanceToTarget);
		state = EntityState.ATTACKING;
		float attackRange = 4f; 
        /*
		while(distanceToTarget > attackRange)
		{
			Debug.Log("Enemy Moving to Attack");
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed*Time.deltaTime);
		}

		while(health > 0 && distanceToTarget <= attackRange)
		{
			//do attack animation
			Debug.Log("Attacking target");

		}
         */
	//code for death
		//code for damage dealt and received goes here
	}
	protected override void Die()
	{
		state = EntityState.DYING;
		//Destroy (GenericEnemy);
	}
}