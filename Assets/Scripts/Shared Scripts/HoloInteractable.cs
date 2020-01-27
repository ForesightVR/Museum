using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloInteractable : Interactable
{
    public GameObject hologram;
    public GameObject hologramProjector;
    public Animator animator;

    public override void Interacting()
    {
        if (!hologram.activeInHierarchy)
        {
            hologram.gameObject.SetActive(true);
            hologramProjector.SetActive(true);
            animator.SetTrigger("ScaleUp");
        }
    }

    public override void StoppedInteracting()
    {
        if (hologram.activeInHierarchy)
        {
            animator.SetTrigger("ScaleDown");
            hologramProjector.SetActive(false);
        }
    }
}
