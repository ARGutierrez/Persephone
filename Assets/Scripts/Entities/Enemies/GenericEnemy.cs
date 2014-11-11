using UnityEngine;
using System.Collections;

public class GenericEnemy : BaseUnit 
{
	Player player;
	// Use this for initialization
	void Start () 
	{
		state = EntityState.IDLE;
		//Finds player GameObject, sets BaseUnit player to that Object
		GameObject playerObj = GameObject.Find("Player");
		if (playerObj != null)
		{
			player = (Player) playerObj.GetComponent<BaseUnit>();
		}

		//set health and moveSpeed
		curHealth = 30; //placeholder value
		moveSpeed = 15f; // higher than player base speed so you can't run

		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//code for death
		if (curHealth <= 0) {
			Die ();
		}
		BaseUnit target = FindTarget ();//finds the closest enemy target


		//gives distance enemy is from persephone
		float distFromPlayer = Vector3.Distance (player.transform.position, transform.position);
		float attackRange = 4f; 
		float aggroRange = 20f;//Enemy will try to attack enemies at 20 feet
		if (state == EntityState.IDLE) {
			
			// play idle animation
			
			//checks if target is not null

			if (target != null) 
			{
				state = EntityState.ATTACKING;
			}
			else if (distFromPlayer <= aggroRange) 
			{
				state = EntityState.ATTACKING;
				target =  player;
			} 
		}

		if (state == EntityState.ATTACKING && target != null) 
		{
			//gives distance minion is from enemy
			float distFromTarget = Vector3.Distance (target.transform.position, transform.position);
			if (distFromTarget <= attackRange) {
				Attack (target);
			} else {
				Move (target);
			}
			
			if (target.CurHealth <= 0) {
				target = FindTarget ();//finds the closest enemy target

				if (distFromPlayer <= aggroRange) 
				{
					state = EntityState.ATTACKING;
					target = player;
				} 
				else if (target != null) 
				{
					state = EntityState.ATTACKING;
				}
			}
			
		}
	
	}
	// this method checks the enemy's surroundings and finds the closest minion
	protected BaseUnit FindTarget()
	{
		//finds all objects with tag Minion and assigns them to a group
		GameObject[] minions = GameObject.FindGameObjectsWithTag("Minion");

		//iterates through array of enemies
		float closestMinionDist = 21; //max distance of GenericEnemy is 20 feet
		float currentMinionDist = 21;//tracks the distance of target object 
		GameObject closestMinionObj = null;//tracks closest enemy object
		BaseUnit chosenTarget = null;
		foreach(GameObject targetMin in minions)
		{
			currentMinionDist = Vector3.Distance(targetMin.transform.position, transform.position);
			if (currentMinionDist < closestMinionDist)
			{
				closestMinionDist = currentMinionDist;
				closestMinionObj = targetMin;
			}
			
		}
		if (closestMinionObj != null)
		{
			chosenTarget = closestMinionObj.GetComponent<BaseUnit>();
		}

		return chosenTarget;
		
	}
	protected override void Move(BaseUnit targetUnit)
	{
		transform.position = Vector3.MoveTowards (transform.position, targetUnit.transform.position, moveSpeed * Time.deltaTime);
		
	}
	
	protected override void Attack(BaseUnit minion)
	{
		//do Attack animation
		//code for damage dealt and received goes here

	}
	protected override void Die()
	{
		state = EntityState.DYING;
		Destroy (this.gameObject);
	}
}