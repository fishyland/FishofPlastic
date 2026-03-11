using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;

    private EnemyConfig config;
    private Enemy enemy;

private void Start()
    {
        enemy = GetComponent<Enemy>();
        config = enemy.Config;
    }

public void PerformMeleeAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, config.meleeRange,config.targetLayer);
        if(!hit)
        return;
        PlayerHealth health = GetComponent<PlayerHealth>();
        if(health != null)
        health.ApplyDamage(config.meleeDamage);
    }

}
