using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaFloater : MonoBehaviour
{
    public GameObject playerShip;
    public GameObject enemySpawner;
    public LineRenderer seaLine;
    
    private float originalHeight = -3f;
    private float lineWidth = 2f;

    private float tick = 0;

    void Start()
    {
        seaLine = Instantiate(seaLine, Vector2.zero, Quaternion.identity);
        seaLine.startWidth = lineWidth;
        seaLine.endWidth = lineWidth;
    }
    void Update()
    {
        tick += 0.01f;
        
        Vector2 newPositionForPlayer = getNewPositionForGameObject(playerShip, originalHeight);
        Quaternion newDirectionForPlayer = getNewDirectionForGameObject(playerShip);
        playerShip.transform.SetPositionAndRotation(newPositionForPlayer, newDirectionForPlayer);

        foreach (GameObject enemyShip in enemySpawner.GetComponent<EnemySpawner>().spawnedEnemies) 
        {
            Vector2 newPositionForEnemy = getNewPositionForGameObject(enemyShip, originalHeight);
            float speed = enemyShip.GetComponent<EnemyShipBehaviour>().speed;
            newPositionForEnemy.x -= speed * Time.deltaTime;
            Quaternion newDirectionForEnemy = getNewDirectionForGameObject(enemyShip);
            enemyShip.transform.SetPositionAndRotation(newPositionForEnemy, newDirectionForEnemy);
        }

        Vector3[] samplePoints = generateSeaLineSamplePoints(originalHeight);
        seaLine.positionCount = samplePoints.Length;
        seaLine.SetPositions(samplePoints);
    }

    private Vector2 getNewPositionForGameObject(GameObject gameObject, float originalHeight) 
    {
        float currentHeight = getHeightForPoint(gameObject.transform.position.x); // or Time.time?

        Vector2 newPosition = gameObject.transform.position;
        newPosition.y = originalHeight + currentHeight;
        return newPosition;
    }

    private Quaternion getNewDirectionForGameObject(GameObject gameObject) 
    {
        float currentDirection = getDirectionForPoint(gameObject.transform.position.x);
        return Quaternion.Euler(1, 1, currentDirection*180.0f/Mathf.PI);
    }

    private Vector3[] generateSeaLineSamplePoints(float originalHeight) 
    {
        List<Vector3> samplePoints = new List<Vector3>();
        float leftBound = -15f;
        float rightBound = 15f;
        float wholeSize = Mathf.Abs(rightBound) + Mathf.Abs(leftBound);
        int sampleSize = 1000;
        for (float samplePosition = leftBound; samplePosition < rightBound; samplePosition+=(wholeSize/sampleSize)) {
            float sampleValue = getHeightForPoint(samplePosition);
            Vector3 samplePoint = new Vector3(samplePosition, originalHeight + sampleValue - lineWidth/2.5f, 0f);
            samplePoints.Add(samplePoint);
        }
        return samplePoints.ToArray();
    }

    private float getHeightForPoint(float position) 
    {
        return Mathf.Cos(position + tick) / 2;
    }

    private float getDirectionForPoint(float position) 
    {
        return -Mathf.Sin(position + tick) / 5;
    }
}
