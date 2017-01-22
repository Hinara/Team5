using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    protected float life;
    public float speed;
    protected Enemies target;
    public Elements my_elem;


	// Use this for initialization
	void Start () {
        life = 100;
        Debug.Log("Hello! i'm a bullet");
	}
	
    public void setTarget(Enemies order)
    {
        target = order;
    }

	// Update is called once per frame
	void Update () {
        if ((life -= Time.deltaTime) <= 0)
        {
            Debug.Log("Like a hero, i fall");
            Destroy(gameObject);
        }
        if (target != null)
        {
            Vector3 dir = (target.gameObject.transform.position
               - gameObject.transform.position).normalized;
            gameObject.transform.position += dir * (speed * Time.deltaTime);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Enemies victim;
   
        Debug.Log("Somethings gon' go wrong with " + col.gameObject.name);
        if (col.isTrigger == true)
        {
            if ((victim = col.GetComponent<Enemies>()) != null)
            {
                Debug.Log("And i met my archenemy, " + victim.name);
                switch (my_elem)
                {
                    case Elements.Fire:
                        victim.setOnFire(5.0f);
                        break;
                    case Elements.Water:
                        victim.freeze(5.0f);
                        break;
                    case Elements.Thunder:
                        victim.electricityDamage(35.0f);
                        break;
                    case Elements.Earth:
                        victim.earthQuake();
                        break;
                    case Elements.Wind:
                        victim.blowAway(30.0f);
                        break;
                    case Elements.Light:
                        victim.laserDamage(30.0f);
                        break;
                }
                Debug.Log("Haha! Found You, bitch! (" + target.name + ")");
                if (my_elem == Elements.Wind)
                {
                    life -= 20.0f;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
