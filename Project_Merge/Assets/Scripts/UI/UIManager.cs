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
    private Text marketJewelryMoney = null;
    [SerializeField]
    private Text shopJewelryMoney = null;
    [SerializeField]
    private int NeedCheese = 0;

    public GameObject MouseBookDesc = null;
    public GameObject MouseBookDescChild = null;

    [SerializeField]
    private GameObject mouse = null;

    public GameObject MouseBook = null;

    [SerializeField]
    private GameObject Option = null;

    [SerializeField]
    private GameObject Shop = null;

    [SerializeField]
    private Text MouseLimitText = null;

    public bool isUIon = false;

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
    void LateUpdate()
    {
        MouseLimitText.text = string.Format("{0} / {1}", pposition.childCount, SaveMouse.Instance.gameData.Upgrade_MouseLimit);
        if (Input.GetKeyDown(KeyCode.Escape) && isUIon == false)
        {
            if (MenuSet.activeSelf)
                MenuSet.SetActive(false);
            else MenuSet.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isUIon == true) 
        {
            if (SaveMouse.Instance.gameData.TutorialStage == 7 || SaveMouse.Instance.gameData.TutorialStage == 8 || SaveMouse.Instance.gameData.TutorialStage == 9)
                return;
            if (TutorialManager.Instance.TutorialImage.activeSelf)
            {
                TutorialManager.Instance.TutorialImage.SetActive(false);
                return;
            }
            Gmarket.SetActive(false);
            Option.SetActive(false);
            Shop.SetActive(false);

            if (MouseBookDesc.activeSelf)
            {
                MouseBookDesc.SetActive(false);
                if (!MouseBookDesc.activeSelf)
                {
                    isUIon = false;
                }
            }
            else
            {
                MouseBook.SetActive(false);
                isUIon = false;
            }
        }
    }

    public void SpreadCheese()
    {
        AudioManager.Instance.ASButtonClick.Play();
        if (!GameStat.Instance.MouseCountCheck())
            return;

        if(isCatScene ? false : SaveMouse.Instance.gameData.AccessGetCheese() >= NeedCheese)
        {
            SaveMouse.Instance.gameData.AccessSetCheese(GameData.SETTYPE.REMOVE, NeedCheese);
            float randomMouseX = Random.Range(-1.8f, 1.8f);
            float randomMouseY = Random.Range(-2.2f, 1.8f);

            Vector3 randomSpawn = new Vector3(randomMouseX, randomMouseY, 0.1f);
            GameObject newmouse = Instantiate(mouse,randomSpawn,Quaternion.identity);
            newmouse.transform.SetParent(pposition.transform);
            newmouse.GetComponent<MouseElement>().MergeOrCreate();
            UpdateMoneyCheese();
            MouseBookData.Instance.SetLastMouseID(true);
        }
        else
        {
            // TO DO: 치즈가 부족하다고 출력.
        }
    }
    public void UpdateMoneyCheese()
    {
        long money = SaveMouse.Instance.gameData.AccessGetMoney();
        string moneyText = "";

        if (money >= 100000000)
            moneyText += string.Format("{0}억", (money % 1000000000000) / 100000000);
        if (money >= 10000)
            moneyText += string.Format("{0}만", (money % 100000000) / 10000);
        if ( money >= 0)
            moneyText += string.Format("{0}원", money % 10000);
        Money.text = moneyText;
        marketMoney.text = moneyText;

        long jewelrymoney = SaveMouse.Instance.gameData.AccessGetJewelry();
        string jewelryMoneyText = "";

        if (jewelrymoney >= 100000000)
            jewelryMoneyText += string.Format("{0}억", (jewelrymoney % 1000000000000) / 100000000);
        if (jewelrymoney >= 10000)
            jewelryMoneyText += string.Format("{0}만", (jewelrymoney % 100000000) / 10000);
        if (jewelrymoney >= 0)
            jewelryMoneyText += string.Format("{0}개", jewelrymoney % 10000);

        jewelryMoney.text = jewelryMoneyText;
        marketJewelryMoney.text = jewelryMoneyText;
        shopJewelryMoney.text = jewelryMoneyText;

        long cheese = SaveMouse.Instance.gameData.AccessGetCheese();
        string cheeseText = "";

        if (cheese >= 100000000)
            cheeseText += string.Format("{0}억", (cheese % 1000000000000) / 100000000);
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
            isUIon = false;
            Gmarket.SetActive(false);
        }
        else
        {
            isUIon = true;
            Gmarket.SetActive(true);
        }
        UpdateMoneyCheese();
        FunctionManager.Instance.RefreshScroll();
    }
    public void Cheese_Shop()
    {
        AudioManager.Instance.ASButtonClick.Play();
        MarketManager.Instance.Refresh();
        MouseShop.SetActive(false);
        MoneyShop.SetActive(false);
        CheeseShop.SetActive(true);

        MarketTab.GetComponent<Image>().sprite = MarketTabImage[0];
        FunctionManager.Instance.RefreshScroll();
    }
    public void Money_Shop()
    {
        AudioManager.Instance.ASButtonClick.Play();
        MarketManager.Instance.Refresh();
        MouseShop.SetActive(false);
        MoneyShop.SetActive(true);
        CheeseShop.SetActive(false);

        MarketTab.GetComponent<Image>().sprite = MarketTabImage[2];
        FunctionManager.Instance.RefreshScroll();
    }
    public void Mouse_Shop()
    {
        AudioManager.Instance.ASButtonClick.Play();
        MarketManager.Instance.Refresh();
        MouseShop.SetActive(true);
        MoneyShop.SetActive(false);
        CheeseShop.SetActive(false);
 
        MarketTab.GetComponent<Image>().sprite = MarketTabImage[1];
        FunctionManager.Instance.RefreshScroll();
    }
    public void CheeseCat()
    {
        AudioManager.Instance.FCatClick();
        SaveMouse.Instance.gameData.AccessSetCheese(GameData.SETTYPE.ADD, MarketManager.Instance.CatList[0].AddList[SaveMouse.Instance.gameData.Upgrade_CheeseStack]);
        if (GameStat.Instance.isFever && GameObject.Find("ChangeScroll").GetComponent<Scrollbar>().value >= 0.5)
            SaveMouse.Instance.gameData.AccessSetCheese(GameData.SETTYPE.ADD, MarketManager.Instance.CatList[0].AddList[SaveMouse.Instance.gameData.Upgrade_CheeseStack]);
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
        {
            MenuSet.SetActive(false);
        }
        else
        {
            MenuSet.SetActive(true);
        } 
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void MouseBookActive()
    {
        AudioManager.Instance.ASButtonClick.Play();
        if (MouseBook.activeSelf)
        {
            isUIon = false;
            MouseBook.SetActive(false);
        }
        else 
        {
            isUIon = true;
            MouseBook.SetActive(true);
            MouseBookData.Instance.RefreshBook();
        }
    }
    public void MouseBookDescActive()
    {

    }
    public void OptionActive()
    {
        AudioManager.Instance.ASButtonClick.Play();
        if (Option.activeSelf)
        {
            isUIon = false;
            Option.SetActive(false);
        }
        else
        {
            isUIon = true;
            Option.SetActive(true);
        }
    }

    public void ShopActive()
    {
        AudioManager.Instance.ASButtonClick.Play();
        if (Shop.activeSelf)
        {
            isUIon = false;
            Shop.SetActive(false);
        }
        else
        {
            isUIon = true;
            Shop.SetActive(true);
            Gmarket.SetActive(false);
        }
        UpdateMoneyCheese();
        FunctionManager.Instance.RefreshScroll();
    }

    public Text CompleteText = null;

    public void Repair()
    {
        AudioManager.Instance.ASButtonClick.Play();
        if (SaveMouse.Instance.gameData.AccessRepairBoolJMGet() == false)
        {
            SaveMouse.Instance.gameData.AccessRepairBoolJM(true);
            SaveMouse.Instance.gameData.AccessSetJewelry(GameData.SETTYPE.SET,SaveMouse.Instance.gameData.JewelryMoney);
            SaveMouse.Instance.gameData.AccessSetMoney(GameData.SETTYPE.SET,SaveMouse.Instance.gameData.Money);
            SaveMouse.Instance.gameData.AccessSetCheese(GameData.SETTYPE.SET,SaveMouse.Instance.gameData.Cheese);
            UpdateMoneyCheese();
            CompleteText.text = "복구가 끝났다쥐!";
        }
        else
        {
            CompleteText.text = "한번만 할 수 있쥐..";
        }
        SaveMouse.Instance.SaveGameData();
        Invoke("CompleteTextDisappear", 3);
    }

    private void CompleteTextDisappear()
    {
        CompleteText.text = "";
    }
}
