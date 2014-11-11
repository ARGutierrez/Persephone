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

    int currentWP = 0;
    public float nextWaypointDistance = 3;

    // Use this for initialization
    void Start()
    {
        state = EntityState.IDLE;
        //set CurHealth and moveSpeed
		MaxHealth = BASE_HEALTH;
        CurHealth = BASE_HEALTH; //placeholder value
        moveSpeed = BASE_SPEED; // higher than player base speed
        followDistance = 4f;//gives distance skeleton is from persephone
        seeker = GetComponent<Seeker>();

		if (player == null)
			getPlayer();

    }

   /// <summary>
   /// This is the over all update method for the skeleton, contains the state machine and decision making.
   /// </summary>
    void Update()
    {
        //code for death
        if (CurHealth <= 0)
        {
            Die();
        }

        target = FindTarget();//finds the closest enemy target
        distFromPlayer = Vector3.Distance(player.transform.position, transform.position);
        if(path == null && target != null)
            path = seeker.StartPath(this.transform.position, target.transform.position);

        //the distance that persephone can be from skeleton before he moves to follow
        #region IdleState
        if (state == EntityState.IDLE)
        {
            // play idle animation

            //checks if target is not null
            if (target != null)
            {
                state = EntityState.ATTACKING;
            }
            else if (distFromPlayer > followDistance)
            {
                state = EntityState.MOVING;
            }
        }
        #endregion 
        
        #region MovingState
        else if (state == EntityState.MOVING)
        {
            //move to persephone
			Move(target, path);
            //checks if target is not null
            if (target != null)
            {
                state = EntityState.ATTACKING;
            }
            else if (distFromPlayer <= followDistance)
            {
                state = EntityState.IDLE;
            }
        }
        #endregion

        #region AttackingState
        else if (state == EntityState.ATTACKING)
        {
			if(target != null){
				float distFromTarget = Vector3.Distance(target.transform.position, transform.position); ;
            	if (distFromTarget <= ATTACK_RANGE)
            	{
               		Attack(target);
					if (target.CurHealth <= 0)
					{//CurHealthOfTarget <= 0
						target = FindTarget();//finds the closest enemy target
						if (target != null)
						{
							state = EntityState.ATTACKING;
						}
						else
						{
							state = EntityState.MOVING;
							Move(player);
						}
					}
            	}
            	else
            	{
               		Move(target, path);
            	}
        	}
			else
				state = EntityState.IDLE;
		}
        #endregion
    }

    protected override void Move(BaseUnit target)
    {
        throw new System.NotImplementedException();
    }

    // TODO: MAKE THIS THING MOVE
    protected void Move(BaseUnit targetUnit, Path path)
    {
        //transform.position = Vector3.MoveTowards(transform.position, targetUnit.transform.position, moveSpeed * Time.deltaTime);
        //Direction to the next waypoint
        // Vector3 dir = (path.vectorPath[currentWP] - transform.position).normalized;
        // dir *= 5f * Time.fixedDeltaTime;
        transform.position = Vector3.MoveTowards(transform.position, path.vectorPath[currentWP], moveSpeed * Time.deltaTime);

        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector3.Distance(transform.position, path.vectorPath[currentWP]) < nextWaypointDistance)
        {
            currentWP++;
            return;
        }
    }

    protected override void Attack(BaseUnit enemy)
    {
        //do Attack animation
        //code for damage dealt and received goes here
		enemy.CurHealth = enemy.CurHealth - DAMAGE_PER_ATTACK;
    }

    protected override void Die()
    {
        state = EntityState.DYING;
        Destroy(this.gameObject);
        //add code to give will back to persephone
		(player).CurWill += WILL_COST;
    }
}