using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class HoloSceneLoader : MonoBehaviour
{
    public HoloSceneInterface sceneInterface;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Finger"))
            sceneInterface.LoadScene();
    }
}
