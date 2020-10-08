using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Microsoft.Win32.SafeHandles;
using DG.Tweening;


public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private Text Cheese = null;
    [SerializeField]
    private Text Money = null;
    [SerializeField]
    private Text CheeseUpgradeCostText = null;
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
    private int MCheeseUpgrade = 1;
    //[SerializeField]
    //private int MMoneyUpgrade = 1;
    [SerializeField]
    public Transform pposition = null;
    [SerializeField]
    private int MCheeseUpgradeCost = 0;


    private int MCheeseUpgradeAdd = 1;
    //private int MMoneyUpgradeAdd = 0;

    public bool isCatScene = false;

    public GameObject Gmarket = null;
    public GameObject MainCamera = null;
    public GameObject Gbackground = null;
    public GameObject MenuSet = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuSet.activeSelf)
                MenuSet.SetActive(false);
            else MenuSet.SetActive(true);
        }
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
        Money.text = string.Format("화폐 / {0:D} 원", Mmoney);
        Cheese.text = string.Format("치즈 / {0:D}", MCheese);
        CheeseUpgradeCostText.text = string.Format("{0:D} 원", MCheeseUpgradeCost);
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
        MCheese += MCheeseUpgradeAdd;
        UpdateMoneyCheese();
    }
    public void CheeseUpgrade()
    {
        if(Mmoney >= MCheeseUpgradeCost)
        {
            Mmoney -= MCheeseUpgradeCost;
            MCheeseUpgradeCost += GameStat.Instance.CheeseDataTable[MCheeseUpgrade];
            MCheeseUpgrade++;
            MCheeseUpgradeAdd = GameStat.Instance.CheeseDataTable[MCheeseUpgrade];
            UpdateMoneyCheese();
        }
        else
        {
            Debug.Log("Not enough Money");
        }
    }
    /*public void MoneyUpgrade()
    {
        MMoneyUpgrade++;
        MMoneyUpgradeAdd = GameStat.Instance.MoneyDataTable[MMoneyUpgrade];
    }*/

    public void MenuSetOn()
    {
        if (MenuSet.activeSelf)
            MenuSet.SetActive(false);
        else MenuSet.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void AddMoney(int money)
    {
        Mmoney += money;
        UpdateMoneyCheese();
    }

}
