using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger entered");

        if(collision.gameObject.CompareTag("Player"))
        {
            
            print("Switching scene to " + sceneBuildIndex);
            FadeTransition();
           
        }

    }
    async void FadeTransition(GameObject player)
    {
        await ScreenFader.Instance.FadeOut();
         SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        await ScreenFader.Instance.FadeIn();
    }

}
