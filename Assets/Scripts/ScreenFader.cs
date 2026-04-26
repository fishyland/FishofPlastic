using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScreenFader : MonoBehaviour
{
  public Image image;
  

    public void Start()
    {
//        StartCoroutine(FadeOut());
    }
  public void FadeAndLoad(string sceneName, float duration)
    {
        StartCoroutine(Fader(sceneName, duration));
    }

    IEnumerator Fader(string sceneName, float duration)
    {
        float t = 0;
        Color c = image.color;
        while(t < duration)
        {
            t += Time.deltaTime;
            c.a = t/duration;
            image.color = c;
            yield return null;
        }
    
    }

    IEnumerator FadeOut()
    {
         float t = 0;
        Color c = image.color;
        while(t < 1)
        {
            t += Time.deltaTime;
            c.a = 1f - (t/1f);
            image.color = c;
            yield return null;
        }
    }
}
