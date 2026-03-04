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
        Vector3 vector3 = Vector3.left * moveInput.x + Vector3.down * moveInput.y;
        Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");


        animator.SetBool("isWalking", true);

        if((moveX == 0 && moveY == 0) && (moveInput.x != 0 || moveInput.y !=0))
        {
            animator.SetBool("isWalking", false);
            lastMoveDirection = moveInput;
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
            

        Vector3 vector3 = Vector3.left * lastMoveDirection.x + Vector3.down * lastMoveDirection.y;
        Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
    
        } else if (moveX != 0 || moveY != 0)
        {
            isWalking = true;
        }
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX",moveInput.x);
        animator.SetFloat("InputY",moveInput.y);
    }
}

