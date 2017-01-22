using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour {
    public int Sound;

	// Use this for initialization
	void Start () {
		
	}
	public void PlusButton()
    {
        AudioListener.volume += 0.2f;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
