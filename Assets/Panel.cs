using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public bool canClick = true;
    public PanelManager panelmanager;

    public void Next()
    {
        if (canClick && GameManager.instance.canProgress)
        {
            canClick = false;
            panelmanager.NextPanel();
        }
    }
}
