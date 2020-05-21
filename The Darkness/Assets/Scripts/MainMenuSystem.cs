using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSystem : MonoBehaviour
{
    public GameObject menu, controls, information;

    public void Start()
    {
        menu.SetActive(true);
        controls.SetActive(false);
        information.SetActive(false);
    }

    public void StartGame()
    {
        menu.SetActive(false);
        controls.SetActive(false);
        information.SetActive(true);
    }

    public void Continue()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Controls()
    {
        menu.SetActive(false);
        information.SetActive(false);
        controls.SetActive(true);
    }

    public void Back()
    {
        menu.SetActive(true);
        controls.SetActive(false);
        information.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
