using UnityEngine;

public class BossMusic : MonoBehaviour
{

  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audioSource.clip = bossMusic;
            audioSource.Play();
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
          if(collision.gameObject.tag == "Player")
        {
            audioSource.clip = defaultMusic;
            audioSource.Play();
        }
    }
    
    
}
