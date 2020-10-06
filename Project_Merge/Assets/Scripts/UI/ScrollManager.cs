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
    void Start()
    {
        
    }

    void Update()
    {
         ScrollStat = GameObject.Find("체인쥐Scroll").GetComponent<Scrollbar>().value;

        if (isDrag == false)
        {
            if (GameObject.Find("체인쥐Scroll").GetComponent<Scrollbar>().value >= 0.5)
                GameObject.Find("체인쥐Scroll").GetComponent<Scrollbar>().value = Mathf.Lerp(ScrollStat, 1, Time.deltaTime * 5);
            else
                GameObject.Find("체인쥐Scroll").GetComponent<Scrollbar>().value = Mathf.Lerp(ScrollStat, 0, Time.deltaTime * 5);
        }

        MainCamera.transform.position = new Vector3(GameObject.Find("체인쥐Scroll").GetComponent<Scrollbar>().value * -5, MainCamera.transform.position.y, -10);
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
