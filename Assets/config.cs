using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class config : MonoBehaviour
{
    public int targetFrameRate = 60;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }
}
