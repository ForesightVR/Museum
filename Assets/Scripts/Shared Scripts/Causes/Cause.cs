using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cause : MonoBehaviour
{
    public List<Effect> effects;

    public void ActivateEffect()
    {
        foreach (Effect effect in effects)
            effect?.Invoke(effect.chosenMethod, 0);
    }
}
