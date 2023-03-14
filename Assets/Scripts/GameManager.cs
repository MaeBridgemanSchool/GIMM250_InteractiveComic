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
public class Scene
{
    public string postProcessing;
    public Sprite map;
}

[Serializable]
public class PostProcessing
{
    public GameObject sadPostProcessing;
    public GameObject neutralPostProcessing;
    public GameObject happyPostProcessing;
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

    public List<Scene> scenes = new List<Scene>();
    private int sceneIndex = 0;

    public PostProcessing postProcessing;

    [Serializable]
    public struct Song
    {
        public string name;
        public AudioClip audio;
    }
    public Song[] music;

    public static GameManager instance;
    public Animator transition;
    public SpriteRenderer mapSprite;

    public void Start()
    {
        instance = this;
        ResetEnvironment();
    }

    public void _ChangeMusic(string s)
    {
        foreach(Song song in music)
        {
            if (song.name == s)
            {
                GetComponent<AudioSource>().clip = song.audio;
            }
        }
    }

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

    public void _ChangePostProcessing(string newState)
    {
        if (newState == "Happy")
        {
            postProcessing.happyPostProcessing.SetActive(true);
            postProcessing.neutralPostProcessing.SetActive(false);
            postProcessing.sadPostProcessing.SetActive(false);
        }
        else if (newState == "Sad")
        {
            postProcessing.happyPostProcessing.SetActive(false);
            postProcessing.neutralPostProcessing.SetActive(false);
            postProcessing.sadPostProcessing.SetActive(true);
        }
        else if (newState == "Neutral")
        {
            postProcessing.happyPostProcessing.SetActive(false);
            postProcessing.neutralPostProcessing.SetActive(true);
            postProcessing.sadPostProcessing.SetActive(false);
        }
    }

    public void SceneTransition()
    {
        sceneIndex++;
        transition.SetTrigger("StartTransition");
    }

    public void TransitionReported()
    {
        //Make changes
        Scene newScene = scenes[sceneIndex];
        _ChangePostProcessing(newScene.postProcessing);
        mapSprite.sprite = newScene.map;
    }
}
