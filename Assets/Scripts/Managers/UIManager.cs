using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(0);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(1);
    }

    public void YouWin()
    {
        SceneManager.LoadScene(2);
    }
}
