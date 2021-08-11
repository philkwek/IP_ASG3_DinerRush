using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{

    public GameObject RoundScript;

    public void PlayGame()
    {
        RoundScript.GetComponent<RoundScript>().FadeToBlack();
        Invoke("Load1", 3.0f);
    }

    void Load1()
    {
        SceneManager.LoadScene("round1");
    }

    public void round2()
    {
        RoundScript.GetComponent<RoundScript>().FadeToBlack();
        Invoke("Load2", 3.0f);
    }

    void Load2()
    {
        SceneManager.LoadScene("round2");
    }

    public void round3()
    {
        RoundScript.GetComponent<RoundScript>().FadeToBlack();
        Invoke("Load3", 3.0f);
    }

    void Load3()
    {
        SceneManager.LoadScene("round3");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("main_menu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("credits");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
