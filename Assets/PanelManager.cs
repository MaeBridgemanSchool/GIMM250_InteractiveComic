using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public int panelIndex = 0;
    public List<GameObject> panels = new List<GameObject>();

    public void Start()
    {
        for (int i = 1; i < panels.Count; i++)
        {
            panels[i].SetActive(false);
        }
    }

    public void NextPanel()
    {
        GameManager.instance._NextStage();

        panelIndex++;

        panels[panelIndex].SetActive(true);

    }
}
