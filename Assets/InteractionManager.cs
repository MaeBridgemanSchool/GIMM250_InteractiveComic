using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{

    private GameManager gm;
    public int numberRequired = 3;
    public int numberMatched = 0;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void NewMatch()
    {
        numberMatched++;

        if (numberMatched >= numberRequired)
        {
            gm._NextStage();
        }
    }
}
