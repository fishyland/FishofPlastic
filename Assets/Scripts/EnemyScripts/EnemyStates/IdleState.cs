using UnityEngine;

public class IdleState : State
{

    private Transform target;
    protected override string AnimBoolName => "isIdling";
    public IdleState(Enemy enemy) : base(enemy){}


    public override void Enter()
    {
        base.Enter();
        rb.linearVelocity = Vector2.zero;
    }

    public override void FixedUpdate()
    {
        //1. check for target
        target = senses.GetChaseTarget();

        if(!target)
        {
            stateMachine.ChangeState(new PatrolState(enemy));
            return;
        }
        enemy.FaceTarget(target);
        //check if we have reached target
        
        float distance = Mathf.Abs(target.position.x - enemy.transform.position.x);
        if(distance <= config.turnThreshold)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        //Check for obstacles
        if(senses.IsAtWall())
        {
            stateMachine.ChangeState(new IdleState(enemy));
            return;
        }

        if(senses.IsAtWall())
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
      //4. we HAVE target, we have NOT reached it, there are NO obstacles
       stateMachine.ChangeState(new ChaseState(enemy));

}
}
