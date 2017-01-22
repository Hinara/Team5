using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float life;
    public float speed;
    public GameObject target;


	// Use this for initialization
	void Start () {
        life = 100;
        Debug.Log("Hello! i'm a bullet");
	}
	
	// Update is called once per frame
	void Update () {
        if ((life -= Time.deltaTime) <= 0)
        {
            Debug.Log("Like a hero, i fall");
            Destroy(gameObject);
        }
          
        Vector3 dir = target.gameObject.transform.position
            - gameObject.transform.position;
        dir.Normalize();
        gameObject.transform.position += dir * (speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Somethings gon' go wrong!");
        if (col.isTrigger == true)
        {
            if (col.GetComponent<Enemies>() != null)
                col.GetComponent<Enemies>().earthQuake();
            Debug.Log("Haha! Found You, bitch! (" + target.name + ")");
            Destroy(gameObject);
        }
    }
}
