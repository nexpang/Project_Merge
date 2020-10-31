using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour
{
    float ScrollStat;
    float SoundStat;
    public GameObject MainCamera = null;
    public GameObject ChangeScroll = null;
    public GameObject BlurBlack = null;
    void Start()
    {
        
    }

    void Update()
    {
        ScrollStat = ChangeScroll.GetComponent<Scrollbar>().value;
        SoundStat = OptionManager.Instance.V;

            if (ScrollStat >= 0.5)
                ScrollStat = Mathf.Lerp(ScrollStat, 1, Time.deltaTime * 5);
            else
                ScrollStat = Mathf.Lerp(ScrollStat, 0, Time.deltaTime * 5);

        BlurBlack.GetComponent<Image>().color = new Color(1, 1, 1, ScrollStat);
        MainCamera.transform.position = new Vector3( ChangeScroll.GetComponent<Scrollbar>().value * -5, MainCamera.transform.position.y, -10);


        if (ScrollStat >= 0.5f) 
        { 
            AudioManager.Instance.ASCatSleep.volume = SoundStat;
            AudioManager.Instance.MusicDefault.volume = SoundStat * -0.7f; 
        }
        else
        {
            AudioManager.Instance.ASCatSleep.volume = 0;
            AudioManager.Instance.MusicDefault.volume = SoundStat;
        }

    }


}
