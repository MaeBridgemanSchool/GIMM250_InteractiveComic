using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionManager : MonoBehaviour
{

    private GameManager gm;
    public PanelManager panelManager;
    public int numberRequired = 3;
    public int numberMatched = 0;
    public UnityEvent otherEvents;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void NewMatch()
    {
        numberMatched++;

        if (numberMatched >= numberRequired)
        {
            Complete();
        }
    }

    public void Complete()
    {
        //GameManager.instance.SceneTransition();
        panelManager.NextPanel();
        otherEvents.Invoke();
        //gm._NextStage();
    }
}
