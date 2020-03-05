using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectEffects : Effect
{
    public GameObject[] targetObjects;
    public void ActivateObject()
    {
        foreach(GameObject go in targetObjects)
            go.SetActive(true);
    }

    public void DeactivateObject()
    {
        foreach (GameObject go in targetObjects)
            go.SetActive(false);
    }

}
