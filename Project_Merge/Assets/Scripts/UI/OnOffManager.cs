using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Button = null;
    public void ButtonActive()
    {
        AudioManager.Instance.ASButtonClick.Play();
        if (Button.activeSelf)
        {
            Button.SetActive(false);
        }
        else
        {
            Button.SetActive(true);
        }
    }
}
