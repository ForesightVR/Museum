using UnityEngine;

public class SoundEffects : Effect
{
    public AudioSource source;
    public AudioClip clip;

    void Awake()
    {
        methodArray = GetMethodNames((typeof(SoundEffects))).ToArray();
    }

    public void PlayClip()
    {
        source.PlayOneShot(clip);
    }
}
