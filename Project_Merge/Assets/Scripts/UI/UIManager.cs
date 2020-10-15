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
    private int mouseID = 0;
    [SerializeField]
    private GameObject mouse = null;

    //public int MCheeseUpgrade = 1; 아마 지울꺼

    [SerializeField]
    public Transform pposition = null;
    [SerializeField]
    private int MCheeseUpgradeCost = 0;


    private int MCheeseUpgradeAdd = 1;

    public bool isCatScene = false;

    public GameObject Gmarket = null;

    public GameObject MouseShop = null;
    public GameObject MoneyShop = null;
    public GameObject CheeseShop = null;

    public GameObject MainCamera = null;
    public GameObject Gbackground = null;
    public GameObject MenuSet = null;
    public GameObject CatBGCanvas = null;

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
        if(isCatScene ? false : SaveMouse.Instance.gameData.Cheese >= NeedCheese)
        {
            SaveMouse.Instance.gameData.Cheese -= NeedCheese;
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
            // TO DO: 치즈가 부족하다고 출력
        }
    }
    public void UpdateMoneyCheese()
    {
        MCheeseUpgradeAdd = GameStat.Instance.CheeseDataTable[SaveMouse.Instance.gameData.Upgrade_CheeseStack];
        MCheeseUpgradeCost = GameStat.Instance.CheeseDataTable[SaveMouse.Instance.gameData.Upgrade_CheeseStack];

        long money = SaveMouse.Instance.gameData.Money;
        string moneyText = "화폐 / ";

        if (money >= 100000000)
            moneyText += string.Format("{0}억", (money % 1000000000000) / 100000000);
        if (money >= 10000)
            moneyText += string.Format("{0}만", (money % 100000000) / 10000);
        if ( money >= 0)
            moneyText += string.Format("{0}원", money % 10000);
        Money.text = moneyText;

        long cheese = SaveMouse.Instance.gameData.Cheese;
        string cheeseText = "치즈 / ";

        if (cheese >= 10000)
            cheeseText += string.Format("{0}만", (cheese % 100000000) / 10000);
        if (cheese >= 0)
            cheeseText += string.Format("{0}개", cheese % 10000);
        Cheese.text = cheeseText;

        CheeseUpgradeCostText.text = string.Format("{0:#,###} 원", MCheeseUpgradeCost);
        SaveMouse.Instance.SaveGameData();
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
        SaveMouse.Instance.gameData.Cheese += MCheeseUpgradeAdd;
        float hitPx = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -2f, 2f);
        float hitPy = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -2.5f, 3.5f);
        MouseClickAnimation(hitPx , hitPy);
        UpdateMoneyCheese();

    }
    private void MouseClickAnimation(float x , float y)
    {
        Instantiate(GameObjectBox.Instance.CatClickAnimation, new Vector3(x-5, y, -2f), transform.rotation);
        CatBGCanvas.GetComponent<Animator>().Play("Cat_Click");
    }

    public void CheeseUpgrade()
    {
        if(SaveMouse.Instance.gameData.Money >= MCheeseUpgradeCost)
        {
            SaveMouse.Instance.gameData.Money -= MCheeseUpgradeCost;
            SaveMouse.Instance.gameData.Upgrade_CheeseStack++;
            MCheeseUpgradeAdd = GameStat.Instance.CheeseDataTable[SaveMouse.Instance.gameData.Upgrade_CheeseStack];
            MCheeseUpgradeCost = GameStat.Instance.CheeseDataTable[SaveMouse.Instance.gameData.Upgrade_CheeseStack];
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
        SaveMouse.Instance.gameData.Money += money;
        UpdateMoneyCheese();
    }

}
