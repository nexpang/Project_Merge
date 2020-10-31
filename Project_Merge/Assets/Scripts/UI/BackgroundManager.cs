using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] backgroundObject = null;

    [SerializeField]
    private GameObject[] backgroundDisplay = null;

    [SerializeField]
    private Sprite[] backgroundDisplaySprite = null;

    void Update()
    {
        if (SaveMouse.Instance.gameData.currentBackground==0)
        {
            backgroundObject[0].SetActive(true);
            backgroundObject[1].SetActive(false);
            backgroundObject[2].SetActive(false);
            backgroundObject[3].SetActive(false);
            backgroundDisplay[0].GetComponent<Image>().sprite = backgroundDisplaySprite[0];
            backgroundDisplay[1].GetComponent<Image>().sprite = backgroundDisplaySprite[0];
            backgroundDisplay[2].GetComponent<Image>().sprite = backgroundDisplaySprite[0];
        }
        if (SaveMouse.Instance.gameData.currentBackground == 1)
        {
            backgroundObject[0].SetActive(false);
            backgroundObject[1].SetActive(true);
            backgroundObject[2].SetActive(false);
            backgroundObject[3].SetActive(false);
            backgroundDisplay[0].GetComponent<Image>().sprite = backgroundDisplaySprite[1];
            backgroundDisplay[1].GetComponent<Image>().sprite = backgroundDisplaySprite[0];
            backgroundDisplay[2].GetComponent<Image>().sprite = backgroundDisplaySprite[0];
        }
        if (SaveMouse.Instance.gameData.currentBackground == 2)
        {
            backgroundObject[0].SetActive(false);
            backgroundObject[1].SetActive(false);
            backgroundObject[2].SetActive(true);
            backgroundObject[3].SetActive(false);
            backgroundDisplay[0].GetComponent<Image>().sprite = backgroundDisplaySprite[0];
            backgroundDisplay[1].GetComponent<Image>().sprite = backgroundDisplaySprite[1];
            backgroundDisplay[2].GetComponent<Image>().sprite = backgroundDisplaySprite[0];
        }
        if (SaveMouse.Instance.gameData.currentBackground == 3)
        {
            backgroundObject[0].SetActive(false);
            backgroundObject[1].SetActive(false);
            backgroundObject[2].SetActive(false);
            backgroundObject[3].SetActive(true);
            backgroundDisplay[0].GetComponent<Image>().sprite = backgroundDisplaySprite[0];
            backgroundDisplay[1].GetComponent<Image>().sprite = backgroundDisplaySprite[0];
            backgroundDisplay[2].GetComponent<Image>().sprite = backgroundDisplaySprite[1];
        }
    }
}
