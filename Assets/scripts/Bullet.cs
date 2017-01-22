using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public Enemies target;


	// Use this for initialization
	void Start () {
        Debug.Log("Hello! i'm a bullet");
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null || target.gameObject == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Vector3 dir = (target.gameObject.transform.position
                - gameObject.transform.position).normalized;
            gameObject.transform.position += dir * (speed * Time.deltaTime);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Somethings gon' go wrong!");
        if (col.isTrigger == true)
        {
            if (col.GetComponent<Enemies>() != null)
            {
                col.GetComponent<Enemies>().earthQuake();
                Destroy(gameObject);
            }
        }
    }
}
