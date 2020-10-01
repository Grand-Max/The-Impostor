using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject lobby;

    


    public void LoadTestMap()
    {
        SceneManager.LoadScene("SingleMap");
    }

    public void LoadSetting()
    {
         //SceneManager.LoadScene("TestMap");
    }

    public void ShowLobby()
    {
        mainMenu.SetActive(false);
        lobby.SetActive(true);
    }

    public void backMenuFromLobby()
    {
        lobby.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
