using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public CanvasGroup mainMenu;
    public CanvasGroup optionsMenu;
    public float transitionDuration = .25f;

    void Start()
    {
        ShowMainMenuInstant();
    }
    public void OpenOptionsMenu()
    {
        StartCoroutine(TransitionMenus(mainMenu,optionsMenu)); //function that plays with time
    }
    public void BackToMainMenu()
    {
        StartCoroutine(TransitionMenus(optionsMenu, mainMenu));
    }
    
    void ShowMainMenuInstant() //void for standard function
    {
        //making sure main menu is on
        mainMenu.alpha = 1; //alpha is connected to opacity, fades out from one to another
        mainMenu.interactable = true; //hover over buttons
        mainMenu.blocksRaycasts = true; //makes it so u can touch the ui without affecting anything in the bg

    //making sure options menu is on
        optionsMenu.alpha = 0;
        optionsMenu.interactable = false;
        optionsMenu.blocksRaycasts = false;
        optionsMenu.gameObject.SetActive(false);
    }
    IEnumerator TransitionMenus(CanvasGroup currentMenu, CanvasGroup nextMenu) //Enumerautur for coroutine
    {
        float timer = 0f;
        nextMenu.gameObject.SetActive(true);

        while(timer < transitionDuration)
        {
            timer += Time.deltaTime; //time goes up by framerate
            float progress = timer/transitionDuration; //over time slowing down
            currentMenu.alpha = 1-progress; //minused by timer going down by one
            nextMenu.alpha = progress; //going up by one
            yield return null; //wait for n seconds then do it, null means it doesnt have to do it more than once
        }
        currentMenu.interactable = false;
        currentMenu.blocksRaycasts = false;
        currentMenu.gameObject.SetActive(false);

        nextMenu.interactable = true;
        nextMenu.blocksRaycasts = true;
        //opposite way around, slowly turns back on
    }
}
