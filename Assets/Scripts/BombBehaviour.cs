using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionSound;

    public float damage = 10f;

    public float throwDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Instantiate(explosionSound, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
