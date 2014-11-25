//TODO WEAPON CURRENTLY COMMENTED OUT
//TODO methods are currently abstract, therefore you cannot specify a body as they are in this class.
//	   Also Cannot change move because all base classes are overriding the original method.
//	   Not necessarily difficult fixes but need to know what's expected
using UnityEngine;
using System.Collections;

public abstract class BaseUnit : MonoBehaviour
{

    #region Unit Properties
    public Sprite sprite;
    //public float health;
    public float moveSpeed;
    public int DamagePerAttack;
    public EntityState state;
    #endregion

//	variable declarations
	protected int maxHealth;
	public int curHealth;
	protected string myName;
	//protected Weapon myWeapon;
	protected GameObject myCharacter;

	//MiniMap
	protected GameObject marker;
	protected Transform minimap;

//  properties for accessing the variables publicly
	public int MaxHealth { 
		get { return maxHealth; } 
        set { maxHealth = value;} 
	}
    public int CurHealth {
		get { return curHealth; }
        set { 
			if(value > maxHealth)
				curHealth = maxHealth;			
			else
				curHealth = value;
		} 
	}
    public string MyName{
		get { return myName; }
		set { myName = value;} 
	}
/*	public Weapon MyWeapon {
		get { return myWeapon; }
		set { myWeapon = value;}
	}
*/
	public GameObject Character {
		get { return myCharacter; }
		set { myCharacter = value;}
	}

	public void TakeDamage(int damage)
	{
		curHealth = Mathf.Clamp(curHealth - damage, 0, MaxHealth);
		if (curHealth == 0)
			Die();
	}

	#region Unit Methods
	protected abstract void Move();
	protected abstract void Attack();
	public abstract void Die();
    public abstract void SetFacing(BaseUnit target);
    #endregion
}