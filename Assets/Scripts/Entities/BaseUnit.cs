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
    public float health;
    public float moveSpeed;
	public GameObject player;
    public EntityState state;
    #endregion

//	enumeration for moving 8 directions. Start at 1, move around compass clockwise
//	TODO this may or may not be useful so for now It's commented out
//	enum Direction : int {N=1, NE=2, E=3, SE=4, S=5, SW=6, W=7, NW=8};

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
        set { curHealth = value;} 
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
	protected abstract void Move();
//	TODO protected abstract void Move(int direction, float speed);
	protected abstract void Attack(GameObject target, float distanceToTarget);
	protected abstract void Die();
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
