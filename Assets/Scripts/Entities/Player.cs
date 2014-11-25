using UnityEngine;
using System.Collections;

public class Player : BaseUnit
{
    #region Persephone Base Stats
    private readonly int BASE_HEALTH = 100;
    private readonly float BASE_SPEED = 15f;//TODO design says 4 ft per second....how does that translate?
	private readonly int BASE_WILL = 15; //assuming skselton is learned at the start? may need to be 10
    private readonly float ATTACK_DELAY = 0.5f;
    private float LAST_ATTACK_TIME = 0f;
    #endregion

    public Vector3 HitPoint;

    Animator anims;
    // HACKY CODE AHEAD
    bool canAttack = false;

	MyInput input;


	void Start () {
		Reference.player = this;
		input = Reference.input;
		gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        anims = GetComponent<Animator>();
		moveSpeed = BASE_SPEED;
		CurHealth = BASE_HEALTH;
		MaxHealth = BASE_HEALTH;
		Will.modifyWill(BASE_WILL);

		//Minimap marker
		minimap = GameObject.FindGameObjectWithTag("MiniMap").transform;
		marker = Instantiate(Resources.Load("PlayerMark")) as GameObject;
		marker.transform.parent = minimap.transform;
		marker.GetComponent<PlayerMark>().player = gameObject;
	}

	// Update is called once per frame but we 
	void Update () 
    {
        Move();
        if (anims.GetFloat("WalkSpeed") == 0) canAttack = true;
        else canAttack = false;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
	}

	//players move command is passed an empty variable to avoid an error
    protected override void Move()
    {
		float h = input.GetAxis("Horizontal");
		float v = input.GetAxis("Vertical");
        anims.SetFloat("WalkSpeed", h * h + v * v);
		if(h == 0 && v == 0) {
			state = EntityState.IDLE;
		} else {
			state = EntityState.MOVING;
			Vector3 translate = new Vector3(h, v, 0);
            if (h < 0) transform.localScale = new Vector3(-1f, 1f, 1);
            else transform.localScale = new Vector3(1f, 1f, 1);
			translate = translate.normalized;
			transform.Translate(translate * moveSpeed * Time.deltaTime);
		}
	}
	
	protected override void Attack()
    {
        if (Time.time > LAST_ATTACK_TIME + ATTACK_DELAY)
        {
		    state = EntityState.ATTACKING;
            anims.SetTrigger("IsAttacking");
            Debug.Log(DamagePerAttack);
            LAST_ATTACK_TIME = Time.time;
        }
    }

    public void Hit()
    {
        Collider2D[] enemiesHit;
       
        Vector3 hitOffset = this.transform.TransformPoint(HitPoint);
        enemiesHit = Physics2D.OverlapCircleAll(hitOffset, 10f);
        foreach (Collider2D col in enemiesHit)
        {
           Enemy enemy = col.gameObject.GetComponent<Enemy>();
           if (enemy != null)
           {
               enemy.TakeDamage(DamagePerAttack);
           }
        }
    }

    public override void TakeDamage(int damage)
    {
    }

    public override void SetFacing(BaseUnit target)
    {

    }

    public override void Die()
    {
		state = EntityState.DYING;
		DestroyObject (marker);
    }

	//TODO specifiy which minions are currently learned?
	private void learnNewMinion(){
		Will.modifyWill(5);
	}

	public void Summon(string minion, int cost) {
		if(Will.useWill(cost))
			ObjectPool.instance.GetObjectForType(minion, false).transform.position = transform.position;
	}
}