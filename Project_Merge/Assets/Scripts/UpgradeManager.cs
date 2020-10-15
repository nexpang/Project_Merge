using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < MarketManager.Instance.CatList.Count; i++)
        {

        }
    }

    public void Cat0Upgrade()
    {
        int upgradeCount = MarketManager.Instance.CatList[0].upgradeCount;
        if (SaveMouse.Instance.gameData.Money >= MarketManager.Instance.CatList[0].priceList[upgradeCount])
        {
            SaveMouse.Instance.gameData.Money -= MarketManager.Instance.CatList[0].priceList[upgradeCount];
            SaveMouse.Instance.gameData.Upgrade_CheeseStack++;
            MarketManager.Instance.CatList[0].upgradeCount++;
            UIManager.Instance.UpdateMoneyCheese();
        }
        else
        {
            Debug.Log("Not enough Money");
        }
    }

    public void Mouse0Upgrade()
    {
        int upgradeCount = MarketManager.Instance.MouseList[0].upgradeCount;
        if (SaveMouse.Instance.gameData.Money >= MarketManager.Instance.MouseList[0].priceList[upgradeCount])
        {
            SaveMouse.Instance.gameData.Money -= MarketManager.Instance.MouseList[0].priceList[upgradeCount];
            SaveMouse.Instance.gameData.Upgrade_MoneyElapsedTimeStack++;
            MarketManager.Instance.MouseList[0].upgradeCount++;
            UIManager.Instance.UpdateMoneyCheese();
        }
        else
        {
            Debug.Log("Not enough Money");
        }
    }
}
