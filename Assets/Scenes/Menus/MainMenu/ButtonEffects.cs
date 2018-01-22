using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonEffects : MonoBehaviour {

    public Button StartGameButton;
    public Button LoadGameButton;
    public Button SettingsGameButton;
    public Button ExitGameButton;
    public Button BackToMainMenuButton;
    public Button SoundOnOf;

    public void startPress()
    {
        SceneManager.LoadScene(1/*SceneNumber*/);
    }

    public void LoadSavePress()
    {
        SceneManager.LoadScene(0/*SceneNumber*/);
    }

    public void SettingsPress()
    {
        SceneManager.LoadScene(0/*SceneNumber*/);
    }

    public void ExitPress()
    {
        Application.Quit();
    }

    public void BackToMainMenuPress()
    {
        SceneManager.LoadScene(0/*MAINMENUSCENENUMBER*/);
    }



}
