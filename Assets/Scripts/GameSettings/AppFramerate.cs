using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppFramerate : MonoBehaviour
{
    public int framerate = 60;

    void Start()
    {
        Application.targetFrameRate = framerate;
    }

    void Update()
    {
        SetFramerate();
    }

    public void SetFramerate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Application.targetFrameRate = framerate;
        }
    }
}
