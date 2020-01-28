using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloSceneButton : MonoBehaviour
{
    public HoloSceneInterface sceneInterface;
    public Sprite logo;
    [TextArea]
    public string description;
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Finger"))
            sceneInterface.SetInfo(logo, description, sceneName);
    }
}
