using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerShipBehaviour : MonoBehaviour
{
    public GameObject explosion;

    public int lives = 3;
    
    public int currentLives;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = lives;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLives <= 0)
        {
            GameObject explosionInstance = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            explosionInstance.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject explosionInstance = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        explosionInstance.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

        currentLives--;
    }
}
