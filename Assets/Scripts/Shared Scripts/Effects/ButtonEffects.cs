using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ButtonEffects : Effect
{
    [ValueMatchDisplay("chosenMethod", "TETBUT", true)]
    public GameObject button;

    public float numOfButtons;

    [ValueMatchDisplay("numOfButtons", 1.5f)]
    public GameObject buttons;

    public void ButtonWeeee() { }

    public void BurErfect() { }

    public void TETBUT() { }

    IEnumerator DoCoroutinesWork() { yield return new WaitForSeconds(3.14f); }
}
