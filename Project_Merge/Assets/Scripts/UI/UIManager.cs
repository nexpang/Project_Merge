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

    public int MCheese = 0;
    public int Mmoney = 0;

    [SerializeField]
    private int mouseID = 0;
    [SerializeField]
    private GameObject mouse = null;

    public int MCheeseUpgrade = 1;

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

    public GameObject MouseShop = null;
    public GameObject MoneyShop = null;
    public GameObject CheeseShop = null;

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
        if(isCatScene ? false : MCheese >= NeedCheese)
        {
            MCheese -= NeedCheese;
            float randomMouseX = Random.Range(-1.8f, 1.8f);
            float randomMouseY = Random.Range(-2.2f, 3f);

            Vector3 randomSpawn = new Vector3(randomMouseX, randomMouseY, 0.1f);
            GameObject newmouse = Instantiate(mouse,randomSpawn,Quaternion.identity);
            newmouse.transform.SetParent(pposition.transform);
            newmouse.GetComponent<MouseElement>().MergeOrCreate();
            UpdateMoneyCheese();    
        }
        else
        {

        }
    }
    public void UpdateMoneyCheese()
    {
        MCheeseUpgradeAdd = GameStat.Instance.CheeseDataTable[MCheeseUpgrade];
        MCheeseUpgradeCost = GameStat.Instance.CheeseDataTable[MCheeseUpgrade];

        Money.text = string.Format("화폐 / {0:D} 원", Mmoney);
        Cheese.text = string.Format("치즈 / {0:D}", MCheese);
        CheeseUpgradeCostText.text = string.Format("{0:D} 원", MCheeseUpgradeCost);
    }
    public void GmarketOpen()//쥐마켓페이지On,Off
    {
        if (Gmarket.activeSelf)
        {
            Gmarket.SetActive(false);
        }
        else
        {
            Gmarket.SetActive(true);
        }
        UpdateMoneyCheese();
    }
    public void Cheese_Shop()
    {
        MouseShop.SetActive(false);
        MoneyShop.SetActive(false);
        CheeseShop.SetActive(true);
    }
    public void Money_Shop()
    {
        MouseShop.SetActive(false);
        MoneyShop.SetActive(true);
        CheeseShop.SetActive(false);
    }
    public void Mouse_Shop()
    {
        MouseShop.SetActive(true);
        MoneyShop.SetActive(false);
        CheeseShop.SetActive(false);
    }
    public void CheeseCat()
    {
        MCheese += MCheeseUpgradeAdd;
        float hitPx = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -2f, 2f);
        float hitPy = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -2.5f, 3.5f);
        MouseClickAnimation(hitPx , hitPy);
        UpdateMoneyCheese();

    }
    private void MouseClickAnimation(float x , float y)
    {
        Instantiate(GameObjectBox.Instance.CatClickAnimation, new Vector3(x-5, y, -2f), transform.rotation);
    }

    public void CheeseUpgrade()
    {
        if(Mmoney >= MCheeseUpgradeCost)
        {
            Mmoney -= MCheeseUpgradeCost;
            MCheeseUpgrade++;
            MCheeseUpgradeAdd = GameStat.Instance.CheeseDataTable[MCheeseUpgrade];
            MCheeseUpgradeCost = GameStat.Instance.CheeseDataTable[MCheeseUpgrade];
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
