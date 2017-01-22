using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour {

    private float angle;
    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        angle = anim.GetFloat("Angle");

    }
	
	// Update is called once per frame
	void Update () {
        angle = (angle + Time.deltaTime * 10.0f) % 360.0f;
        anim.SetFloat("Angle", angle);
	}
}
