using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenuController : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Main_GamePlay");
    }
     public void Main_Ui()
    {
        SceneManager.LoadScene("Main_Ui");
    }
  public void PreLosing()
    {
        SceneManager.LoadScene("PreLosing");
    }
    public void Lose_Scene()
    {
        SceneManager.LoadScene("Lose_Scene");
    }

    public void Win_Scene()
    {
        SceneManager.LoadScene("Win_Scene");
    }

    public void Story_Scene1()
    {
        SceneManager.LoadScene("Story_Scene1");
    }
     public void Story_Scene2()
    {
        SceneManager.LoadScene("Story_Scene2");
    }
     public void Story_Scene3()
    {
        SceneManager.LoadScene("Story_Scene3");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Break();
    }
}