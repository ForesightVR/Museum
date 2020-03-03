using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryCause : Cause
{
    public List<Effect> deactivateEffects;
    public void DeactivateEffects()
    {
        foreach (Effect effect in deactivateEffects)
            effect?.Invoke(effect.chosenMethod, 0);
    }
}
