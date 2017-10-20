using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonEffects : MonoBehaviour {

    public Button StartGameButton;
    public Button LoadGameButton;
    public Button SettingsGameButton;
    public Button ExitGameButton;

    public void startPress()
    {
        SceneManager.LoadScene(1/*SceneNumber*/);
    }

    public void LoadSavePress()
    {
        SceneManager.LoadScene(1/*SceneNumber*/);
    }

    public void SettingsPress()
    {
        SceneManager.LoadScene(1/*SceneNumber*/);
    }

    public void ExitPress()
    {
        Application.Quit();
    }


}
