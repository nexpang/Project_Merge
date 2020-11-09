using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public GameObject MainCamera = null;
    public Scrollbar ChangeScroll;
    public GameObject BlurBlack = null;
    public Slider SoundSlider;

    private bool mouseCheck = false;

    private bool isDrag = false;
    void Start()
    {
        SoundSlider.onValueChanged.AddListener(delegate { MusicValueChangeCheck(); });
        ChangeScroll.onValueChanged.AddListener(delegate { ScrollValueChangeCheck(); }) ;
    }
    private void MusicValueChangeCheck()
    {
        AudioManager.Instance.MusicDefaultSetting = SoundSlider.value;
    }
     private void ScrollValueChangeCheck()
    {
        AudioManager.Instance.MusicDefault = -ChangeScroll.value*0.8f + 1;
      
        BlurBlack.GetComponent<Image>().color = new Color(1, 1, 1, ChangeScroll.value);
        MainCamera.transform.position = new Vector3(ChangeScroll.value * -5, MainCamera.transform.position.y, -10);
    }
    private void Update()
    {
        if (isDrag == false)
        {
            if (ChangeScroll.value >= 0.5)
                ChangeScroll.value = Mathf.Lerp(ChangeScroll.value, 1, Time.deltaTime * 5);
            else
                ChangeScroll.value = Mathf.Lerp(ChangeScroll.value, 0, Time.deltaTime * 5);
        }
    }
    private void LateUpdate()
    {
        if (mouseCheck)
        {
            isDrag = true;
        }
        else
        {
            isDrag = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        mouseCheck = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        mouseCheck = false;
    }
}
