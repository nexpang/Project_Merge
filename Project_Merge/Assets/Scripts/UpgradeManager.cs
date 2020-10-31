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

    public void Guitar1Upgrade()
    {
        int upgradeCount = MarketManager.Instance.GuitarList[1].upgradeCount;
        if (MarketManager.Instance.GuitarList[1].isMax == true)
        {
            AudioManager.Instance.ASButtonClick.Play();
            if (SaveMouse.Instance.gameData.currentBackground == 1)
            {
                SaveMouse.Instance.gameData.currentBackground = 0;
                return;
            }
            SaveMouse.Instance.gameData.currentBackground = 1;
            return;
        }
        if (SaveMouse.Instance.gameData.Money >= MarketManager.Instance.GuitarList[1].priceList[upgradeCount])
        {
            SaveMouse.Instance.gameData.Money -= MarketManager.Instance.GuitarList[1].priceList[upgradeCount];
            SaveMouse.Instance.gameData.Upgrade_Background1 = 1;
            MarketManager.Instance.GuitarList[1].upgradeCount++;
            UpgradeComplete();

        }
        else
        {
            Debug.Log("Not enough Money");
            AudioManager.Instance.ASBuyFail.Play();
        }
    }

    public void Guitar2Upgrade()
    {
        int upgradeCount = MarketManager.Instance.GuitarList[2].upgradeCount;
        if (MarketManager.Instance.GuitarList[2].isMax == true)
        {
            AudioManager.Instance.ASButtonClick.Play();
            if (SaveMouse.Instance.gameData.currentBackground == 2)
            {
                SaveMouse.Instance.gameData.currentBackground = 0;
                return;
            }
            SaveMouse.Instance.gameData.currentBackground = 2;
            return;
        }
        if (SaveMouse.Instance.gameData.Money >= MarketManager.Instance.GuitarList[2].priceList[upgradeCount])
        {
            SaveMouse.Instance.gameData.Money -= MarketManager.Instance.GuitarList[2].priceList[upgradeCount];
            SaveMouse.Instance.gameData.Upgrade_Background2 = 1;
            MarketManager.Instance.GuitarList[2].upgradeCount++;
            UpgradeComplete();

        }
        else
        {
            Debug.Log("Not enough Money");
            AudioManager.Instance.ASBuyFail.Play();
        }
    }

    public void Guitar3Upgrade()
    {
        int upgradeCount = MarketManager.Instance.GuitarList[3].upgradeCount;
        if (MarketManager.Instance.GuitarList[3].isMax == true)
        {
            AudioManager.Instance.ASButtonClick.Play();
            if (SaveMouse.Instance.gameData.currentBackground == 3)
            {
                SaveMouse.Instance.gameData.currentBackground = 0;
                return;
            }
            SaveMouse.Instance.gameData.currentBackground = 3;
            return;
        }
        if (SaveMouse.Instance.gameData.Money >= MarketManager.Instance.GuitarList[3].priceList[upgradeCount])
        {
            SaveMouse.Instance.gameData.Money -= MarketManager.Instance.GuitarList[3].priceList[upgradeCount];
            SaveMouse.Instance.gameData.Upgrade_Background3 = 1;
            MarketManager.Instance.GuitarList[3].upgradeCount++;
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
