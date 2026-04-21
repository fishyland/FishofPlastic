using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 5f;
    //public PlayerAttackState attackState;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 lastMoveDirection;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float horizInput;
    private bool isWalking;
    public bool attackPressed;
    public GameObject Player;

    [Header ("Attack Settings")]
    public int damage;
    public float attackRadius = .5f;
    public Transform attackPoint;
    public LayerMask enemyLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   // private void Awake()
   // {
        //attackState = new PlayerAttackState(this);
   // }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseController.IsGamePaused)
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("isWalking", false);
            return;
        }
        rb.linearVelocity = moveInput * moveSpeed;
        animator.SetBool("isWalking", rb.linearVelocity.magnitude > 0);
        horizInput = Input.GetAxisRaw("Horizontal");

     if (spriteRenderer != null)
        {
            if (horizInput > 0.1f) spriteRenderer.flipX = false;
            else if (horizInput < -0.1f) spriteRenderer.flipX = true;
            
        }
        OnAttack();

    }

    public void Move(InputAction.CallbackContext context)
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");


        

        if((moveX == 0 && moveY == 0) && (moveInput.x != 0 || moveInput.y !=0))
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        
    
        } else if (moveX != 0 || moveY != 0)
        {
            isWalking = true;
        }
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX",moveInput.x);
        animator.SetFloat("InputY",moveInput.y);
    }

    public void OnAttack()
    {
        attackPressed = true;
        if(Input.GetKeyDown(KeyCode.R) || Input.GetMouseButton(0))
        {
            Collider2D enemy = Physics2D.OverlapCircle(attackPoint.position,attackRadius,enemyLayer);

            if(enemy != null)
                enemy.gameObject.GetComponent<Health>().ChangeHealth(-damage, transform.position);
            animator.Play("Fishfight");
        }
    }
      
    
}

