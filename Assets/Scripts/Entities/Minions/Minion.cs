using UnityEngine;
using System.Collections;
using Pathfinding;

public abstract class Minion : BaseUnit
{
	protected float distFromTarget;
	//the distance that persephone can be from skeleton before he moves to follow
	protected float followDistance;
	protected float attackRange;
	protected BaseUnit target;
	protected Seeker seeker;
	protected Path path;
	public float repathRate = 1f;
	public float lastRepath = 0;
	public int currentWP = 0;
	protected Player player;

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
		float agroRange = 20; //Distance at which a minion will start attacking.
		GameObject closestEnemyObj = null;//tracks closest enemy object
		BaseUnit chosenTarget = null;
		foreach(GameObject target in minions)
		{
			distFromTarget = Vector3.Distance(target.transform.position, transform.position);
			if (distFromTarget < agroRange) {
				agroRange = distFromTarget;
				closestEnemyObj = target;
			}
			
		}
		if(closestEnemyObj != null)
		{
			chosenTarget = closestEnemyObj.GetComponent<BaseUnit>();
		}
		return chosenTarget;
	}

	public void OnPathComplete (Path p) {
		p.Claim (this);
		if (!p.error) {
			if (path != null) path.Release (this);
			path = p;
		} else {
			p.Release (this);
			Debug.Log ("Oh noes, the target was not reachable: "+p.errorLog);
		}
	}
}