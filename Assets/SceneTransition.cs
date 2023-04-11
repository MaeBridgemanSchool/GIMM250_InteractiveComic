using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{

    private bool transitioned = false;

    public void Change()
    {
        if (transitioned == false)
        {
            GameManager.instance.SceneTransition();
            transitioned = true;
        }
        else ChangePage();
    }

    public void ChangePage()
    {
        PageManager.instance.ChangePage(true);
    }
}
