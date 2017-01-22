using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobDetector : MonoBehaviour {
    TurretAI turretAI;

    // Use this for initialization
    void Start () {

	}

    void Awake()
    {
            turretAI = gameObject.GetComponentInParent<TurretAI>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Vector2     dir;
        float       min_distance;
        GameObject  next_target;

        if (coll.gameObject.GetComponent<Enemies>() == null)
            return ;
        Debug.Log("I'm kicking your ass, " + coll.gameObject.name);
        turretAI.currentCollisions++;
        min_distance = float.MaxValue;
        dir = coll.transform.position - gameObject.transform.position;
        if (dir.magnitude < min_distance)
           turretAI.target = coll.gameObject;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<Enemies>() == null)
            return;
        Debug.Log("Fuck this shit " + coll.gameObject.name + " is out!");
        turretAI.currentCollisions--;
        if (turretAI.currentCollisions <= 0)
            turretAI.target = null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
