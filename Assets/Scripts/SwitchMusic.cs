using UnityEngine;
using System.Collections;

public class SwitchMusic : MonoBehaviour
{

    public AudioClip newTrack;
    private AudioManager theAM;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theAM = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(newTrack != null)
            theAM.ChangeMusic(newTrack);
        }
    }
}
