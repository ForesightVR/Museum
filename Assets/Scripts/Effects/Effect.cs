using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

[ExecuteInEditMode]
public class Effect : MonoBehaviour
{
    public Effect[] effects;
    public enum EffectTypes { };

    EffectTypes effectType;

    public string[] methodNames = { "name", "anotherName", "oneMoreName"};

    protected virtual void Awake()
    {



        Type myType = (typeof(ButtonEffects));
        MethodInfo[] myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        for (int i = 0; i < myArrayMethodInfo.Length; i++)
        {
            MethodInfo myMethodInfo = (MethodInfo)myArrayMethodInfo[i];
           // effectType = methodNames;

           // methodNames.Add(myMethodInfo.Name);
        }

    }

    public virtual void InvokeEffect() { }
}
