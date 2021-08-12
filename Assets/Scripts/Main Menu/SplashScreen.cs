using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SplashScreen : MonoBehaviour
{
    public GameObject Screen; //stop showing splash screen
    public GameObject Menu; //start showing menu
    public GameObject FadeScene;
    public GameObject fadeOut;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoFadeIn());
        StartCoroutine(ChangeScene());
    }
    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3.5f);
        Screen.SetActive(false);
        Menu.SetActive(true);
        fadeOut.GetComponent<mainMenuFade>().FadeOutBlack();
    }


    IEnumerator DoFadeIn()
    {
        yield return new WaitForSeconds(2.5f);
        FadeScene.SetActive(true);
        CanvasGroup canvasGroup = FadeScene.GetComponent<CanvasGroup>();
        Debug.Log(canvasGroup.alpha);
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }

    IEnumerator DoFadeOut()
    {
        yield return new WaitForSeconds(2);
        CanvasGroup canvasGroup = FadeScene.GetComponent<CanvasGroup>();
        Debug.Log(canvasGroup.alpha);
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime;
            yield return null;
        }
        yield return null;
        FadeScene.SetActive(false);
    }
}
