using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[ExecuteInEditMode]
public class ButtonEffects : Effect
{
    void Awake()
    {
        methodArray = GetMethodNames((typeof(ButtonEffects))).ToArray();
    }

    IEnumerator DoCoroutinesWork() { yield return new WaitForSeconds(3.14f); }
}
