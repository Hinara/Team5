using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour {

    protected Enemies target = null;
    protected Animator anim;
    public float shootCD;
    public float barrelHeat;
    //public float bulletSpeed;
    public Bullet bullet;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        this.OnTriggerStay2D(collider);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (target == null)
        {
            Enemies temp = collider.GetComponent<Enemies>();
            if (temp != null)
            {
                target = temp;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (target != null)
        {
            Enemies temp = collision.GetComponent<Enemies>();
            if (temp != null)
            {
                if (target.GetInstanceID() == temp.GetInstanceID())
                {
                    target = null;
                }
            }
        }
    }

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (target != null)
        {
            if (target.gameObject == null)
            {
                target = null;
            }
            else
            {
                rotateInDirection(target.gameObject.transform.position);
            }
            Attack();
        }
        if ((barrelHeat -= Time.deltaTime) < 0.0f)
            barrelHeat = 0.0f;            
    }
    private void rotateInDirection(Vector3 vec)
    {
        //Quaternion quat = transform.rotation;
        float degrees = Vector3.Angle(Vector3.right, vec - transform.position);
        if (vec.y < transform.position.y)
        {
            degrees = 360 - degrees;
        }
        anim.SetFloat("Angle", degrees);
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
            Bullet bulletClone = Instantiate(bullet, transform.position, transform.rotation) as Bullet;
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