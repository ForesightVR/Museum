using UnityEngine;

public class SoundEffects : Effect
{
    public AudioSource source;
    public AudioClip clip;

    public void PlayClip()
    {
        source.PlayOneShot(clip);
    }
}
