using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxSwitcher : MonoBehaviour
{
    public Material[] skyboxes;

    int index;
    bool nextPressed;
    bool previousPressed;


    private void Update()
    {
        if (!nextPressed && (OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Three)))
        {
            nextPressed = true;
            Next();
        }
        else if (!OVRInput.Get(OVRInput.Button.One) && !OVRInput.Get(OVRInput.Button.Three))
            nextPressed = false;

        if (!previousPressed && (OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.Button.Four)))
        {
            previousPressed = true;
            Previous();
        }
        else if (!OVRInput.Get(OVRInput.Button.Two) && !OVRInput.Get(OVRInput.Button.Four))
            previousPressed = false;
    }

    void Next()
    {
        if (index + 1 >= skyboxes.Length)
            index = 0;
        else
            index++;

        RenderSettings.skybox = skyboxes[index];
    }

    void Previous()
    {
        if (index - 1 < 0)
            index = skyboxes.Length - 1;
        else
            index--;

        RenderSettings.skybox = skyboxes[index];
    }
}
