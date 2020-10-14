using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAnimation : MonoBehaviour
{
    [SerializeField]
    GameObject IntroLogo = null;
    [SerializeField]
    GameObject IntroBackground = null;
    [SerializeField]
    GameObject IntroTitle = null;

    void Start()
    {
        Invoke("GoToTitle", 3);
        InvokeRepeating("CheckClick", 4.5f, 0.166f);
    }

    private void GoToTitle()
    {
        IntroLogo.SetActive(false);
        IntroBackground.SetActive(false);
        IntroTitle.GetComponent<Animator>().Play("Intro_Title_Appear");
    }

    private void CheckClick()
    {
        if(Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("inGame(Merge)");
        }
    }
}