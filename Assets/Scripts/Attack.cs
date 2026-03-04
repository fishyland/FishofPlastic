using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject Melee;
    bool isAttacking = false;
    float atkDuration = 0.3f;
    float atkTimer = 0f;
    void Update()
    {
        CheckMeleeTimer();
       if(Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(0));
        {
           OnAttack();
        } 
    
    }

    void OnAttack()
    {
        Melee.SetActive(true);
        isAttacking = true;
        //call animator to play melee attack
    }

    void CheckMeleeTimer()
    {
        atkTimer += Time.deltaTime;
        if(atkTimer >= atkDuration)
        {
            atkTimer = 0;
            isAttacking = false;
            Melee.SetActive(false);
        }
    }
}
