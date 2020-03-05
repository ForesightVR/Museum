using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorEffects : Effect
{
    public GameObject affectedObject;
    
    [ValueMatchDisplay("chosenMethod", new string[] { "ChangeColor", "RepeatColor"})]
    public Color color;  

    public void ChangeColor()
    {
        affectedObject.GetComponent<MeshRenderer>().material.color = color;
        Debug.Log("Color changed");
    }

    public void RepeatColor()
    { }

    public void ColorBlack()
    {
        affectedObject.GetComponent<MeshRenderer>().material.color = Color.black;
        Debug.Log("Color changed");
    }
}
