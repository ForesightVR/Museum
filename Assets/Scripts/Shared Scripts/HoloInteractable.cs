using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloInteractable : Interactable
{
    public GameObject hologram;
    public GameObject hologramProjector;
    public Animator animator;

    public AudioClip onSound;
    public AudioClip offSound;

    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public override void Interacting()
    {
        if (!hologram.activeInHierarchy)
        {
            source.PlayOneShot(onSound);
            hologram.gameObject.SetActive(true);
            hologramProjector.SetActive(true);
            animator.SetTrigger("ScaleUp");
        }
    }

    public override void StoppedInteracting()
    {
        if (hologram.activeInHierarchy)
        {
            source.PlayOneShot(offSound);
            animator.SetTrigger("ScaleDown");
            hologramProjector.SetActive(false);
        }
    }
}
