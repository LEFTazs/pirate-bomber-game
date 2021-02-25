using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject playerShip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int score = playerShip.GetComponent<PlayerShipBehaviour>().score;
        GetComponent<Text>().text = "Score: " + score.ToString();
    }
}
