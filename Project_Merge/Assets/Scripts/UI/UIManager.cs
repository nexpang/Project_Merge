using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Microsoft.Win32.SafeHandles;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private Text Cheese = null;
    [SerializeField]
    private Text Money = null;
    [SerializeField]
    private Text jewelryMoney = null;
    [SerializeField]
    private Text marketMoney = null;
    [SerializeField]
    private int NeedCheese = 0;

    [SerializeField]
    private GameObject mouse = null;

    //public int MCheeseUpgrade = 1; 아마 지울꺼

    [SerializeField]
    public Transform pposition = null;

    public bool isCatScene = false;

    public GameObject Gmarket = null;

    public GameObject MouseShop = null;
    public GameObject MoneyShop = null;
    public GameObject CheeseShop = null;

    public GameObject MainCamera = null;
    public GameObject Gbackground = null;
    public GameObject MenuSet = null;
    public GameObject CatBGCanvas = null;
    public GameObject MarketTab = null;
    public Sprite[] MarketTabImage = null;
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
        AudioManager.Instance.ASButtonClick.Play();
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
        long money = SaveMouse.Instance.gameData.Money;
        string moneyText = "x ";

        if (money >= 100000000)
            moneyText += string.Format("{0}억", (money % 1000000000000) / 100000000);
        if (money >= 10000)
            moneyText += string.Format("{0}만", (money % 100000000) / 10000);
        if ( money >= 0)
            moneyText += string.Format("{0}원", money % 10000);
        Money.text = moneyText;
        marketMoney.text = moneyText;

        long jewelrymoney = SaveMouse.Instance.gameData.JewelryMoney;
        string jewelryMoneyText = "x ";

        if (jewelrymoney >= 100000000)
            jewelryMoneyText += string.Format("{0}억", (jewelrymoney % 1000000000000) / 100000000);
        if (jewelrymoney >= 10000)
            jewelryMoneyText += string.Format("{0}만", (jewelrymoney % 100000000) / 10000);
        if (jewelrymoney >= 0)
            jewelryMoneyText += string.Format("{0}원", jewelrymoney % 10000);

        jewelryMoney.text = jewelryMoneyText;


        long cheese = SaveMouse.Instance.gameData.Cheese;
        string cheeseText = "x ";

        if (cheese >= 10000)
            cheeseText += string.Format("{0}만", (cheese % 100000000) / 10000);
        if (cheese >= 0)
            cheeseText += string.Format("{0}개", cheese % 10000);
        Cheese.text = cheeseText;
    }
    public void GmarketOpen()//쥐마켓페이지On,Off
    {
        AudioManager.Instance.ASButtonClick.Play();
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
        AudioManager.Instance.ASButtonClick.Play();
        MarketManager.Instance.Refresh();
        MouseShop.SetActive(false);
        MoneyShop.SetActive(false);
        CheeseShop.SetActive(true);

        MarketTab.GetComponent<Image>().sprite = MarketTabImage[0];
    }
    public void Money_Shop()
    {
        AudioManager.Instance.ASButtonClick.Play();
        MarketManager.Instance.Refresh();
        MouseShop.SetActive(false);
        MoneyShop.SetActive(true);
        CheeseShop.SetActive(false);

        MarketTab.GetComponent<Image>().sprite = MarketTabImage[2];
    }
    public void Mouse_Shop()
    {
        AudioManager.Instance.ASButtonClick.Play();
        MarketManager.Instance.Refresh();
        MouseShop.SetActive(true);
        MoneyShop.SetActive(false);
        CheeseShop.SetActive(false);
 
        MarketTab.GetComponent<Image>().sprite = MarketTabImage[1];
    }
    public void CheeseCat()
    {
        AudioManager.Instance.FCatClick();
        SaveMouse.Instance.gameData.Cheese += MarketManager.Instance.CatList[0].AddList[SaveMouse.Instance.gameData.Upgrade_CheeseStack];
        float hitPx = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -2f, 2f);
        float hitPy = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -2.5f, 3.5f);
        CatClickAnimation();
        UpdateMoneyCheese();

    }
    private void CatClickAnimation()
    {
        Instantiate(GameObjectBox.Instance.CatClickAnimation, Vector3.zero, Quaternion.identity);
        CatBGCanvas.GetComponent<Animator>().Play("Cat_Click");
    }

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
