using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public static PageManager instance;

    public List<GameObject> pages = new List<GameObject>();
    private int pageIndex;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void ChangePage(bool forward)
    {
        if (forward) pageIndex++;
        else pageIndex--;
        for (int i = 0; i < pages.Count; i++)
        {
            if (pageIndex != i) pages[i].SetActive(false);
            else pages[i].SetActive(true);
        }
    }
}
