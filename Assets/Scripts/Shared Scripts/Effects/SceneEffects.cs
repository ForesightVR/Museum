using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SceneEffects : Effect
{
    public string sceneName;
    SteamVR_LoadLevel sceneLoader;

    void Awake()
    {
        methodArray = GetMethodNames((typeof(SceneEffects))).ToArray();
    }

    public void SetScene()
    {
        if (sceneLoader == null)
            sceneLoader = GameObject.FindObjectOfType<SteamVR_LoadLevel>();

        if (sceneName != "")
            sceneLoader.levelName = sceneName;

        Debug.Log("Setting Scene");
    }

    public void LoadScene()
    {
        if (sceneLoader == null)
            sceneLoader = GameObject.FindObjectOfType<SteamVR_LoadLevel>();

        Debug.Log("Scene: " + sceneLoader.levelName);
        if (sceneLoader.levelName != "")
        {
            sceneLoader.Trigger();
            transform.root.position = Vector3.zero;
        }
    }
}

