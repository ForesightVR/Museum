using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(Effect))]
public class EffectEditor : Editor
{
    void OnGUI()
    {
        Effect effect = (Effect)base.target;
        EditorGUILayout.Popup(0, effect.methodNames);
    }
}
