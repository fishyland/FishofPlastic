using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerHealth : MonoBehaviour, IDamageable
{
   [SerializeField] float maxHealth = 100f;
   [SerializeField] float invulnerabilityDuration = 1f;
   [SerializeField] float  blinkInterval = 0.1f;

    /*private EnemyConfig config;
    private Enemy enemy;*/
    public float currentHealth;
    public float invulnerabilityTimer;
    private SpriteRenderer sprite;
    private float blinkTimer;
    private bool blinking;

    /*private void Start()
    {
        enemy = GetComponent<Enemy>();
        config = enemy.Config;
    } */

    void Awake()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
      
    }

    void Update()
    {
        if(invulnerabilityTimer >0f)
        {
            invulnerabilityTimer-=Time.deltaTime;
            HandleBlink();
        }
    }
    public bool ApplyDamage(float meleeDamage)
    {
        if(currentHealth <=0f || invulnerabilityTimer > 0f)
        return false;

        currentHealth -= meleeDamage;

        if(currentHealth <= 0f)
        {
            Die();
            return true;
        }
        invulnerabilityTimer = invulnerabilityDuration;
        StartBlink(invulnerabilityDuration);
        return true;
    }
    void StartBlink(float duration)
    {
        blinking = true;
        blinkTimer = duration;
    }
    void HandleBlink()
    {
        if(!blinking) return;
        blinkTimer -= Time.deltaTime;
        if(blinkTimer <=0f)
        {
            blinking = false;
            sprite.enabled = true;
            return;
        }
        sprite.enabled =
        Mathf.FloorToInt(blinkTimer/blinkInterval) % 2 == 0;
    }
    void Die()
    {
        gameObject.SetActive(false);
    }
    
}

