using UnityEngine;

public abstract class State //cant create this in the game, but other scripts can inherit its logic
{
public Rigidbody2D rb;
protected EnemyConfig config;
protected EnemySenses senses;

protected State(Enemy enemy)//not accessible to other classes, gets called each time we create new class
    {
        rb = enemy.RB;
        config = enemy.Config;
        senses = enemy.Senses;
    }

public virtual void Enter(){} //default logic (for all states)/states can override this method, doing whatever specific logic they need
public virtual void Update(){}
public virtual void FixedUpdate(){}
public virtual void Exit (){}

//need to be passed into the other states
}
