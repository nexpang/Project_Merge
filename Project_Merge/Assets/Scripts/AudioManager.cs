using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource ASCatSleep = null;
    public AudioSource ASMouseSqueaky = null;
    public AudioSource ASbuysound = null;
    public AudioSource ASButtonClick = null;
    public AudioSource ASCatClick = null;
    public AudioSource ASBuyFail = null;

    public float MusicDefault = 1;
    public float MusicDefaultSetting = 1;

    public AudioSource MusicDefaultTotal = null;

    private void Start()
    {
        ASCatSleep.Play();
    }

    private void Update()
    {
        MusicDefaultTotal.volume = MusicDefault * MusicDefaultSetting;
    }
    public void FMouseSqueaky()
    {
        ASMouseSqueaky.PlayOneShot(ASMouseSqueaky.clip);
    }

    public void FCatClick()
    {
        ASCatClick.PlayOneShot(ASCatClick.clip);
    }

    public void FBuySound()
    {
        ASbuysound.PlayOneShot(ASbuysound.clip);
    }
}
