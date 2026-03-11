using UnityEngine;

public abstract class State //cant create this in the game, but other scripts can inherit its logic
{
public Rigidbody2D rb;
protected Animator animator;
protected virtual string AnimBoolName => null;
protected EnemyConfig config;
protected EnemySenses senses;
protected StateMachine stateMachine;
protected Enemy enemy;

protected State(Enemy enemy)//not accessible to other classes, gets called each time we create new class
    {
        rb = enemy.RB;
        animator = enemy.Animator;
        config = enemy.Config;
        senses = enemy.Senses;
        stateMachine = enemy.StateMachine;
        this.enemy = enemy;
    }

public virtual void Enter() //default logic (for all states)/states can override this method, doing whatever specific logic they need
    {
        if(!string.IsNullOrEmpty(AnimBoolName))
        animator.SetBool(AnimBoolName,true);
    }

public virtual void Update(){}
public virtual void FixedUpdate(){}
public virtual void Exit ()
    {
        if(!string.IsNullOrEmpty(AnimBoolName))
        animator.SetBool(AnimBoolName,false);
    }

//need to be passed into the other states
}
