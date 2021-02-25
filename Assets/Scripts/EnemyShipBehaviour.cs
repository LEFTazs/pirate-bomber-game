using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipBehaviour : MonoBehaviour
{
    public GameObject explosion;

    public float health = 100f;
    
    private float currentHealth;
    //private float relativeHeight = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //healthBar = Instantiate(healthBar, gameObject.transform.position + new Vector3(0, relativeHeight, 0), Quaternion.identity);
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {       
        if (currentHealth <= 0) 
        {
            GameObject explosionInstance = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            explosionInstance.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            //Destroy(healthBar);
            Destroy(gameObject);
        } else 
        {
            updateHealthBar();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        currentHealth -= col.gameObject.GetComponent<BombBehaviour>().damage;
    }

    private void updateHealthBar() 
    {
        /*healthBar.transform.position = gameObject.transform.position + new Vector3(0, relativeHeight, 0);
        float healthPercent = currentHealth / health;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.red, healthPercent), new GradientColorKey(Color.white, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, healthPercent), new GradientAlphaKey(1.0f, 1.0f) }
        );
        healthBar.colorGradient = gradient;*/
    }
}
