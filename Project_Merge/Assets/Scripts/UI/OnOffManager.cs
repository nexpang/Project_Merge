using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Button = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && UIManager.Instance.isUIon == true && Button.activeSelf)
        {
            Button.SetActive(false);
        }
    }

    public void ButtonActive()
    {
        AudioManager.Instance.ASButtonClick.Play();
        if (Button.activeSelf)
        {
            UIManager.Instance.isUIon = false;
            Button.SetActive(false);
        }
        else
        {
            UIManager.Instance.isUIon = true;
            Button.SetActive(true);
        }
    }
}
