using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour {

    public float distance;
    public float wakeRange;
    public float shootCD;
    public float barrelHeat;
    public float bulletSpeed;

    public int rotation;
    public int currentCollisions;
    public Bullet bullet;
    public GameObject target;
    public Animator anim;
    public Transform shootPointUpRight, shootPointUp, shootPointUpLeft;
    public Transform shootPointDownLeft, shootPointDown, shootPointDownRight;

    void Awake()
    {
        target = null;
        currentCollisions = 0;
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("Update: " + target + "(" + currentCollisions + ")");
        if ((barrelHeat -= Time.deltaTime) < 0.0f)
            barrelHeat = 0.0f;
        if (target != null)
            Attack();
	}

    void Attack()
    {
        Vector2 dir;
        Transform ex;
        Bullet data;

        if (barrelHeat <= 0)
        {
            Debug.Log("Attack on "+ target.name + "!");
            dir = target.gameObject.transform.position - gameObject.transform.position;
            dir.Normalize();
            int idx = (int)((Vector2.Angle(Vector2.right, dir) - 30.0f) / 60.0f);
            ex = (new Transform[6] {shootPointUpRight,
            shootPointUp,
            shootPointUpLeft,
            shootPointDownLeft,
            shootPointDown,
            shootPointDownRight})[idx];
            Bullet bulletClone = Instantiate(bullet, ex.transform.position, ex.transform.rotation) as Bullet;
            bulletClone.speed = bulletSpeed;
            bulletClone.target = target;
            /*if ((data = bulletClone.GetComponent<Bullet>()) != null)
            {
                data.target = target;
                data.speed = bulletSpeed;
            }*/
            barrelHeat = shootCD;
            
        }
    }
}