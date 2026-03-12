using UnityEngine;

public class Weapon : MonoBehaviour
{
    private EnemyConfig config;
    public float damage = 2f;
   

   private void OnTriggerEnter2D(Collider2D collision)
    {
            


        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy !=null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
