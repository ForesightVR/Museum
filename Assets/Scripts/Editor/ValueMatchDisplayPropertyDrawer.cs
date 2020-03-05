using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

[CustomPropertyDrawer(typeof(ValueMatchDisplayAttribute))]
public class ValueMatchDisplayPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {       
        var attrib = this.attribute as ValueMatchDisplayAttribute;
        bool enabled = CheckIfValueMatches(attrib, property);

        bool wasEnabled = GUI.enabled;
        GUI.enabled = enabled;
        
        if (enabled)
        {
            EditorGUI.PropertyField(position, property, label, true);
        }

        GUI.enabled = wasEnabled;        
    }
    /// <summary>
    /// Changes the size of the editor window to allow the variable to be displayed
    /// </summary>
    /// <param name="property"></param>
    /// <param name="label"></param>
    /// <returns></returns>
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ValueMatchDisplayAttribute condHAtt = (ValueMatchDisplayAttribute)attribute;
        bool enabled = CheckIfValueMatches(condHAtt, property);

        if (enabled)
        {
            return EditorGUI.GetPropertyHeight(property, label);
        }
        else
        {
            //The property is not being drawn
            //We want to undo the spacing added before and after the property
            return -EditorGUIUtility.standardVerticalSpacing;
            //return 0.0f;
        }
    }

    //If true, the variable appears. If false, the variable doesn't appear.
    bool CheckIfValueMatches(ValueMatchDisplayAttribute att, SerializedProperty property)
    {
        string propertyPath = property.propertyPath; //returns the property path of the property we want to apply the attribute to
        string conditionPath = propertyPath.Replace(property.name, att.stringVariableName); //changes the path to the conditionalsource property path
        SerializedProperty sp = property.serializedObject.FindProperty(conditionPath); // this returns the serialzed property that matches the one in the attribute

        //return sp.stringValue == att.matchingValue;

        //return att.matchingValues.(sp.stringValue);

        bool doesMatch = CheckPropertyMatches(att, sp);

        return (att.inverse) ? !doesMatch : doesMatch;
    }

    private bool CheckPropertyMatches(ValueMatchDisplayAttribute att, SerializedProperty sp)
    {
        //Note: add others for custom handling if desired
        switch (sp.propertyType)
        {
            case SerializedPropertyType.Integer:
                return Array.Exists(att.matchingIntValues, x => x == sp.intValue);
            case SerializedPropertyType.String:
                return Array.Exists(att.matchingStringValues, x => x == sp.stringValue);
            case SerializedPropertyType.Float:
                return Array.Exists(att.matchingFloatValues, x => x == sp.floatValue);
            default:
                Debug.LogError("Data type of the property used for conditional hiding [" + sp.propertyType + "] is currently not supported");
                return true;
        }
    }
}
