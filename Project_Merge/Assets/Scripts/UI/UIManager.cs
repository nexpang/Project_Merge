using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.VersionControl;
using Microsoft.Win32.SafeHandles;
using DG.Tweening;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text Cheese = null;
    [SerializeField]
    private Text Money = null;
    [SerializeField]
    private int NeedCheese = 0;
    [SerializeField]
    private int MCheese = 0;
    [SerializeField]
    private int Mmoney = 0;
    [SerializeField]
    private int mouseID = 0;
    [SerializeField]
    private GameObject mouse = null;
    [SerializeField]
    public Transform pposition = null;

    public bool isBGon = false;

    public GameObject Gmarket = null;
    public GameObject Catbackground = null;
    public GameObject Gbackground = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpreadCheese()
    {
        if(isBGon ? false : MCheese > NeedCheese)
        {
            MCheese -= NeedCheese;
            GameObject newmouse = Instantiate(mouse,pposition.position ,Quaternion.identity);
            newmouse.transform.SetParent(pposition.transform);

            UpdateMoneyCheese();    
        }
        else
        {

        }
    }
    private void UpdateMoneyCheese()
    {
        Money.text = Mmoney.ToString();
        Cheese.text = MCheese.ToString();
    }
    public void GmarketOpen()
    {
        if (Gmarket.activeSelf)
        {
            //Time.timeScale = 1; //시간 정상
            isBGon = true;
            Gmarket.SetActive(false);
        }
        else
        {
            isBGon = true;
            Gmarket.SetActive(true);
            //Time.timeScale = 0; //시간 멈춤
        }
    } //쥐마켓페이지올리기
    public void GmarketClose()
    {
        isBGon = false;
        Gmarket.SetActive(false);
    }
    public void BGMove()
    {
        if (Catbackground.activeSelf)
        {
            isBGon = false;
            //Time.timeScale = 1; //시간 정상
            Catbackground.transform.DOMoveX(-5, 0.1f);
            Gbackground.SetActive(true);
            Catbackground.SetActive(false);
        }
        else
        {
            isBGon = true;
            Catbackground.transform.DOMoveX(0, 1);
            Gbackground.SetActive(false);
            Catbackground.SetActive(true);
            //Time.timeScale = 0; //시간 멈춤
        }
    }
    public void CheeseCat()
    {
        MCheese++;
        UpdateMoneyCheese();
    }
}
