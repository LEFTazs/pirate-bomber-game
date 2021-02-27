using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipBehaviour : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerShip;

    public float health = 100f;
    public float speed = 5f;
    public int scoreValue = 100;
    
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {       
        if (currentHealth <= 0) 
        {
            GameObject explosionInstance = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            explosionInstance.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

            playerShip.GetComponent<PlayerShipBehaviour>().score += 100;
            
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.gameObject.tag == "bomb") 
        {
            currentHealth -= col.gameObject.GetComponent<BombBehaviour>().damage;
        } else 
        {
            currentHealth = 0;
        }
    }
}
