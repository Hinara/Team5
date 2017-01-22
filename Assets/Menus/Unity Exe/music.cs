using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour {

    bool Mute = false;

    // Use this for initialization
    void Start() {

    }

    public void MuteButton()
    {
        Mute = !Mute;
        print(Mute);
        AudioListener.volume = (Mute) ? 0.0f : 1.0f ;
    }
// Update is called once per frame
void Update ()
    {
		
	}
}