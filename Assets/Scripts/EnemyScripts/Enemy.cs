using UnityEngine;

public class Enemy: MonoBehaviour
{
   
    public Rigidbody2D RB {get; private set;}
    public StateMachine StateMachine{get; private set;}
    public EnemyConfig Config;
    public EnemySenses Senses {get; private set;}


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        StateMachine = new StateMachine();
        Senses = GetComponent<EnemySenses>();
    }

    public void Start()
    {
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
}
