using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputController : MonoBehaviour
{
    public GameObject bomb;
    public Camera sceneCamera;
    public GameObject ship;

    private Vector2 startPosition;
    private float lastThrowTime = 0;

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
            float throwDelay = bomb.GetComponent<BombBehaviour>().throwDelay;
            if (Time.time - lastThrowTime > throwDelay)
            {
                throwBomb();
                lastThrowTime = Time.time;
            }
        }
    }

    private void throwBomb()
    {
        GameObject newBomb = Instantiate(bomb, startPosition, Quaternion.identity);
        newBomb.GetComponent<Projectile>().targetPos = sceneCamera.ScreenToWorldPoint(Input.mousePosition);

        Physics2D.IgnoreCollision(newBomb.GetComponent<CircleCollider2D>(), ship.GetComponent<BoxCollider2D>(), true);
    }
}
