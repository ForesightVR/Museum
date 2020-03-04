using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEnterCause : Cause
{
    [TagSelector()]
    public List<string> triggerTags;

    private void OnTriggerEnter(Collider other) // -> cause
    {
        if (triggerTags.Contains(other.tag)) // -> Enum Check
            ActivateEffects();
    }
}
