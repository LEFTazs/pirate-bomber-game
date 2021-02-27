﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputController : MonoBehaviour
{
    public GameObject bomb;
    public Camera sceneCamera;
    public GameObject ship;
    private Vector2 startPosition;


    void Start()
    {
        startPosition = ship.transform.position;
        startPosition.y += 1f;
    }

    void Update()
    {
        float shipRightSide = ship.transform.position.x + ship.GetComponent<BoxCollider2D>().offset.x + ship.GetComponent<BoxCollider2D>().size.x * ship.transform.localScale.x / 2;
        if (Input.GetMouseButtonDown(0) && sceneCamera.ScreenToWorldPoint(Input.mousePosition).x > shipRightSide) 
        {
            GameObject newBomb = Instantiate(bomb, startPosition, Quaternion.identity);
            newBomb.GetComponent<Projectile>().targetPos = sceneCamera.ScreenToWorldPoint(Input.mousePosition);

            Physics2D.IgnoreCollision(newBomb.GetComponent<CircleCollider2D>(), ship.GetComponent<BoxCollider2D>(), true);
        }
    }

    private Vector2 getClickPositionRelativeTo(Vector2 position) 
    {
            Vector2 forceDirection = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
            forceDirection.x -= position.x;
            forceDirection.y -= position.y;
            return forceDirection;
    }

    private void sendBombFlyingFromTo(Vector2 from, Vector2 to) 
    {
            GameObject newBomb = Instantiate(bomb, from, Quaternion.identity);
            Physics2D.IgnoreCollision(newBomb.GetComponent<CircleCollider2D>(), ship.GetComponent<BoxCollider2D>(), true);
            Rigidbody2D rigidBody = newBomb.GetComponent<Rigidbody2D>(); 
            rigidBody.AddForce(to*100);
    }
}
