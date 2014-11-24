using UnityEngine;
using System.Collections;
using Pathfinding;

public abstract class Minion : BaseUnit
{
	protected float distFromTarget;
	protected float followDistance; //the distance that persephone can be from skeleton before he moves to follow
	protected float attackRange;
	protected float aggroRange;
	protected BaseUnit target;
	protected Player player;

	protected Seeker seeker;
	protected Path path;
	public float repathRate = 1f;
	public float lastRepath = 0;
	public int currentWP = 0;
	public float nextWaypointDistance = 3;


	protected Player getPlayer() {
		if (Reference.player != null) {
			player = Reference.player;
			return Reference.player;
		} else
			return null;
	}
	
	
	protected BaseUnit FindTarget()
	{
		//finds all objects with tag Enemy and assigns them to a group
		GameObject[] minions = GameObject.FindGameObjectsWithTag("Enemy");
		
		//iterates through array of enemies
		float closestDist = aggroRange;
		GameObject closestEnemyObj = null;//tracks closest enemy object
		foreach(GameObject target in minions)
		{
			distFromTarget = Vector3.Distance(target.transform.position, transform.position);
			if (distFromTarget < closestDist) {
				closestDist = distFromTarget;
				closestEnemyObj = target;
			}
		}
		if(closestEnemyObj != null)
			return closestEnemyObj.GetComponent<BaseUnit>();
		else
			return null;
	}

	public void OnPathComplete (Path p) {
		p.Claim (this);
		if (!p.error) {
			if (path != null) path.Release (this);
			path = p;
		} else {
			p.Release (this);
			Debug.Log ("Oh noes, the target was not reachable: " + p.errorLog);
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

    public override void TakeDamage(int damage)
    {
        curHealth = Mathf.Clamp(curHealth - damage, 0, MaxHealth);
        if (curHealth == 0)
            Die();
    }

    public override void SetFacing(BaseUnit target)
    {
        if ((this.transform.position.x - target.transform.position.x) < 0)
            this.transform.localScale = new Vector3(1, 1, 1);
        else
            this.transform.localScale = new Vector3(-1, 1, 1);
    }
}