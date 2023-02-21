using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public class Stage
{
    public string name;
    [TextArea]
    public string note;

    [Header("The events called when the stage begins.")]
    public UnityEvent events;
}

[Serializable]
public class Objects
{
    public GameObject[] startEnabledObjects;
    public GameObject[] startDisabledObjects;
}

public class GameManager : MonoBehaviour
{
    #region Environment
    [ContextMenu("Reset Environment")]
    public void ResetEnvironment()
    {
        foreach (GameObject go in objects.startEnabledObjects)
        {
            go.SetActive(true);
        }
        foreach (GameObject go in objects.startDisabledObjects)
        {
            go.SetActive(false);
        }
    }

    public Objects objects;
    #endregion

    public List<Stage> stages = new List<Stage>();
    private int stageIndex = 0;

    public void _NextStage()
    {
        stageIndex++;
        Stage stage = stages[stageIndex];

        Debug.Log("Moved to stage " + stageIndex);

        stage.events.Invoke();
    }

    public void _EnableObject(GameObject obj)
    {
        obj.SetActive(true);
        Debug.Log("Stage " + stageIndex + ". Enabled object: " + obj);
    }
    public void _DisableObject(GameObject obj)
    {
        obj.SetActive(false);
        Debug.Log("Stage " + stageIndex + ". Disabled object: " + obj);
    }
    public void _PlayAnimation(Animation anim)
    {
        anim.Play();
        Debug.Log("Stage " + stageIndex + ". Animation played: " + anim);
    }

    void Start()
    {
        ResetEnvironment();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
