using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 lastMoveDirection;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float horizInput;

    public Transform Aim;
    bool isWalking = false;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
        horizInput = Input.GetAxisRaw("Horizontal");

     if (spriteRenderer != null)
        {
            if (horizInput > 0.1f) spriteRenderer.flipX = false;
            else if (horizInput < -0.1f) spriteRenderer.flipX = true;
        }

    }
    private void FixedUpdate()
    {
        if(isWalking)
        {
        Vector3 vector3 = Vector3.left * moveInput.x * Vector3.down * moveInput.y;
        Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);

        if(context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
            lastMoveDirection = moveInput;

        Vector3 vector3 = Vector3.left * lastMoveDirection.x * Vector3.down * lastMoveDirection.y;
        Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
    
        }
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX",moveInput.x);
        animator.SetFloat("InputY",moveInput.y);
    }
}

