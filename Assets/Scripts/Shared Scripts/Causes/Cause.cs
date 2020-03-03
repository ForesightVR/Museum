using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cause : MonoBehaviour
{
    public List<Effect> activateEffects;

    public void ActivateEffects()
    {
        foreach (Effect effect in activateEffects)
            effect?.Invoke(effect.chosenMethod, 0);
    }
}
