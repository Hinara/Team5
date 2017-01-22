using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject waterTurret;
    public GameObject fireTurret;
    public GameObject lightTurret;
    public GameObject electricTurret;
    public GameObject windTurret;

    public Text life;
    public Text money;

    public float gold = 100;
    public float maxHp = 1000.0f;

    private float hp;

    private Vector2 pos = new Vector2(0, 0);

    protected int[][] tab = new int[52][] {
    new int[] {0,0,0,0,0,0,0,0,1,1,1,1,1,1,2,2,2,2,2},
    new int[] {0,0,0,0,0,0,0,0,1,1,1,1,1,1,2,2,2,2,2},
    new int[] {0,0,0,0,0,0,0,0,1,1,1,1,1,1,2,2,2,2,2},
    new int[] {0,0,0,0,0,0,0,0,1,1,1,1,1,1,2,2,2,2,2},
    new int[] {0,0,0,0,0,0,0,0,1,1,1,1,1,1,2,2,2,2,2},
    new int[] {0,0,0,0,0,0,0,0,1,1,1,1,1,1,2,2,2,2,2},
    new int[] {0,0,0,0,0,0,0,0,1,1,1,1,1,1,2,2,2,2,2},
    new int[] {0,0,0,0,0,0,0,0,1,1,1,1,1,1,2,2,2,2,2},
    new int[] {0,0,0,0,0,0,0,0,0,1,1,1,1,1,2,2,2,2,5},
    new int[] {0,0,0,0,0,0,0,0,0,1,1,1,1,1,2,2,2,5,5},
    new int[] {3,0,0,0,0,0,0,0,0,1,1,1,1,1,2,2,2,5,5},
    new int[] {3,0,0,0,0,0,0,0,0,1,1,1,1,1,2,2,5,5,5},
    new int[] {0,3,0,0,0,0,0,0,0,1,1,1,1,1,1,2,5,5,5},
    new int[] {0,3,0,0,0,0,0,0,0,1,1,1,1,1,2,2,5,5,5},
    new int[] {0,0,3,0,0,0,0,0,0,0,1,1,1,1,1,2,5,5,5},
    new int[] {0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,2,5,5,5},
    new int[] {0,0,3,0,0,0,0,0,0,0,1,1,1,1,1,1,2,5,5},
    new int[] {0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,5,5,5},
    new int[] {0,0,3,0,0,0,0,0,0,0,1,1,1,1,1,1,2,5,5},
    new int[] {0,0,0,3,0,0,0,0,0,0,1,1,1,1,1,1,5,5,5},
    new int[] {0,0,3,3,3,0,0,0,0,0,1,1,1,1,1,1,2,5,5},
    new int[] {0,0,3,0,0,0,0,0,0,0,1,1,1,1,1,1,5,5,2},
    new int[] {0,0,0,0,3,0,0,0,0,0,1,1,1,1,1,1,2,2,2},
    new int[] {0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,2,3,2},
    new int[] {4,0,0,0,3,0,0,0,0,0,1,1,1,1,1,1,2,3,2},
    new int[] {4,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,3,2,2},
    new int[] {4,0,0,0,3,0,0,0,0,0,1,1,1,1,1,1,3,2,2},
    new int[] {4,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,2,2,2},
    new int[] {4,4,0,0,3,0,0,0,0,0,0,1,1,1,1,1,3,2,2},
    new int[] {4,0,0,0,0,0,0,0,0,0,1,1,1,1,1,3,2,2,2},
    new int[] {4,4,0,0,3,0,0,0,0,0,0,1,1,1,1,3,1,2,2},
    new int[] {4,4,0,0,0,0,0,0,0,0,1,1,1,1,3,1,2,2,2},
    new int[] {4,4,0,0,3,0,0,0,0,0,0,1,1,1,3,1,1,2,2},
    new int[] {4,4,0,0,3,0,0,0,0,0,1,1,1,1,1,1,1,2,2},
    new int[] {4,4,0,0,0,3,0,0,0,0,0,1,1,3,3,1,1,1,2},
    new int[] {4,4,0,0,0,3,3,3,3,0,1,1,3,3,1,1,1,1,2},
    new int[] {4,4,4,0,0,0,3,3,3,3,0,1,3,1,1,1,1,1,1},
    new int[] {4,4,0,0,0,0,0,0,0,3,3,1,1,1,1,1,1,1,2},
    new int[] {4,4,4,0,0,0,0,0,0,0,3,3,3,1,1,1,1,1,1},
    new int[] {4,4,0,0,0,0,0,0,0,0,0,3,1,1,1,1,1,1,2},
    new int[] {4,4,4,0,4,0,0,0,0,0,0,0,1,1,1,1,1,1,1},
    new int[] {4,4,4,4,4,0,0,0,0,0,0,0,1,1,1,1,1,1,2},
    new int[] {4,4,4,4,4,4,0,0,0,0,0,0,1,1,1,1,1,1,1},
    new int[] {4,4,4,4,4,4,0,0,0,0,0,0,1,1,1,1,1,1,1},
    new int[] {4,4,4,4,4,4,0,0,0,0,0,0,0,1,1,1,1,1,1},
    new int[] {4,4,4,4,4,4,0,0,0,0,0,0,1,1,1,1,1,1,1},
    new int[] {4,4,4,4,4,4,4,0,0,0,0,0,0,0,1,1,1,1,1},
    new int[] {4,4,4,4,4,4,0,0,0,0,0,0,0,1,1,1,1,1,1},
    new int[] {4,4,4,4,4,4,4,0,0,0,0,0,0,0,0,1,1,1,1},
    new int[] {4,4,4,4,4,4,4,0,0,0,0,0,0,0,1,1,1,1,1},
    new int[] {4,4,4,4,4,4,4,0,0,0,0,0,0,0,0,1,1,1,1},
    new int[] {4,4,4,4,4,4,4,0,0,0,0,0,0,0,1,1,1,1,1}
    };
    // Use this for initialization
    void Start () {
        hp = maxHp;
    }
	
	// Update is called once per frame
	void Update () {
        if (gold >= 100.0f)
        {
            if (Input.GetButtonDown("Turret1"))
            {
                if (tab[(int)this.pos.y][(int)this.pos.x] < 3)
                {
                    tab[(int)this.pos.y][(int)this.pos.x] += 8;
                    Instantiate(fireTurret, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
                    spendMoney(100.0f);
                }
            }
            if (Input.GetButtonDown("Turret2"))
            {
                if (tab[(int)this.pos.y][(int)this.pos.x] < 3)
                {
                    tab[(int)this.pos.y][(int)this.pos.x] += 8;
                    Instantiate(waterTurret, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
                    spendMoney(100.0f);
                }
            }
            if (Input.GetButtonDown("Turret3"))
            {
                if (tab[(int)this.pos.y][(int)this.pos.x] < 3)
                {
                    tab[(int)this.pos.y][(int)this.pos.x] += 8;
                    Instantiate(windTurret, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
                    spendMoney(100.0f);
                }
            }
            if (Input.GetButtonDown("Turret4"))
            {
                if (tab[(int)this.pos.y][(int)this.pos.x] < 3)
                {
                    tab[(int)this.pos.y][(int)this.pos.x] += 8;
                    Instantiate(electricTurret, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
                    spendMoney(100.0f);
                }
            }
            if (Input.GetButtonDown("Turret5"))
            {
                if (tab[(int)this.pos.y][(int)this.pos.x] < 3)
                {
                    tab[(int)this.pos.y][(int)this.pos.x] += 8;
                    Instantiate(lightTurret, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
                    spendMoney(100.0f);
                }
            }
        }
        if (Input.GetButtonDown("Right"))
        {
            if (pos.y % 2 == 0)
            {
                if (pos.y + 1 < 51)
                {
                    pos.y += 1;
                    transform.position = new Vector2(transform.position.x + 1.35f, transform.position.y - 0.5f);
                }
            }
            else
            {
                if (pos.y - 1 >= 0 && pos.x + 1 < 19)
                {
                    pos.y -= 1;
                    pos.x += 1;
                    transform.position = new Vector2(transform.position.x + 1.35f, transform.position.y + 0.5f);
                }
            }
        }
        if (Input.GetButtonDown("Left"))
        {
            if (pos.y % 2 == 1)
            {
                if (pos.y - 1 >= 0)
                {
                    pos.y -= 1;
                    transform.position = new Vector2(transform.position.x - 1.35f, transform.position.y + 0.5f);
                }
            }
            else
            {
                if (pos.y + 1 < 51 && pos.x - 1 >= 0.0f)
                {
                    pos.y += 1;
                    pos.x -= 1;
                    transform.position = new Vector2(transform.position.x - 1.35f, transform.position.y - 0.5f);
                }
            }
        }
        if (Input.GetButtonDown("Up"))
        {
            if (pos.y - 2 >= 0)
            {
                pos.y -= 2;
                transform.position = new Vector2(transform.position.x, transform.position.y + 1.0f);
            }
        }
        if (Input.GetButtonDown("Down"))
        {
            if (pos.y + 2 < 51)
            {
                pos.y += 2;
                transform.position = new Vector2(transform.position.x, transform.position.y - 1.0f);
            }
        }
    }

    public void addMoney(float amount)
    {
        this.gold += amount;
        updateMoneyUI();
    }

    public void spendMoney(float amount)
    {
        this.gold -= amount;
        updateMoneyUI();
    }

    public void updateMoneyUI()
    {
        if (money != null)
        {
            money.text = gold + "$";
        }
    }

    public void updateLifeUI()
    {
        if (life != null)
        {
            life.text = hp + "/" + maxHp;
        }
    }
}
