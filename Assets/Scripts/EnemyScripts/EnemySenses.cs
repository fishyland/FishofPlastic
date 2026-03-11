using UnityEngine;

public class EnemySenses : MonoBehaviour
{
[SerializeField] private Enemy enemy;
[SerializeField] private EnemyConfig config;
[SerializeField] private Transform wallCheck;
[SerializeField] private Transform attackPoint;

public bool IsAtWall()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.down, config.wallCheckDistance, config.wallLayer);
    }

    public Transform GetChaseTarget()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, config.chaseRange,config.targetLayer);
        if(!hit)
        return null;

        return hit.transform;
    }
    public bool IsInMeLeeRange(Transform target)
    {
        if(!target)
        return false;

        float distance = Vector2.Distance(target.position,attackPoint.position);
        return distance <= config.meleeRange;
    }

private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position,config.chaseRange);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(attackPoint.position, config.meleeRange);

    }


    
/*
    {
        Gizmos.colour = colour.yellow;
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + Vector3.right * enemy.FacingDirection * config.wallCheckDistance);
    } */
}
