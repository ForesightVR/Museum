﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

[ExecuteInEditMode]
public class Effect : MonoBehaviour
{
    [HideInInspector]
    public string[] methodArray;

    [StringSelector("methodArray")]
    public string chosenMethod;

    protected virtual void Awake()
    {
        //methodArray = GetMethodNames(this.GetType()).ToArray();
    }

    private void Update()
    {
        methodArray = GetMethodNames(this.GetType()).ToArray();
    }

    public List<string> GetMethodNames(Type myType)
    {
        List<string> methodNames = new List<string>();
        MethodInfo[] myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        for (int i = 0; i < myArrayMethodInfo.Length; i++)
        {
            MethodInfo myMethodInfo = (MethodInfo)myArrayMethodInfo[i];
            methodNames.Add(myMethodInfo.Name);
        }

        return methodNames;
    }

    /*protected virtual void Awake()
    {
        List<string> methodNames = new List<string>();
        MethodInfo[] myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        for (int i = 0; i < myArrayMethodInfo.Length; i++)
        {
            MethodInfo myMethodInfo = (MethodInfo)myArrayMethodInfo[i];
            methodNames.Add(myMethodInfo.Name);
            print(myMethodInfo.Name);
        }

        methodArray = methodNames.ToArray();

        print(methodArray.Length);
    }*/

    public virtual void InvokeEffect() { }
}
