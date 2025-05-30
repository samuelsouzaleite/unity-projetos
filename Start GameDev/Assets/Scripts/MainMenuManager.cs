using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
   [SerializeField]private string nameOfGameLevel;
   [SerializeField]private GameObject panelMainMenu;
   [SerializeField]private GameObject panelOptions;
   public void play()
    {
        SceneManager.LoadScene(nameOfGameLevel);
    }

    public void OpenOptions()
    {
        panelMainMenu.SetActive(false);
        panelOptions.SetActive(true);
    }

    public void CloseOptions()
    {
        panelMainMenu.SetActive(true);
        panelOptions.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("jogo fechado");
        Application.Quit();
    }
}
