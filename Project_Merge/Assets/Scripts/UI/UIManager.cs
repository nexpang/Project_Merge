using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.VersionControl;
using Microsoft.Win32.SafeHandles;
using DG.Tweening;


public class UIManager : Singleton<UIManager>
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

    public bool isCatScene = false;


    public GameObject Gmarket = null;
    public GameObject MainCamera = null;
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
        if(isCatScene ? false : MCheese > NeedCheese)
        {
            MCheese -= NeedCheese;
            GameObject newmouse = Instantiate(mouse,new Vector3 (0,0,0.1f) ,Quaternion.identity);
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
            Gmarket.SetActive(false);
        }
        else
        {
            Gmarket.SetActive(true);
            //Time.timeScale = 0; //시간 멈춤
        }
    } //쥐마켓페이지올리기
    public void GmarketClose()
    {
        Gmarket.SetActive(false);
    }
    public void BGMove()
    {
        if (isCatScene)
        {
            //Time.timeScale = 1; //시간 정상
            Catoff();
        }
        else
        {
            Caton();

            //Time.timeScale = 0; //시간 멈춤
        }
    }
    private void Caton()
    {
        if(isCatScene == false)
        {
            MainCamera.transform.DOMoveX(-5, 1f);
            isCatScene = true;
        }
    }
    private void Catoff()
    {
        if(isCatScene == true)
        {
            MainCamera.transform.DOMoveX(0, 1);
            isCatScene = false;
        }
    }
    public void CheeseCat()
    {
        MCheese++;
        UpdateMoneyCheese();
    }

    public void AddMoney(int money)
    {
        Mmoney += money;
        UpdateMoneyCheese();
    }
}
