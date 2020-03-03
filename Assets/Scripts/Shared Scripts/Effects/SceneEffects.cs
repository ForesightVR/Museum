using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SceneEffects : Effect
{
    public SteamVR_LoadLevel sceneLoader;
    public string sceneName;

    void Awake()
    {
        methodArray = GetMethodNames((typeof(SceneEffects))).ToArray();
    }

    public void LoadScene()
    {
        if (sceneLoader == null)
            sceneLoader = GameObject.FindObjectOfType<SteamVR_LoadLevel>();

        if (sceneName != "")
        {
            sceneLoader.levelName = sceneName;
            sceneLoader.Trigger();
            transform.root.position = Vector3.zero;
        }
    }
}

