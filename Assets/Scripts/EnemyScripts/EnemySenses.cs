using UnityEngine;

public class EnemySenses : MonoBehaviour
{
[SerializeField] private EnemyConfig config;
[SerializeField] private Transform groundCheck;
[SerializeField] private Transform wallCheck;

public bool IsAtEdge()
    {
        return !Physics2D.Raycast(groundCheck.position, Vector2.down, config.groundCheckDistance, config.groundLayer);
    }

public bool IsAtWall()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.down, config.wallCheckDistance, config.wallLayer);
    }
}
