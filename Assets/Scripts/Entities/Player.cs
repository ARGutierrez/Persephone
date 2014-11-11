using UnityEngine;
using System.Collections;

public class Player : BaseUnit
{
    #region Persephone Base Stats
    private readonly int BASE_HEALTH = 100;
    private readonly float BASE_SPEED = 15f;//TODO design says 4 ft per second....how does that translate?
	private readonly int BASE_WILL = 15; //assuming skselton is learned at the start? may need to be 10
    #endregion

	void Start () {
		Reference.player = this;
		input = Reference.input;
		gameObject.GetComponent<SpriteRenderer>().sprite = sprite; 
		moveSpeed = BASE_SPEED;
		CurHealth = BASE_HEALTH;
		MaxHealth = BASE_HEALTH;
		CurWill = BASE_WILL;
		MaxWill = BASE_WILL;
	}
	
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

	// Update is called once per frame but we 
	void Update () 
    {
        Move(null);
	}

	//players move command is passed an empty variable to avoid an error
    protected override void Move(BaseUnit none)
    {
		float h = input.GetAxis("Horizontal");
		float v = input.GetAxis("Vertical");
		if(h == 0 && v == 0) {
			state = EntityState.IDLE;
		} else {
			state = EntityState.MOVING;
			Vector3 translate = new Vector3(h, v, 0);
			translate = translate.normalized;
			transform.Translate(translate * moveSpeed * Time.deltaTime);
		}
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