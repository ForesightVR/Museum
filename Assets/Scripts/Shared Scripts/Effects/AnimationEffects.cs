using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEffects : Effect
{
    public Animator animator;
    public string animationName;

    [DisplayIfStringMatch("chosenMethod", "SetBool")]
    public bool animationBool;

    [DisplayIfStringMatch("chosenMethod", "SetInterger")]
    public int animationInt;

    [DisplayIfStringMatch("chosenMethod", "SetFloat")]
    public float animationFloat;

    void Awake()
    {
        methodArray = GetMethodNames((typeof(AnimationEffects))).ToArray();
    }

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
