using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;

    private EnemyConfig config;
    public Collider2D hit;
    private Enemy enemy;
    //private PlayerHealth currentHealth;
    private float lastAttackTime;

private void Start()
    {
        enemy = GetComponent<Enemy>();
        config = enemy.Config;
        hit = GetComponent<BoxCollider2D>();
       // currentHealth = GetComponent<PlayerHealth>();
    }

    public bool CanMeleeAttack() => Time.time >= lastAttackTime + config.meleeCooldown;

public void PerformMeleeAttack()
    {
        lastAttackTime = Time.time;

        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, config.meleeRange,config.targetLayer);
        if(!hit)
        return;

        PlayerHealth currentHealth = hit.GetComponent<PlayerHealth>();

        if(currentHealth != null)
        currentHealth.ApplyDamage(-config.meleeDamage);
    }
    
}
