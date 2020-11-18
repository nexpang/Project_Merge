using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    [Header("화폐")]
    public long Cheese = 0;
    public long Money = 0;
    public long JewelryMoney { get; private set; } = 0;

    [Header("업그레이드 데이터")]
    public int Upgrade_MoneyElapsedTimeStack = 0;
    public int Upgrade_CheeseStack = 0;
    public int Upgrade_MouseLimit = 8;

    public int Upgrade_CleanerWaitTime = 200;
    public int Upgrade_CleanerWaitTimeStack = 0;
    public int ItemCleaner = 0; // 0이면 없음, 1이면 off, 2이면 on

    public int Upgrade_FeverWaitTime = 300;
    public int Upgrade_FeverWaitTimeStack = 0;
    public int ItemFever = 0; // 0이면 없음, 1이면 준비중, 2면 준비완료

    public int Upgrade_Background1 = 0;
    public int Upgrade_Background2 = 0;
    public int Upgrade_Background3 = 0;

    public int currentBackground = 0; // 0 - 기본배경, 1 - 쥐평선, 2 - 노을, 3 - 쥐리산

    [Header("튜토리얼 세이브")]
    public int TutorialStage = 0;

    [Header("쥐 리스트/좌표")]
    public List<int> MiceList = new List<int>();
    public List<Vector2> MiceXY = new List<Vector2>();

    public enum SETTYPE
    {
        SET,
        ADD,
        REMOVE,
    };

    public void AccessSetJewelry(SETTYPE settype,long value)
    {
        switch(settype)
        {
            case SETTYPE.SET: JewelryMoney = value; break;
            case SETTYPE.ADD: JewelryMoney += value; break;
            case SETTYPE.REMOVE: JewelryMoney -= value; break;
        }
    }
}