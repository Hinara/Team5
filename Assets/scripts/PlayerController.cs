using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject waterTurret;
    public GameObject fireTurret;
    public GameObject lightTurret;
    public GameObject electricTurret;
    public GameObject windTurret;

    private Vector2 pos = new Vector2(0, 0);

    private Vector2 org;

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
        org = transform.position;
    }
	
    void displayCase()
    {
        switch (tab[(int) this.pos.y][(int) this.pos.x])
        {
            case 0:
                print("Sand");
                break;
            case 1:
                print("Water");
                break;
            case 2:
                print("Grass");
                break;
            case 3:
                print("Nothing");
                break;
            case 4:
                print("Castle");
                break;
            case 5:
                print("Path");
                break;
            default:
                print("Unknown");
                break;
        }
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Turret1"))
        {
            if (tab[(int)this.pos.y][(int)this.pos.x] < 3)
            {
                tab[(int)this.pos.y][(int)this.pos.x] += 8;
                Instantiate(fireTurret, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
            }
        }
        if (Input.GetButtonDown("Turret2"))
        {
            if (tab[(int)this.pos.y][(int)this.pos.x] < 3)
            {
                tab[(int)this.pos.y][(int)this.pos.x] += 8;
                Instantiate(waterTurret, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
            }
        }
        if (Input.GetButtonDown("Turret3"))
        {
            if (tab[(int)this.pos.y][(int)this.pos.x] < 3)
            {
                tab[(int)this.pos.y][(int)this.pos.x] += 8;
                Instantiate(windTurret, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
            }
        }
        if (Input.GetButtonDown("Turret4"))
        {
            if (tab[(int)this.pos.y][(int)this.pos.x] < 3)
            {
                tab[(int)this.pos.y][(int)this.pos.x] += 8;
                Instantiate(electricTurret, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
            }
        }
        if (Input.GetButtonDown("Turret5"))
        {
            if (tab[(int)this.pos.y][(int)this.pos.x] < 3)
            {
                tab[(int)this.pos.y][(int)this.pos.x] += 8;
                Instantiate(lightTurret, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
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
                    displayCase();
                }
            }
            else
            {
                if (pos.y - 1 >= 0 && pos.x + 1 < 19)
                {
                    pos.y -= 1;
                    pos.x += 1;
                    transform.position = new Vector2(transform.position.x + 1.35f, transform.position.y + 0.5f);
                    displayCase();
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
                    displayCase();
                }
            }
            else
            {
                if (pos.y + 1 < 51 && pos.x - 1 >= 0.0f)
                {
                    pos.y += 1;
                    pos.x -= 1;
                    transform.position = new Vector2(transform.position.x - 1.35f, transform.position.y - 0.5f);
                    displayCase();
                }
            }
        }
        if (Input.GetButtonDown("Up"))
        {
            if (pos.y - 2 >= 0)
            {
                pos.y -= 2;
                transform.position = new Vector2(transform.position.x, transform.position.y + 1.0f);
                displayCase();
            }
        }
        if (Input.GetButtonDown("Down"))
        {
            if (pos.y + 2 < 51)
            {
                pos.y += 2;
                transform.position = new Vector2(transform.position.x, transform.position.y - 1.0f);
                displayCase();
            }
        }
    }
}
