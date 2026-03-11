using UnityEngine;

public class ChaseState : State
{

    private Transform target;
    protected override string AnimBoolName => "isRunning";
    public ChaseState(Enemy enemy) : base(enemy){}

    public override void FixedUpdate()
    {
        //1. Check for a target
        target = senses.GetChaseTarget();

        if(!target)
        {
            stateMachine.ChangeState(new PatrolState(enemy));
            return;
        }
        enemy.FaceTarget(target);

        //2. check if we can attack
        if(senses.IsInMeLeeRange(target))
        {
            stateMachine.ChangeState(new MeleeAttackState(enemy));
            return;
        }

        //3. Check if we've reached target
        float distance = Mathf.Abs(target.position.x - enemy.transform.position.x);
        if(distance <= config.turnThreshold)
        {
            stateMachine.ChangeState(new IdleState(enemy));
            return;
        }

        //Check for obstacles
        if(senses.IsAtWall())
        {
            stateMachine.ChangeState(new IdleState(enemy));
            return;
        }

        //Move toward target
        rb.linearVelocity = new Vector2(config.chaseSpeed * enemy.FacingDirection, rb.linearVelocity.y);
    }

    public override void Exit()
    {
        base.Exit();
        rb.linearVelocity = Vector2.zero;
    }

}
