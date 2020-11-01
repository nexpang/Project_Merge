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
    public Scrollbar ChangeScroll;
    public GameObject BlurBlack = null;
    public Slider SoundSlider;

    void Start()
    {
        SoundSlider.onValueChanged.AddListener(delegate { MusicValueChangeCheck(); });
        ChangeScroll.onValueChanged.AddListener(delegate { ScrollValueChangeCheck(); }) ;
    }
    private void MusicValueChangeCheck()
    {
        if (ChangeScroll.value >= 0.5f)
        {
            AudioManager.Instance.ASCatSleep.volume = SoundSlider.value;
            AudioManager.Instance.MusicDefault.volume = ChangeScroll.value;
        }
        else
        {
            AudioManager.Instance.ASCatSleep.volume = 0;
            AudioManager.Instance.MusicDefault.volume = SoundSlider.value;
        }
        BlurBlack.GetComponent<Image>().color = new Color(1, 1, 1, ChangeScroll.value);
        MainCamera.transform.position = new Vector3(ChangeScroll.value * -5, MainCamera.transform.position.y, -10);
    }
     private void ScrollValueChangeCheck()
    {
        if (ChangeScroll.value >= 0.5f)
        {
            AudioManager.Instance.ASCatSleep.volume = SoundSlider.value;
            AudioManager.Instance.MusicDefault.volume = SoundSlider.value * -0.7f;
        }
        else
        {
            AudioManager.Instance.ASCatSleep.volume = 0;
            AudioManager.Instance.MusicDefault.volume = SoundSlider.value;
        }
        /*if (ChangeScroll.value >= 0.5)
            ChangeScroll.value = Mathf.Lerp(ChangeScroll.value, 1, Time.deltaTime * 5);
        else
            ChangeScroll.value = Mathf.Lerp(ChangeScroll.value, 0, Time.deltaTime * 5);*/
        BlurBlack.GetComponent<Image>().color = new Color(1, 1, 1, ChangeScroll.value);
        MainCamera.transform.position = new Vector3(ChangeScroll.value * -5, MainCamera.transform.position.y, -10);
    }


}
