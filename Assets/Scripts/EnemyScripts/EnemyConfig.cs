using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyConfig")] //menu in unity, can make many scriptable objects

public class EnemyConfig : ScriptableObject //data container script
{
    [Header("Movement")]

    public float patrolSpeed = 5;

    [Header("Patrol")]
    public float groundCheckDistance = .7f;
     public float wallCheckDistance = .5f;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
}
