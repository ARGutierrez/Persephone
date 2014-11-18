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
    public EntityState state;
    #endregion

//	variable declarations
	protected int maxHealth;
	protected int curHealth;
	protected string myName;
	//protected Weapon myWeapon;
	protected GameObject myCharacter;

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

	#region Unit Methods
	//move method now moves unit toward a particular unit
	protected abstract void Move();
	protected abstract void Attack();
	public abstract void Die();
/*	protected abstract void Die(){
		Character.SetActive (false);
	}
*/
    #endregion

    // Use this for initialization
	void Start () {
	//	this method should be overwritten in children to set things correctly. This is just dummy data
		MaxHealth = 20;
		CurHealth = 20;
		MyName = "Base Unit";
		Character = new GameObject(MyName);
		Character.AddComponent("Animator");
		Character.AddComponent("BoxCollider2D");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
