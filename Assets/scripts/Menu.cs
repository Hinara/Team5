using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    bool Mute = false;
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void MuteButton()
    {
        Mute = !Mute;
        print(Mute);
        AudioListener.volume = (Mute) ? 0.0f : 1.0f;
    }

    public void MinusButton()
    {
        AudioListener.volume -= 0.2f;
    }

    public void PlusButton()
    {
        AudioListener.volume += 0.2f;
    }

    public void ClickExit()
    {
        Application.Quit();
    }
}