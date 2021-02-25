using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void restartGame() {
        SceneManager.LoadScene("SeaPlayScene", LoadSceneMode.Single);
    }

    public void goToMenu() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
