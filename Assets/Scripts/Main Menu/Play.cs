using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("round1");
    }

    public void round2()
    {
        SceneManager.LoadScene("round2");
    }

    public void round3()
    {
        SceneManager.LoadScene("round3");
    }

    public void round4()
    {
        SceneManager.LoadScene("round4");
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
