using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An attribute that checks if the provided string value matches the named variable. If it is true, the variable this attribute is over will appear in the Unity Editor.
/// </summary>
public class ValueMatchDisplayAttribute : PropertyAttribute
{
    public string stringVariableName;
    public string[] matchingStringValues;
    public int[] matchingIntValues;
    public float[] matchingFloatValues;
    public bool inverse;

    /// <summary>
    /// A constructor that sets the variable you are checking and the value you want it to be.
    /// </summary>
    /// <param name="variableName">
    /// The name of the variable you are checking for its value.
    /// </param>
    /// <param name="matchingValue">
    /// If the variable in the first parameter matches this value, the variable that this attribute is on will appear.
    /// </param>
    public ValueMatchDisplayAttribute(string variableName, string matchingValue, bool isInverse = false)
    {
        this.stringVariableName = variableName;
        this.matchingStringValues = new string[] { matchingValue };
        this.inverse = isInverse;
    }

    public ValueMatchDisplayAttribute(string variableName, string[] matchingValues, bool isInverse = false)
    {
        this.stringVariableName = variableName;
        this.matchingStringValues = matchingValues;
        this.inverse = isInverse;
    }

    public ValueMatchDisplayAttribute(string variableName, int matchingValue, bool isInverse = false)
    {
        this.stringVariableName = variableName;
        this.matchingIntValues = new int[] { matchingValue };
        this.inverse = isInverse;
    }

    public ValueMatchDisplayAttribute(string variableName, int[] matchingValues, bool isInverse = false)
    {
        this.stringVariableName = variableName;
        this.matchingIntValues = matchingValues;
        this.inverse = isInverse;
    }

    public ValueMatchDisplayAttribute(string variableName, float matchingValue, bool isInverse = false)
    {
        this.stringVariableName = variableName;
        this.matchingFloatValues = new float[] { matchingValue };
        this.inverse = isInverse;
    }

    public ValueMatchDisplayAttribute(string variableName, float[] matchingValues, bool isInverse = false)
    {
        this.stringVariableName = variableName;
        this.matchingFloatValues = matchingValues;
        this.inverse = isInverse;
    }
}
