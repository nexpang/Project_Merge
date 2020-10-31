using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : Singleton<OptionManager>
{
    public GameObject ChangeScroll = null;
    public float V = 0;

    void Update()
    {
        V = ChangeScroll.GetComponent<Slider>().value;
    }
}
