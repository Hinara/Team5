using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Enemies[] mobs;
    public float timeBetweenWaves = 10.0f;
    public int[] nbOfMobByWave;
    public float timeBetweenTwoSpawns = 0.5f;

    private int wave = 0;
    private float spawnCd = 0.0f;
    private float timeLastingBeforeNewWave;
    private bool inWave = false;
    private int ennemySpawned = 0;

    private float randomLimit = 0.0f;
	// Use this for initialization
	void Start () {
        timeLastingBeforeNewWave = timeBetweenWaves;
        foreach (Enemies mob in mobs)
        {
            randomLimit += mob.spawnRate;
        }
    }
	
    protected Enemies getRandomEnemy()
    {
        float range = 0.0f;
        float rnd = Random.Range(0.0f, randomLimit);
        foreach (Enemies mob in mobs)
        {
            range += mob.spawnRate;
            if (range >= rnd)
            {
                return (mob);
            }
        }
        return (null);
    }

	// Update is called once per frame
	void Update () {
        
        if (wave < nbOfMobByWave.Length)
        {
            if (inWave)
            {
                if (spawnCd <= 0.0f)
                {
                    Instantiate(getRandomEnemy(), transform.position, transform.rotation);
                    if (ennemySpawned >= nbOfMobByWave[wave])
                    {
                        inWave = false;
                        timeLastingBeforeNewWave = timeBetweenWaves;
                        wave += 1;
                        ennemySpawned = 0;
                    }
                    else
                    {
                        ennemySpawned += 1;
                        spawnCd = timeBetweenTwoSpawns;
                    }

                }
                else
                {
                    spawnCd -= Time.deltaTime;
                }
            }
            else
            {
                timeLastingBeforeNewWave -= Time.deltaTime;
                if (timeLastingBeforeNewWave <= 0.0f)
                {
                    inWave = true;
                }
            }
        }
	}

    public bool hasFinish()
    {
        return (wave >= nbOfMobByWave.Length);
    }
}
