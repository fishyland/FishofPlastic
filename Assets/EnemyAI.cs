using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour, IDamageable
{
    [Header("Stats")] //isn't required but makes it neater, connects them
    [SerializeField] private float maxHealth = 50f; //can see in inspector but only works in this script
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private float damageAmount = 10f;

    [Header("Patrol Bounds")]
    [SerializeField] private Transform leftBound; //transform is its position, rotation and scale
    [SerializeField] private Transform rightBound;
    //sets up position for right and left side most it can go

    private float currentHealth;
    private float attackTimer = 0f;
    private Transform player;
    private bool isMovingRight = true;
    private Rigidbody2D rb;
    // won't be seen in UI so don't need headers    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        //capitals refer to script, lowercase for variable
        //get playerhealth script then find variable called playerhealth
        if (playerHealth != null)
        {
            player = playerHealth.transform;
            //player health will become whatever the transform is
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0) return;
        attackTimer -= Time.deltaTime; //counts down from whatever the framerate is
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            //vector2 is a line moving in one direction, the players position
            //me to where the player is line
            if (distanceToPlayer <= detectionRange)
            {
                ChasePlayer(distanceToPlayer);
            }
            else
            {
                Patrol();
            }
        }
        else
        {
            Patrol();
        }
    }
    private void ChasePlayer(float distanceToPlayer)
    {
        if (distanceToPlayer <= attackRange)
        {
            IDamageable playerDamageable = player.GetComponent<IDamageable>();
            if (playerDamageable!= null && attackTimer <= 0f)
            {
                playerDamageable.ApplyDamage(damageAmount);
                attackTimer = attackCooldown;
            }
            rb.linearVelocity = new Vector2(0f,rb.linearVelocity.y); //stop moving when attacking player
        }
        else
        {
            float direction = player.position.x>transform.position.x ? 1f: -1f;
            //? fancy way of doing if else, only if it needs one or the other
            Move(direction);
        }
    }
    private void Patrol()
    {
        if(leftBound != null && rightBound != null) //if we dont define shdfdsf it will still work
        {
            if(isMovingRight && transform.position.x >= rightBound.position.x)
            isMovingRight = false;
            else if(!isMovingRight && transform.position.x <= leftBound.position.x)
            isMovingRight = true;
        }
        Move(isMovingRight ? 1f: -1f);
    }
    private void Move(float direction)
    {
        if(rb != null)
        {
            rb.linearVelocity = new Vector2(direction *moveSpeed, rb.linearVelocity.y);
        }
        if(direction != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(direction), 1f,1f);
        }
    }
    public bool ApplyDamage(float damage)
    {
        if(currentHealth<=0f) return false;
        currentHealth -= damage;
        if(currentHealth <= 0f)
        {
            Die();
            return true;
        }
        return true;
    }
    private void Die()
    {
        rb.linearVelocity = Vector2.zero;
        gameObject.SetActive(false);
    }
}

