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
        {
            ActivateEffect();

            //source.PlayOneShot(buttonSound); // -> in the inspector
            //animator.SetTrigger("Pressed");
            //player.rightHand.TriggerHapticPulse(500);

            //sceneInterface.SetInfo(logo, description, sceneName); // -> also in the inspector
        }
    }
}
