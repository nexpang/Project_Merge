using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroAnimation : MonoBehaviour
{
    [SerializeField]
    GameObject IntroLogo = null;
    [SerializeField]
    GameObject IntroBackground = null;
    [SerializeField]
    GameObject IntroTitle = null;
    [SerializeField]
    GameObject IntroTitleText = null;

    void Start()
    {
        Invoke("GoToTitle", 3);
    }

    private void GoToTitle()
    {
        IntroLogo.SetActive(false);
        IntroBackground.SetActive(false);
        IntroTitle.GetComponent<Animator>().Play("Intro_Title_Appear");
    }

    private void Update()
    {
        if(Input.GetMouseButton(0)&&IntroTitleText.GetComponent<Text>().color == new Color(0,0,0,1)&&IntroTitleText.activeSelf)
        {
            SceneManager.LoadScene("inGame(Merge)");
        }
    }
}