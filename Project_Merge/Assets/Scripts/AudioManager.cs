using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource ASCatSleep = null;
    public AudioSource ASMouseSqueaky = null;
    public AudioSource ASbuysound = null;

    private void Start()
    {
        ASCatSleep.Play();
    }

    public void FMouseSqueaky()
    {
        ASMouseSqueaky.PlayOneShot(ASMouseSqueaky.clip);
    }
}
