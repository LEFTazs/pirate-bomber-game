using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManagerBehaviour : MonoBehaviour
{
    public List<GameObject> stages;

    private int currentStage = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < stages.Count; i++)
        {
            stages[i] = Instantiate(stages[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stages[currentStage].GetComponent<Stage>().isDone() && currentStage < stages.Count - 1)
        {
            currentStage++;
        }
    }

    public GameObject getNextEnemyIfReady() 
    {
        return stages[currentStage].GetComponent<Stage>().getNextEnemyIfReady();
    }
}
