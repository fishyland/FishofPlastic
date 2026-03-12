using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    public GameObject Player;
    private Animator animator;
    public GameObject Melee;
    bool isAttacking = false;
    float atkDuration = 0.3f;
    float atkTimer = 0f;
    private float horizInput;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        horizInput = Input.GetAxisRaw("Horizontal"); 
        CheckMeleeTimer();

        if(Input.GetKeyDown(KeyCode.R) || Input.GetMouseButton(0))
        {
            Player.GetComponent<Animator>().Play("Fishfight");
            OnAttack();
            
        }

    if (spriteRenderer != null)
        {
            if (horizInput > 0.1f) spriteRenderer.flipX = false;
            else if (horizInput < -0.1f) spriteRenderer.flipX = true;
        }

    }


    void OnAttack()
    {
        if(!isAttacking)
        Melee.SetActive(true);
        isAttacking = true;
        
    }

    void CheckMeleeTimer()
    {
        if (isAttacking)
        {
            atkTimer = Time.deltaTime;
            if(atkTimer >= atkDuration)
            {
                atkTimer = 0;
                isAttacking = false;
                Melee.SetActive(false);
            }
        }
    }

}
