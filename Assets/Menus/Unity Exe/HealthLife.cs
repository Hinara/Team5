using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthLife : MonoBehaviour {

    public float StartLife = 1000;
    public float CurentLife;
    public Slider healthBar;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public float flashSpeed = 5f;

    bool isDead;
    bool damaged;
    // Use this for initialization
    void Start () {
        CurentLife = StartLife;
	}

    void Awake()
    {
        CurentLife = StartLife;
    }

	// Update is called once per frame
	void Update ()
    {
        TakeDamage(1);
	}

    public void TakeDamage(int amount)
    {
        damaged = true;
        CurentLife -= amount;
        healthBar.value = CurentLife / StartLife;
        if (CurentLife <= 0 && !isDead)
        {
            isDead = true;
            Death();
        }
    }

    void Death()
    {
        Application.LoadLevel("Menu_GGJ");           
    }
}
