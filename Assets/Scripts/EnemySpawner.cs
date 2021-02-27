using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject stageManager;
    public int maxEnemies = 5;

    public List<GameObject> spawnedEnemies = new List<GameObject>();

    private Vector2 startCoordinate = new Vector2(15f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deleteDestroyedEnemies();

        if (spawnedEnemies.Count < maxEnemies) 
        {
            GameObject nextEnemy = stageManager.GetComponent<StageManagerBehaviour>().getNextEnemyIfReady();
            if (nextEnemy != null)
            {
                createNew(nextEnemy);
            }
        }
    }

    private void deleteDestroyedEnemies() 
    {
        List<GameObject> objectsToDelete = new List<GameObject>();
        foreach (GameObject spawnedEnemy in spawnedEnemies) 
        {
            if (spawnedEnemy == null) 
            {
                objectsToDelete.Add(spawnedEnemy);
            }
        }
        foreach (GameObject objectToDelete in objectsToDelete) 
        {
            spawnedEnemies.Remove(objectToDelete);
        }
    }

    private void createNew(GameObject enemyToCreate) 
    {
        GameObject newEnemy = Instantiate(enemyToCreate, startCoordinate, Quaternion.identity);
        spawnedEnemies.Add(newEnemy);
    }
}
