﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseBookTap : Singleton<MouseBookTap>
{
    public int tapId = 0;
    public bool isLock = true;


    public void TabClick()
    {
        AudioManager.Instance.ASButtonClick.Play();

        if (UIManager.Instance.MouseBookDesc.activeSelf)
        {
            UIManager.Instance.MouseBookDesc.SetActive(false);
            if (!UIManager.Instance.MouseBook.activeSelf)
                UIManager.Instance.isUIon = false;
        }
        else
        {
            if (isLock)
                return;

            UIManager.Instance.MouseBookDesc.SetActive(true);
            MouseBookData.Instance.NewMouseEffect.SetActive(false);
            MouseBookData.Instance.MouseBookDescImage.GetComponent<Image>().color = new Color(1, 0.9865527f, 0.9103774f, 1);
            DescDisplay();
        }
    }

    private void DescDisplay()
    {
        GameObject sprite = UIManager.Instance.MouseBookDescChild.transform.GetChild(0).gameObject;
        GameObject name = UIManager.Instance.MouseBookDescChild.transform.GetChild(1).gameObject;
        GameObject desc = UIManager.Instance.MouseBookDescChild.transform.GetChild(2).gameObject;

        sprite.GetComponent<Image>().sprite = MouseBookData.Instance.mouseBookList[tapId - 1].sprite;
        name.GetComponent<Text>().text = MouseBookData.Instance.mouseBookList[tapId - 1].name;
        desc.GetComponent<Text>().text = MouseBookData.Instance.mouseBookList[tapId - 1].desc;
    }
}