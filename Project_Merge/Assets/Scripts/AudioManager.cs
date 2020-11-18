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
    public float SFXDefault = 1;
    public float SFXDefaultSetting = 1;

    public AudioSource MusicDefaultTotal = null;
    public AudioSource MusicFever = null;

    [SerializeField]
    private AudioSource[] Sfx = null;
    private void Start()
    {
        ASCatSleep.Play();
    }

    private void Update()
    {
        MusicDefaultTotal.volume = MusicDefault * MusicDefaultSetting;
        MusicFever.volume = MusicDefault * MusicDefaultSetting;

        for (int i = 0; i < Sfx.Length; i++)
        {
            Sfx[i].volume = SFXDefault * SFXDefaultSetting;
        }
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
