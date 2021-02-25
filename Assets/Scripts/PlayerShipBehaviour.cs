using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipBehaviour : MonoBehaviour
{
    public GameObject explosion;

    public int lives = 3;
    
    public int currentLives;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = lives;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLives <= 0)
        {
            GameObject explosionInstance = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            explosionInstance.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

            Application.Quit();  // TODO: gameover screen
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject explosionInstance = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        explosionInstance.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

        currentLives--;
    }
}
