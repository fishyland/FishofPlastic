using UnityEngine;

public class Enemy: MonoBehaviour
{
    //Variables
    public int FacingDirection{get; private set;} = 1; //when setting in scale to 1, will face right, -1, left
    public Health health;

   //Components
    public Rigidbody2D RB {get; private set;}
    public StateMachine StateMachine{get; private set;}
    public EnemyConfig Config;
    public EnemySenses Senses {get; private set;}
    public EnemyCombat Combat {get; private set;}
    public Animator Animator {get; private set;}
    private Vector2 direction;
    //public Health health;
    public Animator anim;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        StateMachine = new StateMachine();
        Senses = GetComponent<EnemySenses>();
        Combat = GetComponent<EnemyCombat>();
        Animator = GetComponent<Animator>();
    }

    public void Start()
    {
        Config.health = Config.maxHealth;
       StateMachine.Initialize(new PatrolState(this)); 
    }
    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentState?.Update();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState?.FixedUpdate();
    }

    public void FaceTarget(Transform target)
    {
        float offset = target.position.x - transform.position.x;

        int direction = offset > 0 ? 1 : -1;
        if(direction != FacingDirection)
        Flip();
    }
    public void Flip()
    {

       /* if(direction != Vector2.zero)
        {
            animator.SetFloat("XInput", direction.x);
            animator.SetFloat("YInput", direction.y);
        } */
        FacingDirection *= -1;

        Vector3 scale = transform.localScale;
        scale.x = FacingDirection;
        transform.localScale = scale;
    }

    private void OnEnable()
    {
        health.OnDamaged += HandleDamage;
    }


    private void OnDisable()
    {
        health.OnDamaged -= HandleDamage;
    }

    void HandleDamage()
    {
        anim.SetTrigger("isDamaged");
    }

}


