using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuFade : MonoBehaviour
{

    public GameObject FadeScene;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeInBlack()
    {
        StartCoroutine(DoFadeIn());
    }
    public void FadeOutBlack()
    {
        StartCoroutine(DoFadeOut());
    }

    IEnumerator DoFadeIn()
    {
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
