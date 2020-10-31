using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class MarketManager : Singleton<MarketManager>
{
    public List<MarketProduct> CatList = new List<MarketProduct>();
    public List<MarketProduct> MouseList = new List<MarketProduct>();
    public List<MarketProduct> GuitarList = new List<MarketProduct>();

    private void Awake()
    {
        Refresh();
        LoadUpgradeData();
    }

    private void Update()
    {
        Refresh();
    }

    public void Refresh()
    {
        //======================================고양이 탭 새로고침========================================
        for (int i = 0; i < CatList.Count; i++)
        {
            int productUpgradeCount = CatList[i].upgradeCount;
            if (productUpgradeCount >= CatList[i].priceList.Count) // 업그레이드가 최대로 찍혔는지 감지
            {
                CatList[i].isMax = true;
                CatList[i].Product.transform.GetChild(2).gameObject.GetComponent<Text>().text = string.Format("Max", CatList[i].price);
                CatList[i].Product.transform.GetChild(3).gameObject.GetComponent<Text>().text = "";
                CatList[i].Product.transform.GetChild(4).gameObject.SetActive(false);
                CatList[i].Product.transform.GetChild(6).gameObject.GetComponent<Text>().text = string.Format("{0}", CatList[i].AddList[productUpgradeCount]);
                if (i != CatList.Count)
                    continue;
                else
                    break;
            }

            CatList[i].price = CatList[i].priceList[productUpgradeCount];

            CatList[i].Product.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = CatList[i].ProductSprite;
            CatList[i].Product.transform.GetChild(1).gameObject.GetComponent<Text>().text = CatList[i].productName;
            CatList[i].Product.transform.GetChild(7).gameObject.GetComponent<Text>().text = CatList[i].productLore;
            CatList[i].Product.transform.GetChild(2).gameObject.GetComponent<Text>().text = string.Format("{0:#,###} 원", CatList[i].price);
            if (CatList[i].isSale) // 세일인가?
            {
                CatList[i].Product.transform.GetChild(3).gameObject.GetComponent<Text>().text = string.Format("{0:#,###} 원", CatList[i].price * 2);
                CatList[i].Product.transform.GetChild(4).gameObject.SetActive(true);
            }
            else
            {
                CatList[i].Product.transform.GetChild(3).gameObject.GetComponent<Text>().text = "";
                CatList[i].Product.transform.GetChild(4).gameObject.SetActive(false);
            }

            // 고양이 탭 목록 하나 당 개인 표시
            CatList[i].Product.transform.GetChild(6).gameObject.GetComponent<Text>().text = string.Format("{0} -> {1}", CatList[i].AddList[productUpgradeCount], CatList[i].AddList[productUpgradeCount + 1]);
        }
        //======================================고양이 탭 새로고침 끝========================================


        //======================================쥐 탭 새로고침========================================
        for (int i = 0; i < MouseList.Count; i++)
        {
            int productUpgradeCount = MouseList[i].upgradeCount;
            if (productUpgradeCount >= MouseList[i].priceList.Count) // 업그레이드가 최대로 찍혔는지 감지
            {
                MouseList[i].isMax = true;
                MouseList[i].Product.transform.GetChild(2).gameObject.GetComponent<Text>().text = string.Format("Max", MouseList[i].price);
                MouseList[i].Product.transform.GetChild(3).gameObject.GetComponent<Text>().text = "";
                MouseList[i].Product.transform.GetChild(4).gameObject.SetActive(false);
                MouseList[i].Product.transform.GetChild(6).gameObject.GetComponent<Text>().text = string.Format("{0}", MouseList[i].AddList[productUpgradeCount]);
                if (i != MouseList.Count)
                    continue;
                else
                    break;
            }

            MouseList[i].price = MouseList[i].priceList[productUpgradeCount];

            MouseList[i].Product.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = MouseList[i].ProductSprite;
            MouseList[i].Product.transform.GetChild(1).gameObject.GetComponent<Text>().text = MouseList[i].productName;
            MouseList[i].Product.transform.GetChild(7).gameObject.GetComponent<Text>().text = MouseList[i].productLore;
            MouseList[i].Product.transform.GetChild(2).gameObject.GetComponent<Text>().text = string.Format("{0:#,###} 원", MouseList[i].price);
            if (MouseList[i].isSale) // 세일인가?
            {
                MouseList[i].Product.transform.GetChild(3).gameObject.GetComponent<Text>().text = string.Format("{0:#,###} 원", MouseList[i].price * 2);
                MouseList[i].Product.transform.GetChild(4).gameObject.SetActive(true);
            }
            else
            {
                MouseList[i].Product.transform.GetChild(3).gameObject.GetComponent<Text>().text = "";
                MouseList[i].Product.transform.GetChild(4).gameObject.SetActive(false);
            }

            // 쥐 탭 목록 하나 당 개인 표시
            MouseList[0].Product.transform.GetChild(6).gameObject.GetComponent<Text>().text = string.Format("{0}초 -> {1}초", 4 - (MouseList[0].AddList[productUpgradeCount] * 0.1f) , 4 - (MouseList[0].AddList[productUpgradeCount+1] * 0.1f));
        }
        //======================================쥐 탭 새로고침 끝========================================

        //======================================기타 탭 새로고침========================================
        for (int i = 0; i < GuitarList.Count; i++)
        {
            int productUpgradeCount = GuitarList[i].upgradeCount;
            if (productUpgradeCount >= GuitarList[i].priceList.Count) // 업그레이드가 최대로 찍혔는지 감지
            {
                GuitarList[i].isMax = true;
                if(GuitarList[i].onceUpgrade) // 한번만 구매하면 끝인것들
                    GuitarList[i].Product.transform.GetChild(2).gameObject.GetComponent<Text>().text = string.Format("보유 중");
                else
                    GuitarList[i].Product.transform.GetChild(2).gameObject.GetComponent<Text>().text = string.Format("Max");
                GuitarList[i].Product.transform.GetChild(3).gameObject.GetComponent<Text>().text = "";
                GuitarList[i].Product.transform.GetChild(4).gameObject.SetActive(false);
                GuitarList[i].Product.transform.GetChild(6).gameObject.GetComponent<Text>().text = string.Format("{0}", GuitarList[i].AddList[productUpgradeCount]);
                if (i != GuitarList.Count)
                    continue;
                else
                    break;
            }
            

            GuitarList[i].price = GuitarList[i].priceList[productUpgradeCount];

            GuitarList[i].Product.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = GuitarList[i].ProductSprite;
            GuitarList[i].Product.transform.GetChild(1).gameObject.GetComponent<Text>().text = GuitarList[i].productName;
            GuitarList[i].Product.transform.GetChild(7).gameObject.GetComponent<Text>().text = GuitarList[i].productLore;

            if (GuitarList[i].jewelryNeed) // 돈이아니고 보석으로 사용하는가?
            {
                GuitarList[i].Product.transform.GetChild(2).gameObject.GetComponent<Text>().text = string.Format("{0:#,###} 개", GuitarList[i].price);
                GuitarList[i].Product.transform.GetChild(8).gameObject.SetActive(true);
            }
            else
                GuitarList[i].Product.transform.GetChild(2).gameObject.GetComponent<Text>().text = string.Format("{0:#,###} 원", GuitarList[i].price);

            if (GuitarList[i].isSale) // 세일인가?
            {
                if (GuitarList[i].jewelryNeed) // 돈이아니고 보석으로 사용하는가?
                    GuitarList[i].Product.transform.GetChild(3).gameObject.GetComponent<Text>().text = string.Format("{0:#,###} 개", GuitarList[i].price * 2);
                else
                    GuitarList[i].Product.transform.GetChild(3).gameObject.GetComponent<Text>().text = string.Format("{0:#,###} 원", GuitarList[i].price * 2);
                GuitarList[i].Product.transform.GetChild(4).gameObject.SetActive(true);
            }
            else
            {
                GuitarList[i].Product.transform.GetChild(3).gameObject.GetComponent<Text>().text = "";
                GuitarList[i].Product.transform.GetChild(4).gameObject.SetActive(false);
            }

            // 기타 탭 목록 하나 당 개인 표시
            GuitarList[0].Product.transform.GetChild(6).gameObject.GetComponent<Text>().text = string.Format("{0}초 -> {1}초", GuitarList[0].AddList[productUpgradeCount], GuitarList[0].AddList[productUpgradeCount + 1]);
        }
        //======================================기타 탭 새로고침 끝========================================
    }

    private void LoadUpgradeData()
    {
        CatList[0].upgradeCount = SaveMouse.Instance.gameData.Upgrade_CheeseStack;
        MouseList[0].upgradeCount = SaveMouse.Instance.gameData.Upgrade_MoneyElapsedTimeStack;
        GuitarList[1].upgradeCount = SaveMouse.Instance.gameData.Upgrade_Background1;
        GuitarList[2].upgradeCount = SaveMouse.Instance.gameData.Upgrade_Background2;
        GuitarList[3].upgradeCount = SaveMouse.Instance.gameData.Upgrade_Background3;
    }
}

[Serializable]
public class MarketProduct
{
    public GameObject Product = null;
    public Sprite ProductSprite = null;
    public string productName = "";
    public string productLore = "";
    public bool isSale = true;
    public bool onceUpgrade = false;
    public bool jewelryNeed = false;

    //[HideInInspector]
    public int upgradeCount = 0;
    [HideInInspector]
    public long price = 0;

    [HideInInspector]
    public bool isMax = false;

    public List<long> priceList = new List<long>();
    public List<long> AddList = new List<long>();
}
