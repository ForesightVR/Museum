using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorEffects : Effect
{
    [DisplayIfStringMatch("chosenMethod", "ChangeColor")]
    public Color color;
    [DisplayIfStringMatch("chosenMethod", "ChangeColor")]
    public GameObject affectedObject;

    void Awake()
    {
        methodArray = GetMethodNames((typeof(ColorEffects))).ToArray();
    }

    public void ChangeColor()
    {
        affectedObject.GetComponent<MeshRenderer>().material.color = color;
        Debug.Log("Color changed");
    }

    public void ColorBlack()
    {
        affectedObject.GetComponent<MeshRenderer>().material.color = Color.black;
        Debug.Log("Color changed");
    }
}
