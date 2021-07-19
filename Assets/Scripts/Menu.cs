using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void newGameButton()
    {
        SceneManager.LoadScene(1);
    }
    public void exitButton()
    {
        Application.Quit();
    }
}
