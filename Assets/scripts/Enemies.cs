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

    [Tooltip("Efficiency of the fire damage")]
    public float lava_efficiency;
    [Tooltip("Efficiency of the water slow.")]
    public float water_efficiency;
    [Tooltip("Efficiency of electricity damage.")]
    public float electricity_efficiency;
    [Tooltip("Efficiency of a wind blow")]
    public float wind_efficiency;
    [Tooltip("Efficiency of laser damage.")]
    public float laser_efficiency;
    [Tooltip("Maximal duration of a stun on this enemy")]
    public float maxStunDuration;
    [Tooltip("Gold Dropped by the ennemy")]
    public float goldDropped;

    [Tooltip("Spawn Rate of this ennemie")]
    public float spawnRate;


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
                updatePosition();
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
        float pos = this.position / 4000.0f;
        float x;
        float y;
        x = 0.0f;
        y = 0.0f;
        if (pos <= 5.0f)
        {
            x = -26.42f + 1.35f * pos;
            y = 8.14f - 0.5f * pos;
        }
        else if (pos <= 8.0f)
        {
            x = -19.67f;
            y = 5.64f - 1f * (pos - 5.0f);
        }
        else if (pos <= 9.0f)
        {
            x = -19.67f + 1.35f * (pos - 8.0f);
            y = 2.64f - 0.5f * (pos - 8.0f);
        }
        else if (pos <= 11.0f)
        {
            x = -18.32f + 1.35f * (pos - 9.0f);
            y = 2.14f + 0.5f * (pos - 9.0f);
        }
        else if (pos <= 12.0f)
        {
            x = -15.62f + 1.35f * (pos - 11.0f);
            y = 3.14f - 0.5f * (pos - 11.0f);
        }
        else if (pos <= 18.0f)
        {
            x = -14.27f;
            y = 2.64f - 1.0f * (pos - 12.0f);
        }
        else if (pos <= 22.0f)
        {
            x = -14.27f + 1.35f * (pos - 18.0f);
            y = -3.36f - 0.5f * (pos - 18.0f);
        }
        else if (pos <= 23.0f)
        {
            x = -8.87f + 1.35f * (pos - 22.0f);
            y = -5.36f + 0.5f * (pos - 22.0f);
        }
        else if (pos <= 24.0f)
        {
            x = -7.52f + 1.35f * (pos - 23.0f);
            y = -4.86f - 0.5f * (pos - 23.0f);
        }
        else if (pos <= 25.0f)
        {
            x = -6.17f + 1.35f * (pos - 24.0f);
            y = -5.36f + 0.5f * (pos - 24.0f);
        }
        else if (pos <= 26.0f)
        {
            x = -4.82f + 1.35f * (pos - 25.0f);
            y = -4.86f - 0.5f * (pos - 25.0f);
        }
        else if (pos <= 27.0f)
        {
            x = -3.47f + 1.35f * (pos - 26.0f);
            y = -5.36f + 0.5f * (pos - 26.0f);
        }
        else if (pos <= 30.0f)
        {
            x = -2.12f + 1.35f * (pos - 27.0f);
            y = -4.86f - 0.5f * (pos - 27.0f);
        }
        else if (pos <= 31.0f)
        {
            x = 1.93f + 1.35f * (pos - 30.0f);
            y = -6.36f + 0.5f * (pos - 30.0f);
        }
        else if (pos <= 33.0f)
        {
            x = 3.28f + 1.35f * (pos - 31.0f);
            y = -5.86f - 0.5f * (pos - 31.0f);
        }
        else if (pos <= 34.0f)
        {
            x = 5.98f + 1.35f * (pos - 33.0f);
            y = -6.86f + 0.5f * (pos - 33.0f);
        }
        else if (pos <= 35.0f)
        {
            x = 7.33f;
            y = -6.36f + 1.0f * (pos - 34.0f);
        }
        else if (pos <= 37.0f)
        {
            x = 7.33f + 1.35f * (pos - 35.0f);
            y = -5.36f + 0.5f * (pos - 35.0f);
        }
        else if (pos <= 38.0f)
        {
            x = 10.03f + 1.35f * (pos - 37.0f);
            y = -4.36f - 0.5f * (pos - 37.0f);
        }
        else if (pos <= 39.0f)
        {
            x = 11.38f + 1.35f * (pos - 38.0f);
            y = -4.86f + 0.5f * (pos - 38.0f);
        }
        else if (pos <= 40.0f)
        {
            x = 12.73f;
            y = -4.36f + 1.0f * (pos - 39.0f);
        }
        else if (pos <= 44.0f)
        {
            x = 12.73f + 1.35f * (pos - 40.0f);
            y = -3.36f + 0.5f * (pos - 40.0f);
        }
        else if (pos <= 45.0f)
        {
            x = 18.13f;
            y = -1.36f + 1.0f * (pos - 44.0f);
        }
        else if (pos <= 48.0f)
        {
            x = 18.13f + 1.35f * (pos - 45.0f);
            y = -0.36f + 0.5f * (pos - 45.0f);
        }
        else
        {
            //DAMAGE TO THE CASTLE
        }
        transform.position = new Vector2(x, y);
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
