using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public int NewGameScene;

    public void NewGame()
    {
        SceneManager.LoadScene(NewGameScene);
    }

    public void ContinueGame()
    {
        Debug.Log("Эта функция ещё не добавлена, используйте Новую Игру");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
