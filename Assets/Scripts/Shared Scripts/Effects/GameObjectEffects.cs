using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectEffects : Effect
{
    public GameObject targetObject;

    void Awake()
    {
        methodArray = GetMethodNames((typeof(TextEffects))).ToArray();
    }

    public void ActivateObject()
    {
        targetObject.SetActive(true);
    }

    public void DeactivateObject()
    {
        targetObject.SetActive(false);
    }

}
