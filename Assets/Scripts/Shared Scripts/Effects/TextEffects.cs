using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEffects : Effect
{
    public TextMeshProUGUI textbox;
    [TextArea]
    public string text;

    void Awake()
    {
        methodArray = GetMethodNames((typeof(TextEffects))).ToArray();
    }

    public void SetText()
    {
        textbox.text = text;
    }
}
