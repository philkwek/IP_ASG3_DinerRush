using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SplashScreen : MonoBehaviour
{
    public GameObject Screen; //stop showing splash screen
    public GameObject Menu; //start showing menu
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeScene());
    }
    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3.5f);
        Screen.SetActive(false);
        Menu.SetActive(true);


    }
}
