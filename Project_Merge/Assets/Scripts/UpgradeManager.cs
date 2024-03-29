﻿using System.Collections;
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
        if (SaveMouse.Instance.gameData.AccessGetMoney() >= MarketManager.Instance.CatList[0].priceList[upgradeCount])
        {
            SaveMouse.Instance.gameData.AccessSetMoney(GameData.SETTYPE.REMOVE, MarketManager.Instance.CatList[0].priceList[upgradeCount]);
            SaveMouse.Instance.gameData.Upgrade_CheeseStack++;
            MarketManager.Instance.CatList[0].upgradeCount++;

            UpgradeComplete();
        }
        else
        {
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
        if (SaveMouse.Instance.gameData.AccessGetMoney() >= MarketManager.Instance.MouseList[0].priceList[upgradeCount])
        {
            SaveMouse.Instance.gameData.AccessSetMoney(GameData.SETTYPE.REMOVE, MarketManager.Instance.MouseList[0].priceList[upgradeCount]);
            SaveMouse.Instance.gameData.Upgrade_MoneyElapsedTimeStack++;
            MarketManager.Instance.MouseList[0].upgradeCount++;
            UpgradeComplete();
            
        }
        else
        {
            AudioManager.Instance.ASBuyFail.Play();
        }
    }

    public void Mouse1Upgrade()
    {
        int upgradeCount = MarketManager.Instance.MouseList[1].upgradeCount;
        if (MarketManager.Instance.MouseList[1].isMax == true)
        {
            AudioManager.Instance.ASBuyFail.Play();
            return;
        }
        if (SaveMouse.Instance.gameData.AccessGetMoney() >= MarketManager.Instance.MouseList[1].priceList[upgradeCount])
        {
            SaveMouse.Instance.gameData.AccessSetMoney(GameData.SETTYPE.REMOVE, MarketManager.Instance.MouseList[1].priceList[upgradeCount]);
            SaveMouse.Instance.gameData.Upgrade_MouseLimit = (int)MarketManager.Instance.MouseList[1].AddList[upgradeCount + 1];
            MarketManager.Instance.MouseList[1].upgradeCount++;
            UpgradeComplete();
        }
        else
        {
            AudioManager.Instance.ASBuyFail.Play();
        }
    }

    public void Mouse2Upgrade()
    {
        int upgradeCount = MarketManager.Instance.MouseList[2].upgradeCount;
        if (MarketManager.Instance.MouseList[2].isMax == true)
        {
            AudioManager.Instance.ASBuyFail.Play();
            return;
        }
        if (SaveMouse.Instance.gameData.AccessGetJewelry() >= MarketManager.Instance.MouseList[2].priceList[upgradeCount])
        {
            SaveMouse.Instance.gameData.AccessSetJewelry(GameData.SETTYPE.REMOVE, MarketManager.Instance.MouseList[2].priceList[upgradeCount]);
            SaveMouse.Instance.gameData.Upgrade_CleanerWaitTime = (int)MarketManager.Instance.MouseList[2].AddList[upgradeCount + 1];
            MarketManager.Instance.MouseList[2].upgradeCount++;
            SaveMouse.Instance.gameData.Upgrade_CleanerWaitTimeStack = MarketManager.Instance.MouseList[2].upgradeCount;
            if (SaveMouse.Instance.gameData.ItemCleaner == 0)
                SaveMouse.Instance.gameData.ItemCleaner = 1;
            UpgradeComplete();
        }
        else
        {
            AudioManager.Instance.ASBuyFail.Play();
        }
    }

    public void Guitar0Upgrade()
    {
        int upgradeCount = MarketManager.Instance.GuitarList[0].upgradeCount;
        if (MarketManager.Instance.GuitarList[0].isMax == true)
        {
            AudioManager.Instance.ASBuyFail.Play();
            return;
        }
        if (SaveMouse.Instance.gameData.AccessGetJewelry() >= MarketManager.Instance.GuitarList[0].priceList[upgradeCount])
        {
            SaveMouse.Instance.gameData.AccessSetJewelry(GameData.SETTYPE.REMOVE, MarketManager.Instance.GuitarList[0].priceList[upgradeCount]);
            SaveMouse.Instance.gameData.Upgrade_FeverWaitTime = (int)MarketManager.Instance.GuitarList[0].AddList[upgradeCount + 1];
            MarketManager.Instance.GuitarList[0].upgradeCount++;
            SaveMouse.Instance.gameData.Upgrade_FeverWaitTimeStack = MarketManager.Instance.GuitarList[0].upgradeCount;
            if (SaveMouse.Instance.gameData.ItemFever == 0)
                SaveMouse.Instance.gameData.ItemFever = 1;
            UpgradeComplete();
        }
        else
        {
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
        if (SaveMouse.Instance.gameData.AccessGetMoney() >= MarketManager.Instance.GuitarList[1].priceList[upgradeCount])
        {
            SaveMouse.Instance.gameData.AccessSetMoney(GameData.SETTYPE.REMOVE, MarketManager.Instance.GuitarList[1].priceList[upgradeCount]);
            SaveMouse.Instance.gameData.Upgrade_Background1 = 1;
            MarketManager.Instance.GuitarList[1].upgradeCount++;
            UpgradeComplete();

        }
        else
        {
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
        if (SaveMouse.Instance.gameData.AccessGetMoney() >= MarketManager.Instance.GuitarList[2].priceList[upgradeCount])
        {
            SaveMouse.Instance.gameData.AccessSetMoney(GameData.SETTYPE.REMOVE, MarketManager.Instance.GuitarList[2].priceList[upgradeCount]);
            SaveMouse.Instance.gameData.Upgrade_Background2 = 1;
            MarketManager.Instance.GuitarList[2].upgradeCount++;
            UpgradeComplete();

        }
        else
        {
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
        if (SaveMouse.Instance.gameData.AccessGetMoney() >= MarketManager.Instance.GuitarList[3].priceList[upgradeCount])
        {
            SaveMouse.Instance.gameData.AccessSetMoney(GameData.SETTYPE.REMOVE, MarketManager.Instance.GuitarList[3].priceList[upgradeCount]);
            SaveMouse.Instance.gameData.Upgrade_Background3 = 1;
            MarketManager.Instance.GuitarList[3].upgradeCount++;
            UpgradeComplete();

        }
        else
        {
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
