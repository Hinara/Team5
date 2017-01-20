using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

    [Tooltip("Maximum HP of this enemy.")]
    public float maxHp;
    [Tooltip("Damage of the enemy.")]
    public float dmg;
    [Tooltip("Speed of the enemy.")]
    public float speed;

    [Tooltip("Efficiency of the water slow.")]
    public float water_efficiency;
    [Tooltip("Efficiency of the fire damage")]
    public float lava_efficiency;
    [Tooltip("Efficiency of electricity damage.")]
    public float electricity_efficiency;
    [Tooltip("Efficiency of laser damage.")]
    public float laser_efficiency;
    [Tooltip("Maximal duration of a stun on this enemie")]
    public float maxStunDuration;
    [Tooltip("Gold Dropped by the ennemy")]
    public float goldDropped;

    private float currentHp;
    private float position;
    private float fireDuration;
    private float slowDuration;
    private float stunDuration;
    private float stunCd;

    // Use this for initialization
    void Start () {
        this.currentHp = this.maxHp;
        this.position = 0.0f;

        this.stunCd = 0.0f;
        this.stunDuration = 0.0f;
        this.fireDuration = 0.0f;
        this.slowDuration = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

        // This part is the move parts of enemies
        if (slowDuration > 0.0f)
        {
            this.slowDuration -= Time.deltaTime;
            if (stunDuration <= 0.0f)
            {
                this.position += speed * water_efficiency;
                updatePosition();
            }
            else
            {
                stunDuration -= Time.deltaTime;
            }
        }
        else
        {
            if (stunDuration <= 0.0f)
            {
                this.position += speed;
            }
            else
            {
                stunDuration -= Time.deltaTime;
            }
        }

        //This part prohibit the spam of the stun
        if (stunCd > 0.0f)
            stunCd -= Time.deltaTime;

        //This part is the damage by fire part of the enemies
        if (fireDuration > 0.0f)
        {
            damaged(2.0f * lava_efficiency);
            fireDuration -= Time.deltaTime;
        }
	}

    void updatePosition()
    {
        int x;
        int y;
        x = 0;
        y = 0;
        Vector2 pos = new Vector2(x, y);
    }
    public void stun(float duration)
    {
        if (stunCd <= 0.0f)
        {
            if (duration > maxStunDuration)
                duration = maxStunDuration;
            stunDuration = duration;
            stunCd = duration * 4;
        }
    }

    public void earthQuake()
    {
        damaged(249.0f);
    }

    public void setOnFire(float duration)
    {
        if (lava_efficiency > 0.0f)
        {
            fireDuration = duration;
        }
    }

    public void electricityDamage(float dmg)
    {
        damaged(dmg * electricity_efficiency);
    }

    public void laserDamage(float dmg)
    {
        damaged(dmg * laser_efficiency);
    }

    void damaged(float dmg)
    {
        currentHp -= dmg;
        if (currentHp <= 0.0f)
        {
            //TODO : Get the money dropped by the mob
            Destroy(this.gameObject);
        }
    }
}
