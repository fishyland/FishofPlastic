using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
   private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
