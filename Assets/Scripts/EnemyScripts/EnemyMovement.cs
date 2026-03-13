using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    Transform player;
    Vector2 moveDirection;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
    {
        if(player)
        {
            Vector3 direction = (player.position - player.position).normalized;
            moveDirection = direction;
        }
    }
}
private void FixedUpdate()
    {
        if(player)
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }
}
