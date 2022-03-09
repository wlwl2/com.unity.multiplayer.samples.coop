using System;
using UnityEngine;

public class DisableConsole : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.developerConsoleVisible = false;
    }
}
