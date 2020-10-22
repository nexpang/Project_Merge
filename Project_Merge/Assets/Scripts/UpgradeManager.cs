using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{

    public void Cat0Upgrade()
    {
        int upgradeCount = MarketManager.Instance.CatList[0].upgradeCount;
        if(MarketManager.Instance.CatList[0].isMax == true)
        {
            AudioManager.Instance.ASBuyFail.Play();
            return;
        }
        if (SaveMouse.Instance.gameData.Money >= MarketManager.Instance.CatList[0].priceList[upgradeCount])
        {
            SaveMouse.Instance.gameData.Money -= MarketManager.Instance.CatList[0].priceList[upgradeCount];
            SaveMouse.Instance.gameData.Upgrade_CheeseStack++;
            MarketManager.Instance.CatList[0].upgradeCount++;

            UpgradeComplete();
        }
        else
        {
            Debug.Log("Not enough Money");
            AudioManager.Instance.ASBuyFail.Play();
        }
    }

    public void Mouse0Upgrade()
    {
        int upgradeCount = MarketManager.Instance.MouseList[0].upgradeCount;
        if (MarketManager.Instance.MouseList[0].isMax == true)
        {
            AudioManager.Instance.ASBuyFail.Play();
            return;
        }
        if (SaveMouse.Instance.gameData.Money >= MarketManager.Instance.MouseList[0].priceList[upgradeCount])
        {
            SaveMouse.Instance.gameData.Money -= MarketManager.Instance.MouseList[0].priceList[upgradeCount];
            SaveMouse.Instance.gameData.Upgrade_MoneyElapsedTimeStack++;
            MarketManager.Instance.MouseList[0].upgradeCount++;
            UpgradeComplete();

        }
        else
        {
            Debug.Log("Not enough Money");
            AudioManager.Instance.ASBuyFail.Play();
        }
    }


    private void UpgradeComplete()
    {
        UIManager.Instance.UpdateMoneyCheese();
        AudioManager.Instance.FBuySound();
        SaveMouse.Instance.SaveGameData();
    }
}
