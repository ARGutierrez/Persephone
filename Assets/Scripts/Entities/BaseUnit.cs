using UnityEngine;
using System.Collections;

public abstract class BaseUnit : MonoBehaviour
{

    #region Unit Properties
    public Sprite sprite;
    public float health;
    public float moveSpeed;
	public GameObject player;
    public EntityState state;
    #endregion

	int maxHealth;
	int curHealth;
    protected int MaxHealth {   get { return maxHealth; } 
                                set { maxHealth = value;} }
    protected int CurHealth {   get { return curHealth; }
                                set { curHealth = value;} }
    


    #region Unit Methods
    protected abstract void Move();
    protected abstract void Attack(GameObject target, float distanceToTarget);
    protected abstract void Die();
    #endregion

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
