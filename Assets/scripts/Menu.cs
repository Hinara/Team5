using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public float time;
    public string scene;
    public bool stop;

    private float time_d;

    private void Start()
    {
        time_d = 0;
    }

    private void Update()
    {
        if (time > 0.0f)
        {
            time_d += Time.deltaTime;
            if (time_d >= time)
            {
                if (stop)
                {
                    Application.Quit();
                }
                else if (scene != null)
                {
                    SceneManager.LoadScene(scene);
                }
            }
        }
    }

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