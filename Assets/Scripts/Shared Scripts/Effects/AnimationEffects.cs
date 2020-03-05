using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEffects : Effect
{
    public Animator animator;
    public string animationName;

    [ValueMatchDisplay("chosenMethod", "SetBool")]
    public bool animationBool;

    [ValueMatchDisplay("chosenMethod", "SetInterger")]
    public int animationInt;

    [ValueMatchDisplay("chosenMethod", "SetFloat")]
    public float animationFloat;

    public void SetTrigger()
    {
        animator.SetTrigger(animationName);
    }

    public void SetBool()
    {
        animator.SetBool(animationName, animationBool);
    }

    public void SetInterger()
    {
        animator.SetInteger(animationName, animationInt);
    }

    public void SetFloat()
    {
        animator.SetFloat(animationName, animationFloat);
    }
}
