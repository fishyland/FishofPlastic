using UnityEngine;

public class PatrolState : State
{
  
  public PatrolState(Enemy enemy) : base(enemy) {}

  public override void FixedUpdate()
    {
        if(senses.IsAtWall() || senses.IsAtEdge())
        {
            Debug.Log("I found a wall");
            return; 
        }
      rb.linearVelocity = new Vector2(config.patrolSpeed, rb.linearVelocity.y);
    }
}
