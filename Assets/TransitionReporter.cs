using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionReporter : MonoBehaviour
{
    public void Report()
    {
        GameManager.instance.TransitionReported();
    }
}
