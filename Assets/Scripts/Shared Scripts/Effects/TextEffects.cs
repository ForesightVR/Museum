using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEffects : Effect
{
    public TextMeshProUGUI textbox;
    [TextArea]
    public string text;

    public void SetText()
    {
        textbox.text = text;
    }
}
