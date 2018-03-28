using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


    public void StartGame()
    {
        
        SceneManager.LoadScene("TestScene");
    }
    public void CloseGame()
    {
        Debug.Log("Game Closed..");
        Application.Quit();
    }
}
