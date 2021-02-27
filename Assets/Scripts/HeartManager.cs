using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public GameObject playerShip;
    public Image oneHeart;

    private List<Image> hearts = new List<Image>();

    private int lastLive;

    // Start is called before the first frame update
    void Start()
    {
        lastLive = playerShip.GetComponent<PlayerShipBehaviour>().lives;
        for (int i = 0; i < lastLive; i++) 
        {
            Image heart = Instantiate(oneHeart);
            heart.transform.SetParent(transform, false);
            hearts.Add(heart);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lastLive > 0) 
        {
            int currentLive = playerShip.GetComponent<PlayerShipBehaviour>().currentLives;
            if (lastLive > currentLive)
            {
                Destroy(hearts[lastLive-1]);
                lastLive = currentLive;
            }
        }
    }
}
