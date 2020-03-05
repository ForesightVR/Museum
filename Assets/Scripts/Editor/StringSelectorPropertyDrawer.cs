using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomPropertyDrawer(typeof(StringSelectorAttribute))]
public class StringSelectorPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.String) /// if the variable you're setting isn't a string, this doesn't work
        {
            EditorGUI.BeginProperty(position, label, property);

            var attrib = this.attribute as StringSelectorAttribute;

            string propertyPath = property.propertyPath; //returns the property path of the property we want to apply the attribute to
            string conditionPath = propertyPath.Replace(property.name, attrib.stringDropDownName); //changes the path to the conditionalsource property path
            SerializedProperty sp = property.serializedObject.FindProperty(conditionPath); // this returns the serialzed property that matches the one in the attribute

            List<string> stringList = new List<string>();

            if (sp.isArray) //checks if the variable to be converted into the drop down is indeed an array
            {
                sp.Next(true); // skip generic field
                sp.Next(true); // advance to array size field

                // Get the array size
                int arrayLength = sp.intValue;
                sp.Next(true); // advance to first array index

                int lastIndex = arrayLength - 1;
                for (int i = 0; i < arrayLength; i++)
                {
                    stringList.Add(sp.stringValue); // copy the value to the list
                    if (i < lastIndex) sp.Next(false); // advance without drilling into children
                }
            }

            //check if there is an entry that matches the entry and get the index
            int index = stringList.IndexOf(property.stringValue);

            //Draw the popup box with the current selected index
            index = EditorGUI.Popup(position, label.text, index, stringList.ToArray());

            //if nothing is selected, defaults them to the first option
            property.stringValue = (index == -1) ? stringList[0] : stringList[index];
        }

        EditorGUI.EndProperty();   
    }
}
