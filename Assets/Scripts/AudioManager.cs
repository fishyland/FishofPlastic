using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource audioSource;
    
    
    [Header("AudioClips")]
    public AudioClip backgroundMusic;
    public AudioClip kickSFX;
    public AudioClip damageSFX;
    public AudioClip bossMusic, defaultMusic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        } 
        else
        {
            Destroy(gameObject);
        }
        }
    
   private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        defaultMusic = audioSource.clip;

        if (backgroundMusic != null && musicSource != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        if(clip!=null && sfxSource != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
    public void PlayMusic(AudioClip clip)
    {
        if(clip != null && musicSource != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
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

