using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour
{
    float ScrollStat;
    bool isDrag = false;
    public GameObject MainCamera = null;
    public GameObject ChangeScroll = null;
    public GameObject BlurBlack = null;
    void Start()
    {
        
    }

    void Update()
    {
         ScrollStat = ChangeScroll.GetComponent<Scrollbar>().value;

        if (isDrag == false)
        {
            if (ChangeScroll.GetComponent<Scrollbar>().value >= 0.5)
                ChangeScroll.GetComponent<Scrollbar>().value = Mathf.Lerp(ScrollStat, 1, Time.deltaTime * 5);
            else
                ChangeScroll.GetComponent<Scrollbar>().value = Mathf.Lerp(ScrollStat, 0, Time.deltaTime * 5);
        }

        BlurBlack.GetComponent<Image>().color = new Color(1, 1, 1, ChangeScroll.GetComponent<Scrollbar>().value);
        MainCamera.transform.position = new Vector3(ChangeScroll.GetComponent<Scrollbar>().value * -5, MainCamera.transform.position.y, -10);


        AudioManager.Instance.ASCatSleep.volume = ChangeScroll.GetComponent<Scrollbar>().value;
        AudioManager.Instance.MusicDefault.volume = ChangeScroll.GetComponent<Scrollbar>().value * -0.7f + 1f;
    }

    private void OnMouseDrag()
    {
        isDrag = true;
    }

    private void OnMouseUp()
    {
        isDrag = false;
    }
}
