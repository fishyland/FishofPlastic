using UnityEngine;

public class EnemySenses : MonoBehaviour
{
[SerializeField] private Enemy enemy;
[SerializeField] private EnemyConfig config;
[SerializeField] private Transform wallCheck;

public bool IsAtWall()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.down, config.wallCheckDistance, config.wallLayer);
    }

/*private void OnDrawGizmosSelected()
    {
        Gizmos.colour = colour.yellow;
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + Vector3.right * enemy.FacingDirection * config.wallCheckDistance);
    } */
}
