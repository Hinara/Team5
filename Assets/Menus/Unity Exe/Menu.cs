﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Use this for initialization
    void Start ()
    {
         
	}

	// Update is called once per frame
	void Update () {
		
	}
}
