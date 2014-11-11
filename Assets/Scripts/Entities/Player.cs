using UnityEngine;
using System.Collections;

public class Player : BaseUnit
{
    #region Persephone Base Stats
    private readonly int BASE_HEALTH = 100;
    private readonly float BASE_SPEED = 15f;//TODO design says 4 ft per second....how does that translate?
	private readonly int BASE_WILL = 15; //assuming skselton is learned at the start? may need to be 10
    #endregion

	//variables
	MyInput input;
	protected int maxWill;
	protected int curWill;

	public int MaxWill{
		get { return maxWill; } 
		set { maxWill = value;} 
	}
	public int CurWill{
		get { return curWill; } 
		set {	
			if(value > maxWill)
				curWill = maxWill;
			else
				curWill = value;
		} 
	}

	void Start () {
		gameObject.GetComponent<SpriteRenderer>().sprite = sprite; 
		input = Reference.input;
        moveSpeed = BASE_SPEED;
		CurHealth = BASE_HEALTH;
		MaxHealth = BASE_HEALTH;
		CurWill = BASE_WILL;
		MaxWill = BASE_WILL;
	}
	
	// Update is called once per frame but we 
	//convert it to seconds because of Time.deltaTime
	void Update () 
    {
		//passes an empty value for the move function, player does not move towards a unit
        Move(null);
		//code for minion summoning
		//checks if 1 is down on alpha numbers or on numpad
		/*if (Input.GetKeyDown(KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.Keypad7))
		{
			//create skeleton at mouse pointer
			if(Input.GetMouseButtonDown(0))//checks if left mouse button is clicked
			{
				//add code to subtract will from persephone
			
				Instantiate(Skeleton, Input.mousePosition, Quaternion.identity);//need to spawn in proper location
			}
		}*/
	}
	//players move command is passed an empty variable to avoid an error
    protected override void Move(BaseUnit none)
    {
		state = EntityState.MOVING;
        float h = input.GetAxis("Horizontal");
        float v = input.GetAxis("Vertical");
        Vector3 translate = new Vector3(h, v, 0);
        translate = translate.normalized;

        transform.Translate(translate * moveSpeed * Time.deltaTime);
    }

    protected override void Attack(BaseUnit target)
    {
		state = EntityState.ATTACKING;
    }
    protected override void Die()
    {
		state = EntityState.DYING;
    }

	//TODO specifiy which minions are currently learned?
	private void learnNewMinion(){
		MaxWill += 5;
		CurWill += 5;
	}

	private void summonSkeleton(){
		if (CurWill >= 3) {
			//TODO spawn a skeleton
			CurWill -= 3;
		}
	}

}