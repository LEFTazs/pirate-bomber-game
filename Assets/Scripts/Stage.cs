using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


public class Stage : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<float> probabilites;
    public float minSpawnDelaySeconds;
    public float maxSpawnDelaySeconds;
    public int numOfEnemiesToSpawn;

    private int enemiesSpawned;
    private float lastGeneration;
    private float currentSpawnDelaySeconds;

    void Start()
    {
        enemiesSpawned = 0;
        lastGeneration = 0f;
        currentSpawnDelaySeconds = 0f;

        Assert.AreEqual(enemies.Count, probabilites.Count);
        float probabilitesSum = 0f;
        foreach (float probability in probabilites)
        {
            probabilitesSum += probability;
        }
        Assert.AreEqual(probabilitesSum, 1f);
    }

    void Update()
    {}

    public bool isDone()
    {
        return numOfEnemiesToSpawn <= enemiesSpawned;
    }

    public GameObject getNextEnemyIfReady() 
    {
        if (Time.time - lastGeneration > currentSpawnDelaySeconds) 
        {
            currentSpawnDelaySeconds = Random.Range(minSpawnDelaySeconds, maxSpawnDelaySeconds);
            lastGeneration = Time.time;
            enemiesSpawned++;
            return chooseNextEnemyType();
        }
        return null;
    }

    private GameObject chooseNextEnemyType() 
    {
        float randomValue = Random.value;
        float lastValue = 0f;
        for (int i = 0; i < probabilites.Count; i++)
        {
            if (lastValue <= randomValue && randomValue < lastValue + probabilites[i])
            {
                return enemies[i];
            }
            lastValue += probabilites[i];
        }
        return null;
    }
}
