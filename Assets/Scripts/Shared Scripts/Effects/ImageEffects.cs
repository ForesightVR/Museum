using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageEffects : Effect
{
    public Image image;
    public Sprite sprite;

    void Awake()
    {
        methodArray = GetMethodNames((typeof(ImageEffects))).ToArray();
    }

    public void SetImage()
    {
        image.sprite = sprite;
    }
}
